using System;
using System.Collections.Generic;

namespace ClassIV
{
	public class A
	{
		int
			_Val;

		public A():this(default(int))
		{}

		public A(A obj):this(obj.Val)
		{}

		public A(int aVal)
		{
			_Val=aVal;
		}

		public virtual int Val
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

	public class B : A
	{
		int
			_ValVal;

		public B() : this(default(int),default(int))
		{
		}

		public B(B obj)	: this(obj.Val, obj.ValVal)
		{
		}

		public B(int aVal, int aValVal) : base(aVal)
		{
			_ValVal = aValVal;
		}

		public virtual int ValVal
		{
			get
			{
				return _ValVal;
			}
			set
			{
				if (_ValVal != value)
					_ValVal = value;
			}
		}
	}

	public class AA
	{
		int
			_Val;

		public AA()
		{}

		public AA(AA obj)
		{
			_Val=obj.Val;
		}

		public AA(int aVal)
		{
			_Val = aVal;
		}

		public virtual int Val
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

	public class BB : AA
	{
		int
			_ValVal;

		public BB()
		{}

		public BB(BB obj) : base(obj)
		{
			_ValVal=obj.ValVal;
		}

		public BB(int aVal, int aValVal) : base(aVal)
		{
			_ValVal = aValVal;
		}

		public virtual int ValVal
		{
			get
			{
				return _ValVal;
			}
			set
			{
				if (_ValVal != value)
					_ValVal = value;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			AA
				a = new AA(1);

			BB
				b = new BB(1,11);

			a = new AA(b);
		}
	}
}
