using System;

namespace DerivedClass1
{
	public class DerivedClass1:BaseClass.BaseClass
	{
		public void DerivedClassMethod()
		{
			Console.WriteLine("DerivedClassMethod() (from DerivedClass1)");
		}
		//---------------------------------------------------------------------------

		public void BaseClassMethod()
		{
			Console.Write("DerivedClass1::");
			BaseClass.BaseClass.BaseClassStaticMethod();
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}