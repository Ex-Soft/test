using System.Collections.Generic;

using TestService.ServiceI;

namespace TestService
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceISoapClient
				ServiceI = new ServiceISoapClient("ServiceISoap");

			List<TestClassI>
				list = new List<TestClassI>();

			TestClassI
				tmpTestClassI;

			tmpTestClassI = new TestClassI();
			tmpTestClassI.FInt = 1;
			list.Add(tmpTestClassI);

			tmpTestClassI = new TestClassI();
			tmpTestClassI.FInt = 2;
			list.Add(tmpTestClassI);

			tmpTestClassI = new TestClassI();
			tmpTestClassI.FInt = 3;
			list.Add(tmpTestClassI);
			
			TestClassI
				TestClassI=ServiceI.SumContainer(list.ToArray());
		}
	}
}
