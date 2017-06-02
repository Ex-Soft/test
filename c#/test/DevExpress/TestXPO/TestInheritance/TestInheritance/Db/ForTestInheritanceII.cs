using DevExpress.Xpo;

namespace TestInheritance.Db
{
	[Persistent("TestDEForTestInheritanceII")]
	public class ForTestInheritanceII : XPBaseObject
	{
		int _id;
		string _value;

		protected Reference
			_left,
			_right;

		public ForTestInheritanceII(Session session) : base(session)
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

		[Persistent("LeftId")]
		[Association("Reference-ForTestInheritanceIILeft", typeof(Reference))]
		public Reference Left
		{
			get { return _left; }
			set { SetPropertyValue("Left", ref _left, value); }
		}

		[Persistent("RightId")]
		[Association("Reference-ForTestInheritanceIIRight", typeof(Reference))]
		public Reference Right
		{
			get { return _right; }
			set { SetPropertyValue("Right", ref _right, value); }
		}
	}

	public class ForTestInheritanceIIBackward : ForTestInheritanceII
	{
		public ForTestInheritanceIIBackward(Session session) : base(session)
		{}

		//[Persistent("RightId")]
		//[Association("Reference-ForTestInheritanceIIBackwardLeft", typeof(Reference))]
		public new Reference Left
		{
			get { return _right; }
			set { SetPropertyValue("Left", ref _right, value); }
		}

		//[Persistent("LeftId")]
		//[Association("Reference-ForTestInheritanceIIBackwardRight", typeof(Reference))]
		public new Reference Right
		{
			get { return _left; }
			set { SetPropertyValue("Right", ref _left, value); }
		}
	}
}
