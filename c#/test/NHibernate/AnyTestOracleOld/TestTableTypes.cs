namespace AnyTestOracleOld
{
	class TestTableTypes
	{
		long
			_Id;

		string
			_FVarchar2,
			_FNVarchar2,
			_FClob,
			_FNClob;

		public long Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		public string FVarchar2
		{
			get { return _FVarchar2; }
			set { _FVarchar2 = value; }
		}

		public string FNVarchar2
		{
			get { return _FNVarchar2; }
			set { _FNVarchar2 = value; }
		}

		public string FClob
		{
			get { return _FClob; }
			set { _FClob = value; }
		}
		public string FNClob
		{
			get { return _FNClob; }
			set { _FNClob = value; }
		}
	}
}
