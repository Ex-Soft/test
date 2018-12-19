using System;

namespace ClassesI
{
	class A
	{
		public void Test()
		{
			Console.WriteLine("A");
		}
	}

	class B : A
	{
		public void Test()
		{
			Console.WriteLine("B");
		}
	}

	class ClassesI
	{
		[STAThread]
		static void Main(string[] args)
		{
			A
				a=new A(),
				_a_;

			B
				b=new B();

			a.Test(); // A
			b.Test(); // B
			Console.WriteLine();

			_a_=a;
			_a_.Test(); // A
			_a_=b;
			_a_.Test(); // A
			Console.WriteLine();

			_a_=new B();
			_a_.Test(); // A
			Console.WriteLine();
		}
	}
}
