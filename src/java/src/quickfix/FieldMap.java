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

package quickfix;

import java.util.Date;
import java.util.Iterator;

public abstract class FieldMap {

    public abstract void setString(int field, String value) throws NoTagValue;
    public abstract void setBoolean(int field, boolean value) throws NoTagValue;
    public abstract void setChar(int field, char value) throws NoTagValue;
    public abstract void setInt(int field, int value) throws NoTagValue;
    public abstract void setDouble(int field, double value) throws NoTagValue;
    public abstract void setUtcTimeStamp(int field, Date value) throws NoTagValue;
    public abstract void setUtcTimeOnly(int field, Date value) throws NoTagValue;
    public abstract void setUtcDateOnly(int field, Date value) throws NoTagValue;
    public abstract String getString(int field) throws FieldNotFound;
    public abstract boolean getBoolean(int field) throws FieldNotFound;
    public abstract char getChar(int field) throws FieldNotFound;
    public abstract int getInt(int field) throws FieldNotFound;
    public abstract double getDouble(int field) throws FieldNotFound;
    public abstract Date getUtcTimeStamp(int field) throws FieldNotFound;
    public abstract Date getUtcTimeOnly(int field) throws FieldNotFound;
    public abstract Date getUtcDateOnly(int field) throws FieldNotFound;
    public abstract void setField(StringField field) throws NoTagValue;
    public abstract void setField(BooleanField field) throws NoTagValue;
    public abstract void setField(CharField field) throws NoTagValue;
    public abstract void setField(IntField field) throws NoTagValue;
    public abstract void setField(DoubleField field) throws NoTagValue;
    public abstract void setField(UtcTimeStampField field) throws NoTagValue;
    public abstract void setField(UtcTimeOnlyField field) throws NoTagValue;
    public abstract void setField(UtcDateOnlyField field) throws NoTagValue;
    public abstract StringField getField(StringField field) throws FieldNotFound;
    public abstract BooleanField getField(BooleanField field) throws FieldNotFound;
    public abstract CharField getField(CharField field) throws FieldNotFound;
    public abstract IntField getField(IntField field) throws FieldNotFound;
    public abstract DoubleField getField(DoubleField field) throws FieldNotFound;
    public abstract UtcTimeStampField getField(UtcTimeStampField field) throws FieldNotFound;
    public abstract UtcTimeOnlyField getField(UtcTimeOnlyField field) throws FieldNotFound;
    public abstract UtcDateOnlyField getField(UtcDateOnlyField field) throws FieldNotFound;
    public abstract boolean isSetField(int field);
    public abstract boolean isSetField(Field field);
    public abstract void removeField(int field);
    public abstract void addGroup(Group group);
	public abstract Group getGroup(int num, Group group) throws FieldNotFound;
	public abstract void removeGroup(int field);
	public abstract void removeGroup(int num, int field);
	public abstract void removeGroup(int num, Group group);
	public abstract void removeGroup(Group group);
	public abstract void hasGroup(int field);
	public abstract void hasGroup(int num, int field);
	public abstract void hasGroup(int num, Group group);
	public abstract void hasGroup(Group group);
    public abstract Iterator iterator();
}
