using System;

namespace ClassVI
{
	class A
	{
		public virtual void Test()
		{
			Console.WriteLine("A");
		}
	}

	class B : A
	{
		public override void Test()
		{
			Console.WriteLine("B");
		}
	}

	class C : B
	{
		public new virtual void Test()
		{
			Console.WriteLine("C");
		}
	}

	class D : C
	{
		public override void Test()
		{
			Console.WriteLine("D");
		}
	}
	class ClassVI
	{
		[STAThread]
		static void Main(string[] args)
		{
			A
				a=new A(),
				_a_;

			B
				b=new B(),
				_b_;

			C
				c=new C(),
				_c_;

			D
				d=new D();

			a.Test(); // A
			b.Test(); // B
			c.Test(); // C
			d.Test(); // D
			Console.WriteLine();

			_a_=a;
			_a_.Test(); // A
			_a_=b;
			_a_.Test(); // B
			_a_=c;
			_a_.Test(); // B
			_a_=d;
			_a_.Test(); // B
			Console.WriteLine();

			_b_=b;
			_b_.Test(); // B
			_b_=c;
			_b_.Test(); // B
			_b_=d;
			_b_.Test(); // B
			Console.WriteLine();

			_c_=c;
			_c_.Test(); // C
			_c_=d;
			_c_.Test(); // D
			Console.WriteLine();

			_a_=new D();
			_a_.Test(); // B
			_c_=new D();
			_c_.Test(); // D
			Console.WriteLine();
		}
	}
}
