using System;

namespace DerivedClass2
{
	public class DerivedClass2:BaseClass.BaseClass
	{
		public void DerivedClassMethod()
		{
			Console.WriteLine("DerivedClassMethod() (from DerivedClass2)");
		}
		//---------------------------------------------------------------------------

		public void BaseClassMethod()
		{
			Console.Write("DerivedClass2::");
			BaseClass.BaseClass.BaseClassStaticMethod();
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}