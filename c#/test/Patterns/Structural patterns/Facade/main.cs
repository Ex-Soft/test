using System;

namespace Facade
{
	// "Subsystem ClassA"
	class SubSystemOne
	{
		public void MethodOne()
		{
			Console.WriteLine(" SubSystemOne Method");
		}
	}

	// "Subsystem ClassB"
	class SubSystemTwo
	{
		public void MethodTwo()
		{
			Console.WriteLine(" SubSystemTwo Method");
		}
	}

	// "Subsystem ClassC"
	class SubSystemThree
	{
		public void MethodThree()
		{
			Console.WriteLine(" SubSystemThree Method");
		}
	}

	// "Subsystem ClassD"
	class SubSystemFour
	{
		public void MethodFour()
		{
			Console.WriteLine(" SubSystemFour Method");
		}
	}

	// "Facade"
	class Facade
	{
		private SubSystemOne
			_one;

		private SubSystemTwo
			_two;

		private SubSystemThree
			_three;

		private SubSystemFour
			_four;

		public Facade()
		{
			_one = new SubSystemOne();
			_two = new SubSystemTwo();
			_three = new SubSystemThree();
			_four = new SubSystemFour();
		}

		public void MethodA()
		{
			Console.WriteLine("\nMethodA() ---- ");
			_one.MethodOne();
			_two.MethodTwo();
			_four.MethodFour();
		}

		public void MethodB()
		{
			Console.WriteLine("\nMethodB() ---- ");
			_two.MethodTwo();
			_three.MethodThree();
		}
	}

	class Program
	{
		static void Main()
		{
			Facade
				facade = new Facade();

			facade.MethodA();
			facade.MethodB();
		}
	}
}
