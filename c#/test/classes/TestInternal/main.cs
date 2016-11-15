using System;

namespace TestInternal
{
	public class A
	{
		int
			privateInt;

		protected int
			protectedInt;

		public int
			publicInt;

		internal int
			internalInt;
	}

	class Program
	{
		static void Main(string[] args)
		{
			A
				a = new A();

			int
				tmp;

			tmp = a.publicInt;
			tmp = a.internalInt;
		}
	}
}
