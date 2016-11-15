using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestLockDictionaryNode
{
    class TaskParam
    {
        public int
            i,
            mSec,
            nodesMax;

        public Dictionary<int, Log>
            victim;
    }

    class Log
    {
        readonly List<string> _log = new List<string>();

        public void Append(string msg)
        {
            _log.Add(msg);
        }

        public void WriteLine()
        {
            if (_log.Count == 0)
            {
                Console.WriteLine("Count == 0");
                return;
            }

            _log.ForEach(Console.WriteLine);
        }
    }

    class Program
    {
        const string FormatString = "mm:ss.fffffff";

        static void Main(string[] args)
        {
            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString(FormatString));

            var victim = new Dictionary<int, Log>();

            int
                threadsMax = 5,
                mSec = 1000,
                nodesMax = 10,
                tmpInt;

            if (args != null && args.Length >= 1 && int.TryParse(args[0], out tmpInt))
                threadsMax = tmpInt;

            if (args != null && args.Length >= 2 && int.TryParse(args[1], out tmpInt))
                mSec = tmpInt;

            if (args != null && args.Length >= 3 && int.TryParse(args[2], out tmpInt))
                nodesMax = tmpInt;

            for (var i = 0; i < nodesMax; ++i)
                victim[i] = new Log();

            Action<object> action = Run;
            var tasks = new Task[threadsMax];

            for (var i = 0; i < threadsMax; ++i)
            {
                var param = new TaskParam { i = i, mSec = mSec, nodesMax = nodesMax, victim = victim };
                tasks[i] = Task.Factory.StartNew(action, param);
            }

            try
            {
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

            for (var i = 0; i < nodesMax; ++i)
            {
                Console.WriteLine();
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("node[{0}]", i);
                victim[i].WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString(FormatString));
        }

        static void Run(object param)
        {
            TaskParam taskParam;

            if ((taskParam = param as TaskParam) == null)
                return;

            Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString(FormatString), taskParam.i);

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            for (var i = 0; i < 10; ++i)
            {
                int
                    nodeNo,
                    millisecondsTimeout = taskParam.mSec*rnd.Next(10);

                Console.WriteLine("{0}\t{1} i={2} (will sleep {3}ms)", DateTime.Now.ToString(FormatString), taskParam.i, i, millisecondsTimeout);

                if ((nodeNo = rnd.Next(taskParam.nodesMax)) < taskParam.nodesMax)
                {
                    var dateTimeBeforeLock = DateTime.Now;

                    Console.WriteLine("{0}\t{1} i={2} trying to lock node {3}", dateTimeBeforeLock.ToString(FormatString), taskParam.i, i, nodeNo);

                    lock (taskParam.victim[nodeNo])
                    {
                        var dateTimeAfterLock = DateTime.Now;
                        var millisecondsTimeoutForLock = taskParam.mSec*rnd.Next(10);
                        string msg;

                        taskParam.victim[nodeNo].Append(msg = string.Format("{0}\t{1} i={2} has locked node {3} successfully (b4lock {4} wait {5}ms will sleep {6}ms)", dateTimeAfterLock.ToString(FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds, millisecondsTimeoutForLock));
                        Console.WriteLine(msg);

                        Thread.Sleep(millisecondsTimeoutForLock);
                    }
                }

                Thread.Sleep(millisecondsTimeout);
            }

            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString(FormatString), taskParam.i);
        }
    }
}
