using System;

namespace TestDelegates
{
	class A
	{
		public delegate void fPtrType();

		void f()
		{
			Console.WriteLine("A::f()");
		}

		public void RunF()
		{
			fPtrType
				fPtr=new fPtrType(f);

			B
				b = new B();

			b.DoIt(fPtr);
		}
	}

	class B
	{
		public void DoIt(A.fPtrType fPtr)
		{
			fPtr();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			A
				a = new A();

			a.RunF();
		}
	}
}
