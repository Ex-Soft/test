using System;
using Castle.Core.Logging;
using Castle.Windsor;

using static System.Console;

namespace TestNLogWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new WindsorContainer();
                container.Install(new WindsorInstaller());

                var logger = container.Resolve<ILogger>();

                logger.Trace("Trace");
                logger.Debug("Debug");
                logger.Info("Info");
                logger.Warn("Warn");
                logger.Error("Error");
                logger.Fatal("Fatal");
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
