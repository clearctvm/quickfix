package org.quickfix.field; 
import org.quickfix.IntField; 
import java.util.Date; 

public class NoHops extends IntField 
{ 

  public NoHops() 
  { 
    super(627);
  } 
  public NoHops(int data) 
  { 
    super(627, data);
  } 
} 
