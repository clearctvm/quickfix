namespace QuickFix41
{

  public class IndicationofInterest : Message
  {
    public IndicationofInterest() : base(MsgType()) {}
    static QuickFix.MsgType MsgType() { return new QuickFix.MsgType("6"); }

    public IndicationofInterest(
      QuickFix.IOIid aIOIid,
      QuickFix.IOITransType aIOITransType,
      QuickFix.Symbol aSymbol,
      QuickFix.Side aSide,
      QuickFix.IOIShares aIOIShares )
    : base(MsgType()) {
      set(aIOIid);
      set(aIOITransType);
      set(aSymbol);
      set(aSide);
      set(aIOIShares);
    }

    public void set(QuickFix.IOIid value)
    { setField(value); }
    public QuickFix.IOIid get(QuickFix.IOIid  value)
    { getField(value); return value; }
    public QuickFix.IOIid getIOIid()
    { QuickFix.IOIid value = new QuickFix.IOIid();
      getField(value); return value; }
    public bool isSet(QuickFix.IOIid field)
    { return isSetField(field); }
    public bool isSetIOIid()
    { return isSetField(23); }

    public void set(QuickFix.IOITransType value)
    { setField(value); }
    public QuickFix.IOITransType get(QuickFix.IOITransType  value)
    { getField(value); return value; }
    public QuickFix.IOITransType getIOITransType()
    { QuickFix.IOITransType value = new QuickFix.IOITransType();
      getField(value); return value; }
    public bool isSet(QuickFix.IOITransType field)
    { return isSetField(field); }
    public bool isSetIOITransType()
    { return isSetField(28); }

    public void set(QuickFix.IOIRefID value)
    { setField(value); }
    public QuickFix.IOIRefID get(QuickFix.IOIRefID  value)
    { getField(value); return value; }
    public QuickFix.IOIRefID getIOIRefID()
    { QuickFix.IOIRefID value = new QuickFix.IOIRefID();
      getField(value); return value; }
    public bool isSet(QuickFix.IOIRefID field)
    { return isSetField(field); }
    public bool isSetIOIRefID()
    { return isSetField(26); }

    public void set(QuickFix.Symbol value)
    { setField(value); }
    public QuickFix.Symbol get(QuickFix.Symbol  value)
    { getField(value); return value; }
    public QuickFix.Symbol getSymbol()
    { QuickFix.Symbol value = new QuickFix.Symbol();
      getField(value); return value; }
    public bool isSet(QuickFix.Symbol field)
    { return isSetField(field); }
    public bool isSetSymbol()
    { return isSetField(55); }

    public void set(QuickFix.SymbolSfx value)
    { setField(value); }
    public QuickFix.SymbolSfx get(QuickFix.SymbolSfx  value)
    { getField(value); return value; }
    public QuickFix.SymbolSfx getSymbolSfx()
    { QuickFix.SymbolSfx value = new QuickFix.SymbolSfx();
      getField(value); return value; }
    public bool isSet(QuickFix.SymbolSfx field)
    { return isSetField(field); }
    public bool isSetSymbolSfx()
    { return isSetField(65); }

    public void set(QuickFix.SecurityID value)
    { setField(value); }
    public QuickFix.SecurityID get(QuickFix.SecurityID  value)
    { getField(value); return value; }
    public QuickFix.SecurityID getSecurityID()
    { QuickFix.SecurityID value = new QuickFix.SecurityID();
      getField(value); return value; }
    public bool isSet(QuickFix.SecurityID field)
    { return isSetField(field); }
    public bool isSetSecurityID()
    { return isSetField(48); }

    public void set(QuickFix.IDSource value)
    { setField(value); }
    public QuickFix.IDSource get(QuickFix.IDSource  value)
    { getField(value); return value; }
    public QuickFix.IDSource getIDSource()
    { QuickFix.IDSource value = new QuickFix.IDSource();
      getField(value); return value; }
    public bool isSet(QuickFix.IDSource field)
    { return isSetField(field); }
    public bool isSetIDSource()
    { return isSetField(22); }

    public void set(QuickFix.SecurityType value)
    { setField(value); }
    public QuickFix.SecurityType get(QuickFix.SecurityType  value)
    { getField(value); return value; }
    public QuickFix.SecurityType getSecurityType()
    { QuickFix.SecurityType value = new QuickFix.SecurityType();
      getField(value); return value; }
    public bool isSet(QuickFix.SecurityType field)
    { return isSetField(field); }
    public bool isSetSecurityType()
    { return isSetField(167); }

    public void set(QuickFix.MaturityMonthYear value)
    { setField(value); }
    public QuickFix.MaturityMonthYear get(QuickFix.MaturityMonthYear  value)
    { getField(value); return value; }
    public QuickFix.MaturityMonthYear getMaturityMonthYear()
    { QuickFix.MaturityMonthYear value = new QuickFix.MaturityMonthYear();
      getField(value); return value; }
    public bool isSet(QuickFix.MaturityMonthYear field)
    { return isSetField(field); }
    public bool isSetMaturityMonthYear()
    { return isSetField(200); }

    public void set(QuickFix.MaturityDay value)
    { setField(value); }
    public QuickFix.MaturityDay get(QuickFix.MaturityDay  value)
    { getField(value); return value; }
    public QuickFix.MaturityDay getMaturityDay()
    { QuickFix.MaturityDay value = new QuickFix.MaturityDay();
      getField(value); return value; }
    public bool isSet(QuickFix.MaturityDay field)
    { return isSetField(field); }
    public bool isSetMaturityDay()
    { return isSetField(205); }

    public void set(QuickFix.PutOrCall value)
    { setField(value); }
    public QuickFix.PutOrCall get(QuickFix.PutOrCall  value)
    { getField(value); return value; }
    public QuickFix.PutOrCall getPutOrCall()
    { QuickFix.PutOrCall value = new QuickFix.PutOrCall();
      getField(value); return value; }
    public bool isSet(QuickFix.PutOrCall field)
    { return isSetField(field); }
    public bool isSetPutOrCall()
    { return isSetField(201); }

    public void set(QuickFix.StrikePrice value)
    { setField(value); }
    public QuickFix.StrikePrice get(QuickFix.StrikePrice  value)
    { getField(value); return value; }
    public QuickFix.StrikePrice getStrikePrice()
    { QuickFix.StrikePrice value = new QuickFix.StrikePrice();
      getField(value); return value; }
    public bool isSet(QuickFix.StrikePrice field)
    { return isSetField(field); }
    public bool isSetStrikePrice()
    { return isSetField(202); }

    public void set(QuickFix.OptAttribute value)
    { setField(value); }
    public QuickFix.OptAttribute get(QuickFix.OptAttribute  value)
    { getField(value); return value; }
    public QuickFix.OptAttribute getOptAttribute()
    { QuickFix.OptAttribute value = new QuickFix.OptAttribute();
      getField(value); return value; }
    public bool isSet(QuickFix.OptAttribute field)
    { return isSetField(field); }
    public bool isSetOptAttribute()
    { return isSetField(206); }

    public void set(QuickFix.SecurityExchange value)
    { setField(value); }
    public QuickFix.SecurityExchange get(QuickFix.SecurityExchange  value)
    { getField(value); return value; }
    public QuickFix.SecurityExchange getSecurityExchange()
    { QuickFix.SecurityExchange value = new QuickFix.SecurityExchange();
      getField(value); return value; }
    public bool isSet(QuickFix.SecurityExchange field)
    { return isSetField(field); }
    public bool isSetSecurityExchange()
    { return isSetField(207); }

    public void set(QuickFix.Issuer value)
    { setField(value); }
    public QuickFix.Issuer get(QuickFix.Issuer  value)
    { getField(value); return value; }
    public QuickFix.Issuer getIssuer()
    { QuickFix.Issuer value = new QuickFix.Issuer();
      getField(value); return value; }
    public bool isSet(QuickFix.Issuer field)
    { return isSetField(field); }
    public bool isSetIssuer()
    { return isSetField(106); }

    public void set(QuickFix.SecurityDesc value)
    { setField(value); }
    public QuickFix.SecurityDesc get(QuickFix.SecurityDesc  value)
    { getField(value); return value; }
    public QuickFix.SecurityDesc getSecurityDesc()
    { QuickFix.SecurityDesc value = new QuickFix.SecurityDesc();
      getField(value); return value; }
    public bool isSet(QuickFix.SecurityDesc field)
    { return isSetField(field); }
    public bool isSetSecurityDesc()
    { return isSetField(107); }

    public void set(QuickFix.Side value)
    { setField(value); }
    public QuickFix.Side get(QuickFix.Side  value)
    { getField(value); return value; }
    public QuickFix.Side getSide()
    { QuickFix.Side value = new QuickFix.Side();
      getField(value); return value; }
    public bool isSet(QuickFix.Side field)
    { return isSetField(field); }
    public bool isSetSide()
    { return isSetField(54); }

    public void set(QuickFix.IOIShares value)
    { setField(value); }
    public QuickFix.IOIShares get(QuickFix.IOIShares  value)
    { getField(value); return value; }
    public QuickFix.IOIShares getIOIShares()
    { QuickFix.IOIShares value = new QuickFix.IOIShares();
      getField(value); return value; }
    public bool isSet(QuickFix.IOIShares field)
    { return isSetField(field); }
    public bool isSetIOIShares()
    { return isSetField(27); }

    public void set(QuickFix.Price value)
    { setField(value); }
    public QuickFix.Price get(QuickFix.Price  value)
    { getField(value); return value; }
    public QuickFix.Price getPrice()
    { QuickFix.Price value = new QuickFix.Price();
      getField(value); return value; }
    public bool isSet(QuickFix.Price field)
    { return isSetField(field); }
    public bool isSetPrice()
    { return isSetField(44); }

    public void set(QuickFix.Currency value)
    { setField(value); }
    public QuickFix.Currency get(QuickFix.Currency  value)
    { getField(value); return value; }
    public QuickFix.Currency getCurrency()
    { QuickFix.Currency value = new QuickFix.Currency();
      getField(value); return value; }
    public bool isSet(QuickFix.Currency field)
    { return isSetField(field); }
    public bool isSetCurrency()
    { return isSetField(15); }

    public void set(QuickFix.ValidUntilTime value)
    { setField(value); }
    public QuickFix.ValidUntilTime get(QuickFix.ValidUntilTime  value)
    { getField(value); return value; }
    public QuickFix.ValidUntilTime getValidUntilTime()
    { QuickFix.ValidUntilTime value = new QuickFix.ValidUntilTime();
      getField(value); return value; }
    public bool isSet(QuickFix.ValidUntilTime field)
    { return isSetField(field); }
    public bool isSetValidUntilTime()
    { return isSetField(62); }

    public void set(QuickFix.IOIQltyInd value)
    { setField(value); }
    public QuickFix.IOIQltyInd get(QuickFix.IOIQltyInd  value)
    { getField(value); return value; }
    public QuickFix.IOIQltyInd getIOIQltyInd()
    { QuickFix.IOIQltyInd value = new QuickFix.IOIQltyInd();
      getField(value); return value; }
    public bool isSet(QuickFix.IOIQltyInd field)
    { return isSetField(field); }
    public bool isSetIOIQltyInd()
    { return isSetField(25); }

    public void set(QuickFix.IOIOthSvc value)
    { setField(value); }
    public QuickFix.IOIOthSvc get(QuickFix.IOIOthSvc  value)
    { getField(value); return value; }
    public QuickFix.IOIOthSvc getIOIOthSvc()
    { QuickFix.IOIOthSvc value = new QuickFix.IOIOthSvc();
      getField(value); return value; }
    public bool isSet(QuickFix.IOIOthSvc field)
    { return isSetField(field); }
    public bool isSetIOIOthSvc()
    { return isSetField(24); }

    public void set(QuickFix.IOINaturalFlag value)
    { setField(value); }
    public QuickFix.IOINaturalFlag get(QuickFix.IOINaturalFlag  value)
    { getField(value); return value; }
    public QuickFix.IOINaturalFlag getIOINaturalFlag()
    { QuickFix.IOINaturalFlag value = new QuickFix.IOINaturalFlag();
      getField(value); return value; }
    public bool isSet(QuickFix.IOINaturalFlag field)
    { return isSetField(field); }
    public bool isSetIOINaturalFlag()
    { return isSetField(130); }

    public void set(QuickFix.Text value)
    { setField(value); }
    public QuickFix.Text get(QuickFix.Text  value)
    { getField(value); return value; }
    public QuickFix.Text getText()
    { QuickFix.Text value = new QuickFix.Text();
      getField(value); return value; }
    public bool isSet(QuickFix.Text field)
    { return isSetField(field); }
    public bool isSetText()
    { return isSetField(58); }

    public void set(QuickFix.TransactTime value)
    { setField(value); }
    public QuickFix.TransactTime get(QuickFix.TransactTime  value)
    { getField(value); return value; }
    public QuickFix.TransactTime getTransactTime()
    { QuickFix.TransactTime value = new QuickFix.TransactTime();
      getField(value); return value; }
    public bool isSet(QuickFix.TransactTime field)
    { return isSetField(field); }
    public bool isSetTransactTime()
    { return isSetField(60); }

    public void set(QuickFix.URLLink value)
    { setField(value); }
    public QuickFix.URLLink get(QuickFix.URLLink  value)
    { getField(value); return value; }
    public QuickFix.URLLink getURLLink()
    { QuickFix.URLLink value = new QuickFix.URLLink();
      getField(value); return value; }
    public bool isSet(QuickFix.URLLink field)
    { return isSetField(field); }
    public bool isSetURLLink()
    { return isSetField(149); }

    public void set(QuickFix.NoIOIQualifiers value)
    { setField(value); }
    public QuickFix.NoIOIQualifiers get(QuickFix.NoIOIQualifiers  value)
    { getField(value); return value; }
    public QuickFix.NoIOIQualifiers getNoIOIQualifiers()
    { QuickFix.NoIOIQualifiers value = new QuickFix.NoIOIQualifiers();
      getField(value); return value; }
    public bool isSet(QuickFix.NoIOIQualifiers field)
    { return isSetField(field); }
    public bool isSetNoIOIQualifiers()
    { return isSetField(199); }

    class NoIOIQualifiers: QuickFix.Group
    {
    public NoIOIQualifiers() : base(199,104,message_order ) {}
    static int[] message_order = new int[] {104,0};
      public void set(QuickFix.IOIQualifier value)
      { setField(value); }
      public QuickFix.IOIQualifier get(QuickFix.IOIQualifier  value)
      { getField(value); return value; }
      public QuickFix.IOIQualifier getIOIQualifier()
      { QuickFix.IOIQualifier value = new QuickFix.IOIQualifier();
        getField(value); return value; }
      public bool isSet(QuickFix.IOIQualifier field)
      { return isSetField(field); }
      public bool isSetIOIQualifier()
      { return isSetField(104); }

    };
  };

}

