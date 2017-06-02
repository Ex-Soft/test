using DevExpress.Xpo;

namespace TestInheritance.Db
{
	[Persistent("TestDEReference")]
	public class Reference : XPBaseObject
	{
		int _id;
        string _value;

        public Reference(Session session) : base(session)
        {}

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

		[Association("Reference-ForTestInheritanceILeftRightLeft", typeof(ForTestInheritanceILeftRight))]
		public XPCollection ForTestInheritanceILeftRightLeft
		{
			get { return GetCollection("ForTestInheritanceILeftRightLeft"); }
		}

		[Association("Reference-ForTestInheritanceILeftRightRight", typeof(ForTestInheritanceILeftRight))]
		public XPCollection ForTestInheritanceILeftRightRight
		{
			get { return GetCollection("ForTestInheritanceILeftRightRight"); }
		}

		[Association("Reference-ForTestInheritanceIRightLeftLeft", typeof(ForTestInheritanceIRightLeft))]
		public XPCollection ForTestInheritanceIRightLeftLeft
		{
			get { return GetCollection("ForTestInheritanceIRightLeftLeft"); }
		}

		[Association("Reference-ForTestInheritanceIRightLeftRight", typeof(ForTestInheritanceIRightLeft))]
		public XPCollection ForTestInheritanceIRightLeftRight
		{
			get { return GetCollection("ForTestInheritanceIRightLeftRight"); }
		}

		[Association("Reference-ForTestInheritanceIILeft", typeof(ForTestInheritanceII))]
		public XPCollection ForTestInheritanceIILeft
		{
			get { return GetCollection("ForTestInheritanceIILeft"); }
		}

		[Association("Reference-ForTestInheritanceIIRight", typeof(ForTestInheritanceII))]
		public XPCollection ForTestInheritanceIIRight
		{
			get { return GetCollection("ForTestInheritanceIIRight"); }
		}

		//[Association("Reference-ForTestInheritanceIIBackwardLeft", typeof(ForTestInheritanceIIBackward))]
		//public XPCollection ForTestInheritanceIIBackwardLeft
		//{
		//	get { return GetCollection("ForTestInheritanceIIBackwardLeft"); }
		//}

		//[Association("Reference-ForTestInheritanceIIBackwardRight", typeof(ForTestInheritanceIIBackward))]
		//public XPCollection ForTestInheritanceIIBackwardRight
		//{
		//	get { return GetCollection("ForTestInheritanceIIBackwardRight"); }
		//}
	}
}
