/* ====================================================================
 * The QuickFIX Software License, Version 1.0
 *
 * Copyright (c) 2001 ThoughtWorks, Inc.  All rights
 * reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *
 * 3. The end-user documentation included with the redistribution,
 *    if any, must include the following acknowledgment:
 *       "This product includes software developed by
 *        ThoughtWorks, Inc. (http://www.thoughtworks.com/)."
 *    Alternately, this acknowledgment may appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "QuickFIX" and "ThoughtWorks, Inc." must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact quickfix-users@lists.sourceforge.net.
 *
 * 5. Products derived from this software may not be called "QuickFIX",
 *    nor may "QuickFIX" appear in their name, without prior written
 *    permission of ThoughtWorks, Inc.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.  IN NO EVENT SHALL THOUGHTWORKS INC OR
 * ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
 * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
 * OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 * ====================================================================
 */

package quickfix;

public class DefaultMessageFactory implements quickfix.MessageFactory {
    private quickfix.fix40.MessageFactory fix40Factory =
        new quickfix.fix40.MessageFactory();
    private quickfix.fix41.MessageFactory fix41Factory =
        new quickfix.fix41.MessageFactory();
    private quickfix.fix42.MessageFactory fix42Factory =
        new quickfix.fix42.MessageFactory();
    private quickfix.fix43.MessageFactory fix43Factory =
        new quickfix.fix43.MessageFactory();
    private quickfix.fix44.MessageFactory fix44Factory =
    	new quickfix.fix44.MessageFactory();

    public Message create(String beginString, String msgType) {
        if("FIX.4.0".equals(beginString)) {
            return fix40Factory.create(beginString, msgType);
        }
        if("FIX.4.1".equals(beginString)) {
            return fix41Factory.create(beginString, msgType);
        }
        if("FIX.4.2".equals(beginString)) {
            return fix42Factory.create(beginString, msgType);
        }
        if("FIX.4.3".equals(beginString)) {
            return fix43Factory.create(beginString, msgType);
        }
        if("FIX.4.4".equals(beginString)) {
		    return fix44Factory.create(beginString, msgType);
        }
        return new Message();
    }
}
