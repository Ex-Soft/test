namespace TestXI
{
	abstract class Party
	{
		int
			_Id;

		public virtual int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}
	}
}
