using TestPivotReportWithPaging;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]

namespace TestPivotReportWithPaging
{
    public static class PreStartApp
    {
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Start()
        {
            Logger.Info("Application PreStart");
        }
    }
}