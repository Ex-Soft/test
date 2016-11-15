namespace TestVI
{
	public class Detail
	{
		int
			_Id;

		string
			_Val;

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
