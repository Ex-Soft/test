using System;
using System.Reflection;

namespace AggregatorClass
{
	public class AggregatorClass
	{
		object
			DerivedClassManager;

		public AggregatorClass(int aDerivedClassNo)
		{
			switch(aDerivedClassNo)
			{
				case 1 :
				{
					DerivedClassManager=new DerivedClass1.DerivedClass1();	
					break;
				}
				case 2 :
				{
					DerivedClassManager=new DerivedClass2.DerivedClass2();	
					break;
				}
			}
		}
		//---------------------------------------------------------------------------

		public void DerivedClassMethod()
		{
			try
			{
				DerivedClassManager.GetType().InvokeMember("DerivedClassMethod",BindingFlags.InvokeMethod,null,DerivedClassManager,null);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
		}
		//---------------------------------------------------------------------------

		public void BaseClassMethod()
		{
			try
			{
				DerivedClassManager.GetType().InvokeMember("BaseClassMethod",BindingFlags.InvokeMethod,null,DerivedClassManager,null);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}