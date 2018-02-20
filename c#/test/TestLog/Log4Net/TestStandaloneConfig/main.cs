//http://developmentfootprints.blogspot.com/2013/03/proper-configuring-log4net-in-aspnet-in.html

#define WITH_JOIN

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using log4net;

namespace TestStandaloneConfig
{
    class ThreadClass
    {
        readonly int
            _mSec;

        public Thread
            Thread;

        readonly ILog
            _log;

        public ThreadClass(int mSec, int threadNo, bool isBackground, ILog log)
        {
            _mSec = mSec;
            _log = log;

            log4net.GlobalContext.Properties["GlobalContextProperty"] = "GlobalContextPropertyThreadNo" + threadNo;
            log4net.LogicalThreadContext.Properties["LogicalThreadContextProperty"] = "LogicalThreadContextPropertyThreadNo" + threadNo;
            log4net.ThreadContext.Properties["ThreadContextProperty"] = "ThreadContextPropertyThreadNo" + threadNo;

            using (log4net.ThreadContext.Stacks["NDC"].Push("context NDC"))
            {
                _log.Info("Message from NDC");
            }

            Thread = new Thread(new ThreadStart(this.run));
            Thread.Name = "Thread# " + threadNo;
            Thread.IsBackground = isBackground;
            Thread.Start();
        }

        void run()
        {
            Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
            _log.Info(string.Format("{0} started...", Thread.Name));

            Random
                rnd = new Random(Thread.ManagedThreadId);

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
                _log.Info(string.Format("{0} i={1}", Thread.Name, i));
                Thread.Sleep(_mSec * rnd.Next(10));
            }

            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
            _log.Info(string.Format("{0} finished", Thread.Name));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(Assembly.GetCallingAssembly());

            log4net.GlobalContext.Properties["GlobalContextProperty"] = "GlobalContextPropertyMain";
            log4net.LogicalThreadContext.Properties["LogicalThreadContextProperty"] = "LogicalThreadContextPropertyMain";
            log4net.ThreadContext.Properties["ThreadContextProperty"] = "ThreadContextPropertyMain";

            log4net.Config.XmlConfigurator.Configure();

            //var log = LogManager.GetLogger("RollingFileAppender");
            var log = LogManager.GetLogger("FileAppender");

            log.Fatal("Fatal");
            log.Error("Error");
            log.Warn("Warn");
            log.Info("Info");
            log.Debug("Debug");

            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));
            log.Info("Main thread started...");

            Dictionary<int, ThreadClass>
                threads = new Dictionary<int, ThreadClass>();

            int
                threadsMax = 5,
                mSec = 100;

            bool
                isBackground = false;

            for (int i = 0; i < threadsMax; ++i)
                threads.Add(i, new ThreadClass(mSec, i, isBackground, log));

            #if WITH_JOIN
                for (int i = 0; i < threads.Count; ++i)
                    threads[i].Thread.Join();
            #endif

            log.Info("Main thread finished");
            Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
        }
    }
}
