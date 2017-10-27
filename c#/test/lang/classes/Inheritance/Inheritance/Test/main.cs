using System;

namespace Test
{
	class TestClass
	{
		[STAThread]
		static void Main()
		{
			AggregatorClass.AggregatorClass
				AggregatorClass1=new AggregatorClass.AggregatorClass(1),
				AggregatorClass2=new AggregatorClass.AggregatorClass(2);

			AggregatorClass1.DerivedClassMethod();
			AggregatorClass2.DerivedClassMethod();

			AggregatorClass1.BaseClassMethod();
			AggregatorClass2.BaseClassMethod();
		}
	}
}