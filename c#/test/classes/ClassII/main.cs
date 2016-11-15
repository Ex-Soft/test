using System;

namespace ClassII
{
	abstract class AA
	{
		public abstract void AAMethod();
	}

	class A : AA
	{
		public override void AAMethod()
		{
			Console.WriteLine("AAMethod");
		}
	}

	abstract class AB
	{
		public abstract void ABMethod();
	}

	class B : AB
	{
		public override void ABMethod()
		{
			Console.WriteLine("ABMethod");
		}
	}

	class FinalClass
	{
		A
			a;

		B
			b;

		public FinalClass()
		{
			a = new A();
			b = new B();
		}

		public void AAMethod()
		{
			a.AAMethod();
		}

		public void ABMethod()
		{
			b.ABMethod();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			A
				a = new A();

			a.AAMethod();

			B
				b = new B();

			b.ABMethod();

			FinalClass
				c = new FinalClass();

			c.AAMethod();
			c.ABMethod();
		}
	}
}
