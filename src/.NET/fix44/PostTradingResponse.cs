namespace QuickFix44
{
	public class PostTradingResponse : PostTradingRequest
    {
        public PostTradingResponse() : base(MsgType()) { }
        static QuickFix.MsgType MsgType() { return new QuickFix.MsgType("UPRP"); }

        public void set(QuickFix.ResponseID value)
        { setField(value); }
        public QuickFix.ResponseID get(QuickFix.ResponseID value)
        { getField(value); return value; }
        public QuickFix.ResponseID getResponseID()
        {
            QuickFix.ResponseID value = new QuickFix.ResponseID();
            getField(value); return value;
        }
        public bool isSet(QuickFix.ResponseID field)
        { return isSetField(field); }
        public bool isSetResponseID()
        { return isSetField(QuickFix.ResponseID.FIELD); }
    }
}