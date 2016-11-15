namespace TestXI
{
	class Person : Party
	{
		string
			_FirstName;

		public virtual string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}
	}
}
