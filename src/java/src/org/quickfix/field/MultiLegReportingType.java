package org.quickfix.field; 
import org.quickfix.CharField; 
import java.util.Date; 

public class MultiLegReportingType extends CharField 
{ 
  public static final int FIELD = 442; 
public static final char SINGLE = '1'; 
public static final char INDIV_LEG = '2'; 
public static final char MULTI_LEG = '3'; 

  public MultiLegReportingType() 
  { 
    super(442);
  } 
  public MultiLegReportingType(char data) 
  { 
    super(442, data);
  } 
} 
