using DevExpress.Xpo;

namespace TestInheritance.Db
{
	[Persistent("TestDEForTestInheritanceI")]
	public class ForTestInheritanceI : XPBaseObject
	{
		int _id;
        string _value;

		public ForTestInheritanceI(Session session) : base(session)
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
	}

	[MapInheritance(MapInheritanceType.ParentTable)]
	public class ForTestInheritanceILeftRight : ForTestInheritanceI
	{
		Reference
			_left,
			_right;

		public ForTestInheritanceILeftRight(Session session) : base(session)
		{}

		[Persistent("LeftId")]
		[Association("Reference-ForTestInheritanceILeftRightLeft", typeof(Reference))]
		public Reference Left
		{
			get { return _left; }
			set { SetPropertyValue("Left", ref _left, value); }
		}

		[Persistent("RightId")]
		[Association("Reference-ForTestInheritanceILeftRightRight", typeof(Reference))]
		public Reference Right
		{
			get { return _right; }
			set { SetPropertyValue("Right", ref _right, value); }
		}
	}

	[MapInheritance(MapInheritanceType.ParentTable)]
	public class ForTestInheritanceIRightLeft : ForTestInheritanceI
	{
		Reference
			_left,
			_right;

		public ForTestInheritanceIRightLeft(Session session) : base(session)
		{}

		[Persistent("RightId")]
		[Association("Reference-ForTestInheritanceIRightLeftLeft", typeof(Reference))]
		public Reference Left
		{
			get { return _left; }
			set { SetPropertyValue("Left", ref _left, value); }
		}

		[Persistent("LeftId")]
		[Association("Reference-ForTestInheritanceIRightLeftRight", typeof(Reference))]
		public Reference Right
		{
			get { return _right; }
			set { SetPropertyValue("Right", ref _right, value); }
		}
	}
}
