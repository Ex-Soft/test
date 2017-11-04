//#define TEST_FROM_MSDN
#define TEST_MY

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Example
{
	#if TEST_MY
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
	#endif

	public static void Main()
	{	
		#if TEST_MY
			List<A>
				LA = new List<A>() { new A("1st"), new A("2nd"), new A("3rd") };

			ReadOnlyCollection<A>
				LARO = new ReadOnlyCollection<A>(LA);

			LARO[2].FString = "4th";

			Console.WriteLine("LA:");
			LA.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			Console.WriteLine("LARO:");
			foreach(A a in LARO)
				Console.WriteLine(a.FString);
			Console.WriteLine();

			A
				objA = new A("5th");

			LA[0] = objA;

			Console.WriteLine("LA:");
			LA.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			Console.WriteLine("LARO:");
			foreach (A a in LARO)
				Console.WriteLine(a.FString);
			Console.WriteLine();

			A
				objAII = new A("13th");

			LA.Add(objAII);

			Console.WriteLine("LA:");
			LA.ForEach((item) => { Console.WriteLine(item.FString); });
			Console.WriteLine();

			Console.WriteLine("LARO:");
			foreach (A a in LARO)
				Console.WriteLine(a.FString);
			Console.WriteLine();
		#endif

		#if TEST_FROM_MSDN
			List<string> dinosaurs = new List<string>();

			dinosaurs.Add("Tyrannosaurus");
			dinosaurs.Add("Amargasaurus");
			dinosaurs.Add("Deinonychus");
			dinosaurs.Add("Compsognathus");

			ReadOnlyCollection<string> readOnlyDinosaurs =
				new ReadOnlyCollection<string>(dinosaurs);

			Console.WriteLine();
			foreach (string dinosaur in readOnlyDinosaurs)
			{
				Console.WriteLine(dinosaur);
			}

			Console.WriteLine("\nCount: {0}", readOnlyDinosaurs.Count);

			Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
				readOnlyDinosaurs.Contains("Deinonychus"));

			Console.WriteLine("\nreadOnlyDinosaurs[3]: {0}",
				readOnlyDinosaurs[3]);

			Console.WriteLine("\nIndexOf(\"Compsognathus\"): {0}",
				readOnlyDinosaurs.IndexOf("Compsognathus"));

			Console.WriteLine("\nInsert into the wrapped List:");
			Console.WriteLine("Insert(2, \"Oviraptor\")");
			dinosaurs.Insert(2, "Oviraptor");

			Console.WriteLine();
			foreach (string dinosaur in readOnlyDinosaurs)
			{
				Console.WriteLine(dinosaur);
			}

			string[] dinoArray = new string[readOnlyDinosaurs.Count + 2];
			readOnlyDinosaurs.CopyTo(dinoArray, 1);

			Console.WriteLine("\nCopied array has {0} elements:",
				dinoArray.Length);
			foreach (string dinosaur in dinoArray)
			{
				Console.WriteLine("\"{0}\"", dinosaur);
			}
		#endif
	}
}