/****************************************************************************
** Copyright (c) 2001-2005 quickfixengine.org  All rights reserved.
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

#include "ThreadedSocketConnection.h"
#include "ThreadedSocketAcceptor.h"
#include "ThreadedSocketInitiator.h"
#include "Session.h"
#include "Utility.h"

namespace FIX
{
ThreadedSocketConnection::ThreadedSocketConnection( int s, Application& application )
: m_socket( s ), m_application( application ),
  m_pSession( 0 )
{
    FD_ZERO (&m_fds);
    FD_SET (m_socket, &m_fds);
}

ThreadedSocketConnection::ThreadedSocketConnection( const SessionID& sessionID, int s,
    Application& application )

: m_socket( s ), m_application( application ),
  m_pSession( Session::lookupSession( sessionID ) )
{
  FD_ZERO (&m_fds);
  FD_SET (m_socket, &m_fds);
  if ( m_pSession ) m_pSession->setResponder( this );
}

ThreadedSocketConnection::~ThreadedSocketConnection()
{
  if ( m_pSession )
  {
    m_pSession->setResponder( 0 );
    Session::unregisterSession( m_pSession->getSessionID() );
  }
}

bool ThreadedSocketConnection::send( const std::string& msg )
{ QF_STACK_PUSH(ThreadedSocketConnection::send)
  return socket_send( m_socket, msg.c_str(), msg.length() );
  QF_STACK_POP
}

void ThreadedSocketConnection::disconnect()
{ QF_STACK_PUSH(ThreadedSocketConnection::disconnect)
  socket_close( m_socket );
  QF_STACK_POP
}

bool ThreadedSocketConnection::read()
{ QF_STACK_PUSH(ThreadedSocketConnection::read)

  char buffer[BUFSIZ];
  struct timeval timeout = { 1, 0 };
  fd_set read_set = m_fds;

  try
  {
    // Wait for input (1 second timeout)
    int result = select (1 + m_socket, &read_set, 0, 0, &timeout);

    if (result < 0)             // Error
    {
      throw SocketRecvFailed (result);
    }
    else if (result > 0)        // Something to read
    {
      // We can read without blocking
      result = recv( m_socket, buffer, sizeof(buffer), 0 );
      if ( result <= 0 ) { throw SocketRecvFailed( result ); }
      m_parser.addToStream( buffer, result );
    }

    // Read or timed out.  processStream calls Session::next
    processStream();
    return true;
  }
  catch ( SocketRecvFailed& e )
  {
    if( m_pSession )
    {
      m_pSession->getLog()->onEvent( e.what() );
      m_pSession->disconnect();
    }
    else
    {
      disconnect();
    }

    return false;
  }
  catch ( InvalidMessage& )
  {
    if( !m_pSession->isLoggedOn() )
      disconnect();
  }

  QF_STACK_POP
}

bool ThreadedSocketConnection::readMessage( std::string& msg )
throw( SocketRecvFailed )
{ QF_STACK_PUSH(ThreadedSocketConnection::readMessage)

  try
  {
    return m_parser.readFixMessage( msg );
  }
  catch ( MessageParseError& ) {}
  return true;

  QF_STACK_POP
}

void ThreadedSocketConnection::processStream()
{ QF_STACK_PUSH(ThreadedSocketConnection::processStream)

  std::string msg;
  try
  {
    while ( readMessage( msg ) )
    {
      if ( !m_pSession )
      {
        if ( !setSession( msg ) )
        { disconnect(); continue; }
      }
      m_pSession->next( msg );
    }
  }
  catch( SocketRecvFailed& e )
  {
    if( m_pSession )
      m_pSession->getLog()->onEvent( e.what() );
    disconnect();
  }

  QF_STACK_POP
}

bool ThreadedSocketConnection::setSession( const std::string& msg )
{ QF_STACK_PUSH(ThreadedSocketConnection::setSession)

  m_pSession = Session::lookupSession( msg, true );
  if ( !m_pSession ) return false;
  SessionID sessionID = m_pSession->getSessionID();
  // see if the session frees up within 5 seconds
  for ( int i = 1; i <= 5; ++i )
  {
    m_pSession = Session::registerSession( sessionID );
    if ( m_pSession ) break;
    process_sleep( 1 );
  }
  if ( !m_pSession ) return false;
  m_pSession->setResponder( this );
  return true;

  QF_STACK_POP
}

} // namespace FIX
