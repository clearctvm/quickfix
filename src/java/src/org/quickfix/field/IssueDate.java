package org.quickfix.field; 
import org.quickfix.UtcDateField; 
import java.util.Date; 

public class IssueDate extends UtcDateField 
{ 
  public static final int FIELD = 225; 

  public IssueDate() 
  { 
    super(225);
  } 
  public IssueDate(Date data) 
  { 
    super(225, data);
  } 
} 
