using System;
using System.Collections.Generic;

namespace TestList
{
	class A
	{
		string
			_FString;

		public A() : this(string.Empty)
		{}

		public A(A obj) : this(obj.FString)
		{}

		public A(string aFString)
		{
			_FString = aFString;
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

	class Program
	{
		static void Main(string[] args)
		{
			List<int>
				LI = new List<int>();

            int
                tmpInt;

		    tmpInt = LI.FindIndex(element => element == 13);

            LI = new List<int>(new int[] { 5, 2, 9, 1 });

            LI.ForEach(i => {
                Console.WriteLine(i);
                if (i < 5)
                    return;
                Console.WriteLine(i);
            });

			Console.WriteLine(LI.ToString());

			// Finds first element greater than 5
			tmpInt = LI.Find(item => item > 5);
			tmpInt = LI.Find(item => item > 20);

			bool
				exists;

			exists = LI.Exists(item => item > 5);
			exists = LI.Exists(item => item > 20);

			tmpInt = LI.IndexOf(5);
			tmpInt = LI.IndexOf(20);

			tmpInt = LI.Find(delegate(int val) { return val == 5; });
			tmpInt = LI.Find(delegate(int val) { return val == 20; });

			List<string>
				LS = new List<string>(new string[] { "2nd", "3rd", "1st", "4th" });

			LS.ForEach((item) =>
			{
				if (item == "3rd")
					return;

				Console.WriteLine(item);
			});

			string
				tmpString;

			tmpString = LS.Find(item => item == "3rd");
			tmpString = LS.Find(item => item == "5th");

			exists = LS.Exists(item => item == "3rd");
			exists = LS.Exists(item => item == "5th");

			tmpInt = LS.IndexOf("3rd");
			tmpInt = LS.IndexOf("5th");

			tmpString = LS.Find(delegate(string val) { return val == "3rd"; });
			tmpString = LS.Find(delegate(string val) { return val == "5th"; });

			A
				a = new A("1st");

			List<A>
				L1 = new List<A>();

			L1.Add(a);
			a.FString = "2nd";
			L1.Add(a);

			A
				b = new A("3rd");

			L1.Add(new A(b));
			b.FString = "4th";
			L1.Add(new A(b));

			Console.WriteLine("L1:");
			L1.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			List<A>
				L2 = new List<A>(L1);

			Console.WriteLine("L2:");
			L1.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			L1.ForEach((item) => { item.FString=";-)"; });

			Console.WriteLine("L1:");
			L1.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();
			Console.WriteLine("a={0}",a.FString);
			Console.WriteLine("L2:");
			L2.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

            List<int>
                LI2 = new List<int>(new int[] { 5, 2, 9, 1 });

            LI = new List<int>(new int[] { 5, 2, 9, 1 });
            LI.AddRange(LI2);
            LI.ForEach((item) => Console.WriteLine(item));
		}
	}
}
