namespace TestVII
{
	public class Detail
	{
		int
			_Id;

		string
			_Val;

		Master
			_Master;

		public virtual int Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
					_Id = value;
			}
		}

		public virtual Master Master
		{
			get
			{
				return _Master;
			}
			set
			{
				_Master = value;
			}
		}

		public virtual string Val
		{
			get
			{
				return _Val;
			}
			set
			{
				if (_Val != value)
					_Val = value;
			}
		}
	}
}
