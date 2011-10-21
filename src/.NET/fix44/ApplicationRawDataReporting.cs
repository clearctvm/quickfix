namespace QuickFix44
{
	public class ApplicationRawDataReporting : Message
	{
		public ApplicationRawDataReporting() : base(MsgType()) {}
		static QuickFix.MsgType MsgType() { return new QuickFix.MsgType("URDR"); }

		public QuickFix.ApplReqID getApplReqID()
		{
			var value = new QuickFix.ApplReqID();
			getField(value); 
			return value;
		}

		public QuickFix.ApplResponseID getApplResponseID()
		{
			var value = new QuickFix.ApplResponseID();
			getField(value); 
			return value;
		}

		public QuickFix.ApplID getApplID()
		{
			var value = new QuickFix.ApplID();
			getField(value); 
			return value;
		}

		public QuickFix.RawDataLength getRawDataLength()
		{
			var value = new QuickFix.RawDataLength();
			getField(value); 
			return value;
		}

		public QuickFix.RawData getRawData()
		{
			var value = new QuickFix.RawData();
			getField(value); 
			return value;
		}

		public QuickFix.TotNumReports getTotNumReports()
		{
			var value = new QuickFix.TotNumReports();
			getField(value); 
			return value;
		}

		public QuickFix.NoApplSeqNums getNoApplSeqNums()
		{
			var value = new QuickFix.NoApplSeqNums();
			getField(value); 
			return value;
		}

		public class NoApplSeqNums : QuickFix.Group
		{
			private static readonly int[] message_order = new [] {1181, 1350, 10055, 95};

			public NoApplSeqNums() : base(10054, 1181, message_order)
			{
			}

			public QuickFix.ApplSeqNum getApplSeqNum()
			{
				var value = new QuickFix.ApplSeqNum();
				getField(value); 
				return value;
			}

			public QuickFix.ApplLastSeqNum getApplLastSeqNum()
			{
				var value = new QuickFix.ApplLastSeqNum();
				getField(value); 
				return value;
			}

			public QuickFix.RawDataOffset getRawDataOffset()
			{
				var value = new QuickFix.RawDataOffset();
				getField(value); 
				return value;
			}

			public QuickFix.RawDataLength getRawDataLength()
			{
				var value = new QuickFix.RawDataLength();
				getField(value); 
				return value;
			}
		}
	}
}