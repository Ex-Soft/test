namespace TestXI
{
	class Company : Party
	{
		string
			_CompanyName;

		public virtual string CompanyName
		{
			get { return _CompanyName; }
			set { _CompanyName = value; }
		}
	}
}
