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

#ifndef FIX_INITIATOR_H
#define FIX_INITIATOR_H

#ifdef _MSC_VER
#pragma warning( disable : 4503 4355 4786 4290 )
#endif

#include "Application.h"
#include "MessageStore.h"
#include "Log.h"
#include "Responder.h"
#include "SessionSettings.h"
#include "Exceptions.h"
#include "Mutex.h"
#include <set>
#include <map>
#include <string>

namespace FIX
{
class Client;

/*! \addtogroup user
 *  @{
 */ 
/**
 * Base for classes which act as an initiator for establishing connections.
 *
 * Most users will not need to implement one of these.  The default
 * SocketInitiator implementation will be used in most cases.
 */
class Initiator
{
public:
  Initiator( Application&, MessageStoreFactory&,
             const SessionSettings& ) throw( ConfigError& );
  Initiator( Application&, MessageStoreFactory&,
             const SessionSettings&, LogFactory& ) throw( ConfigError& );

  virtual ~Initiator();

  /// Start initiator.
  void start() throw ( ConfigError&, RuntimeError& );
  /// Block on the initiator
  void block() throw ( ConfigError&, RuntimeError& );
  /// Poll the initiator
  bool poll() throw ( ConfigError&, RuntimeError& );

  /// Stop initiator.
  void stop();

  /// Check to see if any sessions are currently logged on
  bool isLoggedOn();

  Session* getSession( const SessionID& sessionID, Responder& );

public:
  Application& getApplication() { return m_application; }
  MessageStoreFactory& getMessageStoreFactory()
  { return m_messageStoreFactory; }

protected:
  void setConnected( const SessionID&, bool );
  bool isConnected( const SessionID& );
  void connect();

private:
  void initialize() throw ( ConfigError& );

  /// Implemented to configure acceptor
  virtual void onConfigure( const SessionSettings& ) throw ( ConfigError& ) {};
  /// Implemented to initialize initiator
  virtual void onInitialize( const SessionSettings& ) throw ( RuntimeError& ) {};
  /// Implemented to start connecting to targets.
  virtual void onStart() = 0;
  /// Implemented to connect and poll for events.
  virtual bool onPoll() = 0;
  /// Implemented to stop a running initiator.
  virtual void onStop() = 0;
  /// Implemented to connect a session to its target.
  virtual bool doConnect( const SessionID&, const Dictionary& ) = 0;

  static THREAD_PROC startThread( void* p );

  typedef std::set < SessionID > SessionIDs;
  typedef std::map < SessionID, int > SessionState;
  typedef std::map < SessionID, Session* > Sessions;

  Sessions m_sessions;
  SessionIDs m_connected;
  SessionIDs m_disconnected;
  SessionState m_sessionState;

  unsigned m_threadid;
  Application& m_application;
  MessageStoreFactory& m_messageStoreFactory;
  SessionSettings m_settings;
  LogFactory* m_pLogFactory;
  bool m_firstPoll;
};
/*! @} */
}

#endif // FIX_INITIATOR_H
