package org.quickfix.field; 
import org.quickfix.IntField; 
import java.util.Date; 

public class DistribPaymentMethod extends IntField 
{ 
  public static final int FIELD = 477; 

  public DistribPaymentMethod() 
  { 
    super(477);
  } 
  public DistribPaymentMethod(int data) 
  { 
    super(477, data);
  } 
} 
