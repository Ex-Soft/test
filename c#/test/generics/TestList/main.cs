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

    class B : A
    {}

	class Program
	{
		static void Main(string[] args)
		{
		    var listOfB = new List<B>
		    {
		        new B()
		    };

		    var listOfAI = new List<A>();

            listOfB.ForEach((item) => { listOfAI.Add(item); });

            List<int>
				listOfIntI = new List<int>();

            int
                tmpInt,
                defaultInt = default(int);

		    tmpInt = listOfIntI.FindIndex(element => element == 13);

            listOfIntI = new List<int>(new int[] { 5, 2, 9, 1 });

            listOfIntI.ForEach(i => {
                Console.WriteLine(i);
                if (i < 5)
                    return;
                Console.WriteLine(i);
            });

			Console.WriteLine(listOfIntI.ToString());

			// Finds first element greater than 5
			tmpInt = listOfIntI.Find(item => item > 5);
			tmpInt = listOfIntI.Find(item => item > 20);

			bool
				exists;

			exists = listOfIntI.Exists(item => item > 5);
			exists = listOfIntI.Exists(item => item > 20);

			tmpInt = listOfIntI.IndexOf(5);
			tmpInt = listOfIntI.IndexOf(20);

			tmpInt = listOfIntI.Find(delegate(int val) { return val == 5; });
            System.Diagnostics.Debug.WriteLine(tmpInt != defaultInt ? "oB!" : "Tampax");
			tmpInt = listOfIntI.Find(delegate(int val) { return val == 20; });
            System.Diagnostics.Debug.WriteLine(tmpInt != defaultInt ? "oB!" : "Tampax");

            List<string>
				listOfStringI = new List<string>(new string[] { "2nd", "3rd", "1st", "4th" });

			listOfStringI.ForEach((item) =>
			{
				if (item == "3rd")
					return;

				Console.WriteLine(item);
			});

			string
				tmpString;

			tmpString = listOfStringI.Find(item => item == "3rd");
			tmpString = listOfStringI.Find(item => item == "5th");

			exists = listOfStringI.Exists(item => item == "3rd");
			exists = listOfStringI.Exists(item => item == "5th");

			tmpInt = listOfStringI.IndexOf("3rd");
			tmpInt = listOfStringI.IndexOf("5th");

			tmpString = listOfStringI.Find(delegate(string val) { return val == "3rd"; });
			tmpString = listOfStringI.Find(delegate(string val) { return val == "5th"; });

		    listOfAI = new List<A>
		    {
		        new A("1st"),
                new A("2nd"),
                new A("3rd"),
                new A("4th"),
                new A("5th")
		    };

		    A
                a,
		        defaultA = default(A);

		    a = listOfAI.Find(delegate(A _a_) { return _a_.FString == "3rd"; });
            System.Diagnostics.Debug.WriteLine(a != defaultA ? "oB!" : "Tampax");
            a = listOfAI.Find(delegate (A _a_) { return _a_.FString == "blah-blah-blah"; });
            System.Diagnostics.Debug.WriteLine(a != defaultA ? "oB!" : "Tampax");

            a = new A("1st");
            listOfAI = new List<A>();

            listOfAI.Add(a);
			a.FString = "2nd";
            listOfAI.Add(a);

			A
				b = new A("3rd");

            listOfAI.Add(new A(b));
			b.FString = "4th";
            listOfAI.Add(new A(b));

			Console.WriteLine("listOfAI:");
            listOfAI.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			List<A>
				listOfAII = new List<A>(listOfAI);

			Console.WriteLine("listOfAII:");
            listOfAI.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

            listOfAI.ForEach((item) => { item.FString=";-)"; });

			Console.WriteLine("listOfAI:");
            listOfAI.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();
			Console.WriteLine("a={0}",a.FString);
			Console.WriteLine("listOfAII:");
			listOfAII.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

            List<int>
                listOfIntII = new List<int>(new int[] { 5, 2, 9, 1 });

            listOfIntI = new List<int>(new int[] { 5, 2, 9, 1 });
            listOfIntI.AddRange(listOfIntII);
            listOfIntI.ForEach((item) => Console.WriteLine(item));
		}
	}
}
