/* -*- C++ -*- */

/****************************************************************************
** Copyright (c) 2001-2004 quickfixengine.org  All rights reserved.
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

#pragma once

using namespace System;

#include "quickfix_net.h"

#include "Application.h"
#include "SessionSettings.h"
#include "MessageStoreFactory.h"
#include "LogFactory.h"
#include "Acceptor.h"
#include "quickfix/ThreadedSocketAcceptor.h"
#include "quickfix/CallStack.h"

namespace QuickFix
{
public __gc class ThreadedSocketAcceptor : public Acceptor
{
public:
  ThreadedSocketAcceptor( Application* application,
                          MessageStoreFactory* factory,
                          SessionSettings* settings,
                          MessageFactory* messageFactory )
  : m_settings( settings ), m_logFactory( 0 )
  { QF_STACK_TRY

    try
    {
      m_application = new ::Application( application, messageFactory );
      m_factory = new ::MessageStoreFactory( factory );
      m_pUnmanaged = new FIX::ThreadedSocketAcceptor
                     ( *m_application, *m_factory, m_settings->unmanaged() );
    }
    catch ( FIX::ConfigError e ) { throw new ConfigError( e.what() ); }

    QF_STACK_CATCH
  }

  ThreadedSocketAcceptor( Application* application,
                          MessageStoreFactory* factory,
                          SessionSettings* settings,
                          LogFactory* logFactory,
                          MessageFactory* messageFactory )
  : m_settings( settings )
  { QF_STACK_TRY

    try
    {
      m_application = new ::Application( application, messageFactory );
      m_factory = new ::MessageStoreFactory( factory );
      m_logFactory = new ::LogFactory( logFactory );
      m_pUnmanaged = new FIX::ThreadedSocketAcceptor
                     ( *m_application, *m_factory,
                       m_settings->unmanaged(), *m_logFactory );
    }
    catch ( FIX::ConfigError e ) { throw new ConfigError( e.what() ); }

    QF_STACK_CATCH
  }

  ~ThreadedSocketAcceptor()
  {
    delete m_pUnmanaged;
    delete m_application;
    delete m_factory;
    delete m_logFactory;
  }

  void start() throw ( ConfigError*, RuntimeError* ) 
  { QF_STACK_TRY

    try
    {
      m_pUnmanaged->start(); 
    }
    catch( FIX::ConfigError& e )
    {
      throw new ConfigError( e.what() );
    }
    catch( FIX::RuntimeError& e )
    {
      throw new RuntimeError( e.what() );
    }

    QF_STACK_CATCH
  }

  void block() throw ( ConfigError*, RuntimeError* ) 
  { QF_STACK_TRY

    try
    {
      m_pUnmanaged->block(); 
    }
    catch( FIX::ConfigError& e )
    {
      throw new ConfigError( e.what() );
    }
    catch( FIX::RuntimeError& e )
    {
      throw new RuntimeError( e.what() );
    }

    QF_STACK_CATCH
  }

  bool poll() throw ( ConfigError*, RuntimeError* ) 
  { QF_STACK_TRY

    try
    {
      return m_pUnmanaged->poll(); 
    }
    catch( FIX::ConfigError& e )
    {
      throw new ConfigError( e.what() );
    }
    catch( FIX::RuntimeError& e )
    {
      throw new RuntimeError( e.what() );
    }

    QF_STACK_CATCH
  }

  void stop()
  { QF_STACK_TRY
    m_pUnmanaged->stop(); 
    QF_STACK_CATCH
  }

  void stop( bool force )
  { QF_STACK_TRY
    m_pUnmanaged->stop( force ); 
    QF_STACK_CATCH
  }

  bool isLoggedOn()
  { QF_STACK_TRY
    return m_pUnmanaged->isLoggedOn();
    QF_STACK_CATCH
  }

  ArrayList* getSessions()
  { QF_STACK_TRY

    std::set< FIX::SessionID > sessions = m_pUnmanaged->getSessions();
    ArrayList* result = new ArrayList();
    std::set<FIX::SessionID>::iterator i;
    for( i = sessions.begin(); i != sessions.end(); ++i )
    {
      SessionID* sessionID = new SessionID( *i );
      result->Add( sessionID );
    }
    return result;

    QF_STACK_CATCH
  }

private:
  FIX::ThreadedSocketAcceptor* m_pUnmanaged;
  ::Application* m_application;
  ::MessageStoreFactory* m_factory;
  ::LogFactory* m_logFactory;
  SessionSettings* m_settings;
};
}
