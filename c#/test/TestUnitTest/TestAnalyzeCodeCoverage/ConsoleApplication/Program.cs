using System;

using ClassLibrary;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			var testClass = new TestClass();

			Console.WriteLine(testClass.Add(1, 2));
			Console.WriteLine(testClass.Sub(1, 2));
		}
	}
}
