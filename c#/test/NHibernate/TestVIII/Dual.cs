namespace TestVIII
{
	class Dual
	{
		string
			_Dummy;

		public virtual string Dummy
		{
			get
			{
				return _Dummy;
			}
			set
			{
				if (_Dummy != value)
					_Dummy = value;
			}
		}
	}
}
