using System;
using System.Collections.Generic;

namespace GenericsI
{
	class TestClass
	{
		int
			_value;

		public TestClass():this(0)
		{}

		public TestClass(TestClass obj):this(obj.Value)
		{}

		public TestClass(int value)
		{
			Value = value;
		}

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (_value != value)
					_value = value;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<int>
				li=new List<int>();

			li.Add(1);
			li.Add(3);
			li.Add(5);
			li.Add(7);

			int
				di=default(int),
				i;

			i = li.Find(delegate(int val) { return val == 5; });
			Console.WriteLine(i!=di ? "oB!" : "Tampax");

			i = li.Find(delegate(int val) { return val == 6; });
			Console.WriteLine(i != di ? "oB!" : "Tampax");

			List<TestClass>
				ltc = new List<TestClass>();

			ltc.Add(new TestClass(1));
			ltc.Add(new TestClass(3));
			ltc.Add(new TestClass(5));
			ltc.Add(new TestClass(7));

			TestClass
				dtc = default(TestClass),
				tc;

			tc = ltc.Find(delegate(TestClass _tc_) { return _tc_.Value == 5; });
			Console.WriteLine(tc!=dtc ? "oB!" : "Tampax");

			tc = ltc.Find(delegate(TestClass _tc_) { return _tc_.Value == 6; });
			Console.WriteLine(tc!=dtc ? "oB!" : "Tampax");
		}
	}
}
