using System.Collections.Generic;
using System.Web.Services;

namespace ServiceI
{
	/// <summary>
	/// Summary description for ServiceI
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class ServiceI : System.Web.Services.WebService
	{
		[WebMethod]
		public TestClassI Sum(List<TestClassI> list)
		{
			TestClassI
				tmpTestClassI = new TestClassI(0);

			list.ForEach((item) =>
			{
				tmpTestClassI.FInt += item.FInt;
			});

			return tmpTestClassI;
		}

		[WebMethod]
		public TestClassI SumContainer(TestClassIContainer list)
		{
			TestClassI
				tmpTestClassI = new TestClassI(0);

			list.container.ForEach((item) =>
			{
				tmpTestClassI.FInt += item.FInt;
			});

			return tmpTestClassI;
		}
	}
}