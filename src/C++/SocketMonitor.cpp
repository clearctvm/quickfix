/****************************************************************************
** Copyright (c) quickfixengine.org  All rights reserved.
**
** This file is part of the QuickFIX FIX Engine
**
** This file may be distributed under the terms of the quickfixengine.org
** license as defined by quickfixengine.org and appearing in the file
** LICENSE included in the packaging of this file.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** See http://www.quickfixengine.org/LICENSE for licensing information.
**
** Contact ask@quickfixengine.org if any conditions of this licensing are
** not clear to you.
**
****************************************************************************/

#ifdef _MSC_VER
#include "stdafx.h"
#else
#include "config.h"
#endif
#include "CallStack.h"

#include "SocketMonitor.h"
#include "Utility.h"
#include <exception>
#include <set>
#include <algorithm>
#include <iostream>

namespace FIX
{
SocketMonitor::SocketMonitor( int timeout )
: m_timeout( timeout )
{
  socket_init();

  m_timeval.tv_sec = 0;
  m_timeval.tv_usec = 0;
#ifndef SELECT_DECREMENTS_TIME
  m_ticks = clock();
#endif
}

SocketMonitor::~SocketMonitor()
{
  Sockets::iterator i;
  for ( i = m_readSockets.begin(); i != m_readSockets.end(); ++i )
    socket_close( *i );

  socket_term();
}

bool SocketMonitor::addRead( int s )
{ QF_STACK_PUSH(SocketMonitor::add)

  socket_setnonblock( s );
  Sockets::iterator i = m_readSockets.find( s );
  if( i != m_readSockets.end() ) return false;

  m_readSockets.insert( s );
  return true;

  QF_STACK_POP
}

bool SocketMonitor::addWrite( int s )
{ QF_STACK_PUSH(SocketMonitor::add)

  socket_setnonblock( s );
  Sockets::iterator i = m_writeSockets.find( s );
  if( i != m_writeSockets.end() ) return false;

  m_writeSockets.insert( s );
  return true;

  QF_STACK_POP
}

bool SocketMonitor::drop( int s )
{ QF_STACK_PUSH(SocketMonitor::drop)

  Sockets::iterator i = m_readSockets.find( s );
  Sockets::iterator j = m_writeSockets.find( s );
 
  if ( i != m_readSockets.end() || j != m_writeSockets.end() )
  {
    socket_close( s );
    m_readSockets.erase( s );
    m_writeSockets.erase( s );
    m_dropped.push( s );
    return true;
  }
  return false;

  QF_STACK_POP
}

inline timeval* SocketMonitor::getTimeval( bool poll )
{ QF_STACK_PUSH(SocketMonitor::getTimeval)

  if ( poll )
  {
    m_timeval.tv_sec = 0;
    m_timeval.tv_usec = 0;
    return &m_timeval;
  }

  if ( !m_timeout )
    return 0;
#ifdef SELECT_MODIFIES_TIMEVAL
  if ( !m_timeval.tv_sec && !m_timeval.tv_usec && m_timeout )
    m_timeval.tv_sec = m_timeout;
  return &m_timeval;
#else
double elapsed = ( double ) ( clock() - m_ticks ) / ( double ) CLOCKS_PER_SEC;
  if ( elapsed >= m_timeout || elapsed == 0.0 )
  {
    m_ticks = clock();
    m_timeval.tv_sec = 0;
    m_timeval.tv_usec = m_timeout * 1000000;
  }
  else
  {
    m_timeval.tv_sec = 0;
    m_timeval.tv_usec = ( long ) ( ( m_timeout - elapsed ) * 1000000 );
  }
  return &m_timeval;
#endif

  QF_STACK_POP
}

bool SocketMonitor::sleepIfEmpty( bool poll )
{ QF_STACK_PUSH(SocketMonitor::sleepIfEmpty)

  if( poll )
    return false;

  if ( m_readSockets.empty() && m_writeSockets.empty() )
  {
    process_sleep( m_timeout );
    return true;
  }
  else
    return false;

  QF_STACK_POP
}

void SocketMonitor::block( Strategy& strategy, bool poll )
{ QF_STACK_PUSH(SocketMonitor::block)

  while ( m_dropped.size() )
  {
    strategy.onError( *this, m_dropped.front() );
    m_dropped.pop();
    if ( m_dropped.size() == 0 )
      return ;
  }

  fd_set readSet;
  buildSet( m_readSockets, readSet );
  fd_set writeSet;
  buildSet( m_writeSockets, writeSet );

  if ( sleepIfEmpty(poll) )
  {
    strategy.onTimeout( *this );
    return ;
  }

  int result = select( FD_SETSIZE, &readSet, &writeSet, 0, getTimeval(poll) );

  if ( result == 0 )
  {
    strategy.onTimeout( *this );
    return;
  }
  else if ( result > 0 )
  {
    processReadSet( strategy, readSet );
    processWriteSet( strategy, writeSet );
  }
#ifndef _MSC_VER
  else if ( errno == EBADF )
  {
    Sockets::iterator i;
    for ( i = m_readSockets.begin(); i != m_readSockets.end(); ++i )
    {
      if ( socket_isBad( *i ) )
      {
        m_readSockets.erase( *i );
        strategy.onError( *this, *i );
      }
    }
    return ;
  }
#endif
  else
    strategy.onError( *this );

  QF_STACK_POP
}

void SocketMonitor::processReadSet( Strategy& strategy, fd_set& readSet )
{ QF_STACK_PUSH(SocketMonitor::processReadSet)

#ifdef _MSC_VER
  for ( unsigned i = 0; i < readSet.fd_count; ++i )
  {
    int s = readSet.fd_array[ i ];
    strategy.onEvent( *this, s );
  }
#else
    Sockets::iterator i;
    Sockets sockets = m_readSockets;
    for ( i = sockets.begin(); i != sockets.end(); ++i )
    {
      int s = *i;
      if ( !FD_ISSET( *i, &readSet ) )
        continue;
      strategy.onEvent( *this, s );
    }
#endif

  QF_STACK_POP
}

void SocketMonitor::processWriteSet( Strategy& strategy, fd_set& writeSet )
{ QF_STACK_PUSH(SocketMonitor::processWriteSet)

#ifdef _MSC_VER
  for ( unsigned i = 0; i < writeSet.fd_count; ++i )
  {
    int s = writeSet.fd_array[ i ];
    strategy.onConnect( *this, s );
    m_writeSockets.erase( s );
    m_readSockets.insert( s );
  }
#else
  Sockets::iterator i;
  Sockets sockets = m_writeSockets;
  for ( i = sockets.begin(); i != sockets.end(); ++i )
  {
    int s = *i;
    if ( !FD_ISSET( *i, &writeSet ) )
      continue;
    strategy.onConnect( *this, s );
    m_writeSockets.erase( s );
    m_readSockets.insert( s );
  }
#endif

  QF_STACK_POP
}

void SocketMonitor::buildSet( const Sockets& sockets, fd_set& watchSet )
{ QF_STACK_PUSH(SocketMonitor::buildSet)

  FD_ZERO( &watchSet );
  Sockets::const_iterator iter;
  for ( iter = sockets.begin(); iter != sockets.end(); ++iter ) {
    FD_SET( *iter, &watchSet );
  }

  QF_STACK_POP
}
}
