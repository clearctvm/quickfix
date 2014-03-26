namespace QuickFix44
{
	public class PostTradingRequest : Message
	{
        public PostTradingRequest() : this(MsgType()) { }
        public PostTradingRequest(QuickFix.MsgType type) : base(type) { }

        static QuickFix.MsgType MsgType() { return new QuickFix.MsgType("UPRQ"); }

		public void set(QuickFix.ClOrdID value)
        { setField(value); }
        public QuickFix.ClOrdID get(QuickFix.ClOrdID  value)
        { getField(value); return value; }
        public QuickFix.ClOrdID getClOrdID()
        { QuickFix.ClOrdID value = new QuickFix.ClOrdID();
          getField(value); return value; }
        public bool isSet(QuickFix.ClOrdID field)
        { return isSetField(field); }
        public bool isSetClOrdID()
        { return isSetField(11); }

         public void set(QuickFix.NoPartyIDs value)
        { setField(value); }
        public QuickFix.NoPartyIDs get(QuickFix.NoPartyIDs  value)
        { getField(value); return value; }
        public QuickFix.NoPartyIDs getNoPartyIDs()
        { QuickFix.NoPartyIDs value = new QuickFix.NoPartyIDs();
          getField(value); return value; }
        public bool isSet(QuickFix.NoPartyIDs field)
        { return isSetField(field); }
        public bool isSetNoPartyIDs()
        { return isSetField(453); }

        public class NoPartyIDs: QuickFix.Group
        {
            public NoPartyIDs() : base(453,448,message_order ) {}
            static int[] message_order = new int[] {447,448,452,802,0};
              public void set(QuickFix.PartyID value)
              { setField(value); }
              public QuickFix.PartyID get(QuickFix.PartyID  value)
              { getField(value); return value; }
              public QuickFix.PartyID getPartyID()
              { QuickFix.PartyID value = new QuickFix.PartyID();
                getField(value); return value; }
              public bool isSet(QuickFix.PartyID field)
              { return isSetField(field); }
              public bool isSetPartyID()
              { return isSetField(448); }

              public void set(QuickFix.PartyIDSource value)
              { setField(value); }
              public QuickFix.PartyIDSource get(QuickFix.PartyIDSource  value)
              { getField(value); return value; }
              public QuickFix.PartyIDSource getPartyIDSource()
              { QuickFix.PartyIDSource value = new QuickFix.PartyIDSource();
                getField(value); return value; }
              public bool isSet(QuickFix.PartyIDSource field)
              { return isSetField(field); }
              public bool isSetPartyIDSource()
              { return isSetField(447); }

              public void set(QuickFix.PartyRole value)
              { setField(value); }
              public QuickFix.PartyRole get(QuickFix.PartyRole  value)
              { getField(value); return value; }
              public QuickFix.PartyRole getPartyRole()
              { QuickFix.PartyRole value = new QuickFix.PartyRole();
                getField(value); return value; }
              public bool isSet(QuickFix.PartyRole field)
              { return isSetField(field); }
              public bool isSetPartyRole()
              { return isSetField(452); }

              public void set(QuickFix.NoPartySubIDs value)
              { setField(value); }
              public QuickFix.NoPartySubIDs get(QuickFix.NoPartySubIDs  value)
              { getField(value); return value; }
              public QuickFix.NoPartySubIDs getNoPartySubIDs()
              { QuickFix.NoPartySubIDs value = new QuickFix.NoPartySubIDs();
                getField(value); return value; }
              public bool isSet(QuickFix.NoPartySubIDs field)
              { return isSetField(field); }
              public bool isSetNoPartySubIDs()
              { return isSetField(802); }

              public class NoPartySubIDs: QuickFix.Group
              {
              public NoPartySubIDs() : base(802,523,message_order ) {}
              static int[] message_order = new int[] {523,803,0};
                public void set(QuickFix.PartySubID value)
                { setField(value); }
                public QuickFix.PartySubID get(QuickFix.PartySubID  value)
                { getField(value); return value; }
                public QuickFix.PartySubID getPartySubID()
                { QuickFix.PartySubID value = new QuickFix.PartySubID();
                  getField(value); return value; }
                public bool isSet(QuickFix.PartySubID field)
                { return isSetField(field); }
                public bool isSetPartySubID()
                { return isSetField(523); }

                public void set(QuickFix.PartySubIDType value)
                { setField(value); }
                public QuickFix.PartySubIDType get(QuickFix.PartySubIDType  value)
                { getField(value); return value; }
                public QuickFix.PartySubIDType getPartySubIDType()
                { QuickFix.PartySubIDType value = new QuickFix.PartySubIDType();
                  getField(value); return value; }
                public bool isSet(QuickFix.PartySubIDType field)
                { return isSetField(field); }
                public bool isSetPartySubIDType()
                { return isSetField(803); }

              };
            };

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

            public void set(QuickFix.MessageID value)
            { setField(value); }
            public QuickFix.MessageID get(QuickFix.MessageID value)
            { getField(value); return value; }
            public QuickFix.MessageID getMessageID()
            {
                QuickFix.MessageID value = new QuickFix.MessageID();
                getField(value); return value;
            }
            public bool isSet(QuickFix.MessageID field)
            { return isSetField(field); }
            public bool isSetMessageID()
            { return isSetField(QuickFix.MessageID.FIELD); }

            public void set(QuickFix.XMLContent value)
            { setField(value); }
            public QuickFix.XMLContent get(QuickFix.XMLContent value)
            { getField(value); return value; }
            public QuickFix.XMLContent getXMLContent()
            {
                QuickFix.XMLContent value = new QuickFix.XMLContent();
                getField(value); return value;
            }
            public bool isSet(QuickFix.XMLContent field)
            { return isSetField(field); }
            public bool isSetXMLContent()
            { return isSetField(QuickFix.XMLContent.FIELD); }

            public void set(QuickFix.XMLContentLen value)
            { setField(value); }
            public QuickFix.XMLContentLen get(QuickFix.XMLContentLen value)
            { getField(value); return value; }
            public QuickFix.XMLContentLen getXMLContentLen()
            {
                QuickFix.XMLContentLen value = new QuickFix.XMLContentLen();
                getField(value); return value;
            }
            public bool isSet(QuickFix.XMLContentLen field)
            { return isSetField(field); }
            public bool isSetXMLContentLen()
            { return isSetField(QuickFix.XMLContentLen.FIELD); }
	}
}