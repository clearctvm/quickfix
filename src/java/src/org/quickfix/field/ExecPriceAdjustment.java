package org.quickfix.field; 
import org.quickfix.DoubleField; 
import java.util.Date; 

public class ExecPriceAdjustment extends DoubleField 
{ 

  public ExecPriceAdjustment() 
  { 
    super(485);
  } 
  public ExecPriceAdjustment(double data) 
  { 
    super(485, data);
  } 
} 