using System.ServiceProcess;

namespace WindowsServiceWithWebServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new ServiceWithWebServiceHost() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
