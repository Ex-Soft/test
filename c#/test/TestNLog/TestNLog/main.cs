using NLog;

namespace TestNLog
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Trace("Trace");
            logger.Debug("Debug");
            logger.Info("Info");
            logger.Warn("Warn");
            logger.Error("Error");
            logger.Fatal("Fatal");
        }
    }
}
