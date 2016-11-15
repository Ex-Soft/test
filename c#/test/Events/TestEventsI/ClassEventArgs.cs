using System;

namespace TestEventsI
{
	class ClassEventArgs : EventArgs
	{
		int
			_FInt;

		string
			_FString;

		public ClassEventArgs()	: this(int.MinValue, string.Empty)
		{}

		public ClassEventArgs(ClassEventArgs obj) : this(obj.FInt, obj.FString)
		{}

		public ClassEventArgs(int FInt, string FString)
		{
			_FInt=FInt;
			_FString=FString;
		}

		public int FInt
		{
			get
			{
				return _FInt;
			}
			set
			{
				if (_FInt != value)
					_FInt = value;
			}
		}

		public string FString
		{
			get
			{
				return _FString;
			}
			set
			{
				if (_FString != value)
					_FString = value;
			}
		}
	}
}
