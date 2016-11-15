using System;
using System.IO;
using System.Threading.Tasks;
using log4net;

namespace TestLevel
{
    class TaskLogger
    {
        public void Run(object param)
        {
            var taskNo = (int)param;
            var logger = string.Empty;

            switch (taskNo)
            {
                case 0: logger = "LoggerAll"; break;
                case 1: logger = "LoggerDebug"; break;
                case 2: logger = "LoggerInfo"; break;
                case 3: logger = "LoggerWarn"; break;
                case 4: logger = "LoggerError"; break;
                case 5: logger = "LoggerFatal"; break;
                case 6: logger = "LoggerOff"; break;
            }

            if (string.IsNullOrWhiteSpace(logger))
                return;

            ILog log = LogManager.GetLogger(logger);

            log.DebugFormat("{0} started...", taskNo);

            log.Debug("Debug");
            log.Info("Info");
            log.Warn("Warn");
            log.Error("Error");
            log.Fatal("Fatal");

            log.DebugFormat("{0} finished", taskNo);
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logNames = new[] { "LoggerMain.log", "LoggerOff.log", "LoggerFatal.log", "LoggerError.log", "LoggerWarn.log", "LoggerInfo.log", "LoggerDebug.log", "LoggerAll.log" };

            foreach (var logName in logNames)
                if (File.Exists(logName))
                    File.Delete(logName);

            log4net.Config.XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger("FileAppenderMain");

            log.Debug("Main started...");

            log.Debug("Debug (from Main b4)");
            log.Info("Info (from Main b4)");
            log.Warn("Warn (from Main b4)");
            log.Error("Error (from Main b4)");
            log.Fatal("Fatal (from Main b4)");

            const int threadsMax = 7;

            var tasks = new Task[threadsMax];

            for (var i = 0; i < threadsMax; ++i)
            {
                var task = new TaskLogger();
                tasks[i] = Task.Factory.StartNew(task.Run, i);
            }

            try
            {
                log.Debug("Debug (from Main in)");
                log.Info("Info (from Main in)");
                log.Warn("Warn (from Main in)");
                log.Error("Error (from Main in)");
                log.Fatal("Fatal (from Main in)");

                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }

            log.Debug("Main finished");
        }
    }
}
