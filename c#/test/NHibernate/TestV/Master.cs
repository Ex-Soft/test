using System.Collections;

namespace TestV
{
	public class Master
	{
		int
			_Id;

		string
			_Val;

		IList
			_Details;

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

		public virtual IList Details
		{
			get
			{
				return _Details;
			}
			set
			{
				_Details = value;
			}
		}
	}
}
