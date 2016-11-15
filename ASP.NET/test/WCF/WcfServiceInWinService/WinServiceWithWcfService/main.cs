// https://msdn.microsoft.com/en-us/library/ms733069%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396 How to: Host a WCF Service in a Managed Windows Service
// https://msdn.microsoft.com/en-us/library/ddhy0byf%28v=vs.110%29.aspx How to: Add Installers to Your Service Application

using System.ServiceProcess;

namespace WinServiceWithWcfService
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
                new WinService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
