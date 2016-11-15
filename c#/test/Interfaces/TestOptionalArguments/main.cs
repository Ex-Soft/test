// https://blogs.msdn.microsoft.com/ericlippert/2011/05/09/optional-argument-corner-cases-part-one/
// https://blogs.msdn.microsoft.com/ericlippert/2011/05/12/optional-argument-corner-cases-part-two/
// https://blogs.msdn.microsoft.com/ericlippert/2011/05/16/optional-argument-corner-cases-part-three/

using System;

namespace TestOptionalArguments
{
	public interface IA
	{
		void FooI(int pInt = 13);
		void FooII(int pIntI = 13, int pIntII = 26);
		void FooIII(int pInt);
	}

	public class A : IA
	{
		public void FooI(int pInt = 13)
		{
			System.Diagnostics.Debug.WriteLine("pInt = {0}", pInt);
		}

		public void FooII(int pIntI = 13, int pIntII = 39)
		{
			System.Diagnostics.Debug.WriteLine("pIntI = {0}, pIntII = {1}", pIntI, pIntII);
		}

		public void FooIII(int pInt = 13)
		{
			System.Diagnostics.Debug.WriteLine("pInt = {0}", pInt);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			A a = new A();
			IA ia = new A();

			a.FooI();		// 13
			a.FooI(26);		// 26
			ia.FooI();		// 13
			ia.FooI(26);	// 26

			a.FooII();						// 13, 39
			a.FooII(26);					// 26, 39
			a.FooII(26, Int32.MaxValue);	// 26, 2147483647
			ia.FooII();						// 13, 26
			ia.FooII(26);					// 26, 26
			ia.FooII(26, Int32.MaxValue);	// 26, 2147483647

			a.FooIII();		// 13
			a.FooIII(26);	// 26
			//ia.FooIII();	// Error	1	No overload for method 'FooIII' takes 0 arguments
			ia.FooIII(26);	// 26
		}
	}
}
