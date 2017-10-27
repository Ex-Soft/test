using System;

namespace TestExplicitImplementation
{
	class Program
	{
	    public interface II
	    {
	        void B();
	    }

	    public class Base
	    {
	        public void A() { Console.WriteLine("{0}.A()", GetType().Name); }
            public void B() { Console.WriteLine("{0}.B()", GetType().Name); }
	    }

	    public class Derived : Base, II
	    {
            void II.B() { Console.WriteLine("{0}.II.B()", GetType().Name); }
	    }

		public interface IEven
		{
			bool IsOdd(int x);
			bool IsEven(int x);
		}

		public class A : IEven
		{
			bool IEven.IsOdd(int x)
			{
				return (x % 2) != 0;
			}

			public bool IsEven(int x)
			{
				return !((IEven)this).IsOdd(x);
			}
		}

		static void Main()
		{
			A
				a = new A();

			Console.WriteLine(a.IsEven(4));
            //Console.WriteLine(a.IsOdd(3)); // Cannot access explicit implementation of 'IEven.IsOdd'

            Console.WriteLine(((IEven)a).IsOdd(3));

		    var derived = new Derived();

            derived.A();
            derived.B();

		    var iderived = derived as II;

            iderived.B();
		}
	}
}
