using System;

namespace InterfaceI
{
	class Program
	{
		public interface I
		{
			void Show();
		}

		public class A : I
		{
			public void Show()
			{
				((I)this).Show();
			}

			void I.Show()
			{
				Console.WriteLine("A.I.Show()");
			}
		}

        public class B
        {}

		static void Main(string[] args)
		{
			A
				a = new A();

            B
                b = new B();

			a.Show();

            Console.WriteLine((a as I) != null ? "oB!" : "Tampax");
            Console.WriteLine((b as I) != null ? "oB!" : "Tampax");
		}
	}
}
