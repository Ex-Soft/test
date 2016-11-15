using System.ServiceProcess;

namespace TestService
{
	static class Program
	{
		static void Main()
		{
			ServiceBase[]
				ServicesToRun = new ServiceBase[] 
				{ 
					new TestService() 
				};

			ServiceBase.Run(ServicesToRun);
		}
	}
}
