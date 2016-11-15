using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestLockDictionaryNodeViaSimpleLockII
{
    class TaskParam
    {
        public int
            i,
            mSec,
            nodesMax;
    }

    class LogItem
    {
        public const string FormatString = "mm:ss.fffffff";

        public int
            ThreadNo,
            Iteration,
            NodeNo;

        public string
            Operation;

        public DateTime
            Begin;

        public DateTime?
            End;

        public LogItem(int threadNo, int iteration, string operation, int nodeNo, DateTime begin, DateTime? end = null)
        {
            ThreadNo = threadNo;
            Iteration = iteration;
            Operation = operation;
            NodeNo = nodeNo;
            Begin = begin;
            End = end;
        }

        public LogItem(LogItem obj) : this(obj.ThreadNo, obj.Iteration, obj.Operation, obj.NodeNo, obj.Begin, obj.End)
        {}

        public override string ToString()
        {
            return String.Format("{0}\t{1} i={2} {3} {4}", End.HasValue ? End.Value.ToString(FormatString) : Begin.ToString(FormatString), ThreadNo, Iteration, Operation, End.HasValue ? String.Format("(b4operation {0} wait {1}ms)", Begin.ToString(FormatString), (End.Value - Begin).TotalMilliseconds) : string.Empty);
        }
    }

    class Log
    {
        public readonly List<LogItem> _log = new List<LogItem>();

        public void Append(LogItem logItem)
        {
            _log.Add(logItem);
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
        static Dictionary<int, Log> victim = new Dictionary<int, Log>();

        static void Main(string[] args)
        {
            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString(LogItem.FormatString));

            int
                threadsMax = Environment.ProcessorCount * 2,
                mSec = 1000,
                nodesMax = 10,
                tmpInt;

            if (args != null && args.Length >= 1 && int.TryParse(args[0], out tmpInt))
                threadsMax = tmpInt;

            if (args != null && args.Length >= 2 && int.TryParse(args[1], out tmpInt))
                mSec = tmpInt;

            if (args != null && args.Length >= 3 && int.TryParse(args[2], out tmpInt))
                nodesMax = tmpInt;

            Action<object> action = Run;
            var tasks = new Task[threadsMax];

            for (var i = 0; i < threadsMax; ++i)
            {
                var param = new TaskParam { i = i, mSec = mSec, nodesMax = nodesMax };
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
                if (!victim.ContainsKey(i))
                    continue;

                Console.WriteLine();
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("node[{0}]", i);
                victim[i].WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            victim.Values.SelectMany(i => i._log).Where(i => i.End.HasValue && (i.End.Value - i.Begin).TotalMilliseconds > 0 && !i.Operation.StartsWith("has released node")).OrderBy(i => i.End.Value).ToList().ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString(LogItem.FormatString));
        }
        static void Run(object param)
        {
            TaskParam taskParam;

            if ((taskParam = param as TaskParam) == null)
                return;

            Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString(LogItem.FormatString), taskParam.i);

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            for (var i = 0; i < 10; ++i)
            {
                int
                    nodeNo,
                    millisecondsTimeout = taskParam.mSec * rnd.Next(10);

                Console.WriteLine("{0}\t{1} i={2} (will sleep {3}ms)", DateTime.Now.ToString(LogItem.FormatString), taskParam.i, i, millisecondsTimeout);

                if ((nodeNo = rnd.Next(taskParam.nodesMax)) < taskParam.nodesMax)
                {
                    string msg;

                    DateTime
                        dateTimeBeforeLock = DateTime.Now,
                        dateTimeAfterLock;

                    LogItem
                        logItemBeforeLock,
                        logItemAfterLock;

                    bool isNewNode;

                    logItemBeforeLock = new LogItem(taskParam.i, i, String.Format("trying to lock for check node {0}", nodeNo), nodeNo, dateTimeBeforeLock);
                    Console.WriteLine("{0}\t{1} i={2} trying to lock for check node {3}", dateTimeBeforeLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);
                    lock (victim)
                    {
                        dateTimeAfterLock = DateTime.Now;
                        logItemAfterLock = new LogItem(taskParam.i, i, String.Format("has locked for check node {0} successfully", nodeNo), nodeNo, dateTimeBeforeLock, dateTimeAfterLock);
                        Console.WriteLine("{0}\t{1} i={2} has locked for check node {3} successfully (b4lock {4} wait {5}ms)", dateTimeAfterLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds);

                        LogItem logItemNodeHasBeenAdded = null;

                        if (isNewNode = !victim.ContainsKey(nodeNo))
                        {
                            victim.Add(nodeNo, new Log());
                            logItemNodeHasBeenAdded = new LogItem(taskParam.i, i, String.Format("node {0} has been added", nodeNo), nodeNo, DateTime.Now);
                            Console.WriteLine("{0}\t{1} i={2} node {3} has been added", DateTime.Now.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);
                        }

                        victim[nodeNo].Append(logItemBeforeLock);
                        victim[nodeNo].Append(logItemAfterLock);

                        if (logItemNodeHasBeenAdded != null)
                            victim[nodeNo].Append(logItemNodeHasBeenAdded);

                        dateTimeAfterLock = DateTime.Now;
                        victim[nodeNo].Append(new LogItem(taskParam.i, i, String.Format("has released for check node {0} successfully", nodeNo), nodeNo, dateTimeBeforeLock, dateTimeAfterLock));
                        Console.WriteLine("{0}\t{1} i={2} has released for check node {3} successfully (b4lock {4} wait {5}ms)", DateTime.Now.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds);
                    }

                    dateTimeBeforeLock = DateTime.Now;
                    logItemBeforeLock = new LogItem(taskParam.i, i, String.Format("trying to lock node {0}", nodeNo), nodeNo, dateTimeBeforeLock);
                    Console.WriteLine("{0}\t{1} i={2} trying to lock node {3}", dateTimeBeforeLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);

                    lock (victim[nodeNo])
                    {
                        dateTimeAfterLock = DateTime.Now;
                        var millisecondsTimeoutForLock = taskParam.mSec * rnd.Next(10);
                        victim[nodeNo].Append(logItemBeforeLock);
                        victim[nodeNo].Append(new LogItem(taskParam.i, i, String.Format("has locked node {0} successfully (will sleep {1}ms)", nodeNo,
                                millisecondsTimeoutForLock), nodeNo, dateTimeBeforeLock, dateTimeAfterLock));
                        Console.WriteLine("{0}\t{1} i={2} has locked node {3} successfully (will sleep {6}ms) (b4lock {4} wait {5}ms)", dateTimeAfterLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds, millisecondsTimeoutForLock);

                        if (isNewNode)
                        {
                            Foo1(nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));
                            Foo2(nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));
                        }
                        else
                            Foo2(nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));

                        Thread.Sleep(millisecondsTimeoutForLock);

                        var tmpDateTime = DateTime.Now;
                        victim[nodeNo].Append(new LogItem(taskParam.i, i, String.Format("has released node {0} successfully", nodeNo), nodeNo, dateTimeAfterLock, tmpDateTime));
                        Console.WriteLine("{0}\t{1} i={2} has released node {3} successfully (b4lock {4} wait {5}ms)", tmpDateTime.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeAfterLock.ToString(LogItem.FormatString), (tmpDateTime - dateTimeAfterLock).TotalMilliseconds);
                    }
                }

                Thread.Sleep(millisecondsTimeout);
            }

            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString(LogItem.FormatString), taskParam.i);
        }

        static void Foo1(int nodeNo, int mSec, LogItem logItem)
        {
            const string methodName = "Foo1";

            logItem.Begin = DateTime.Now;

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var millisecondsTimeoutForLock = mSec * rnd.Next(10);

            logItem.Operation = String.Format("{0}() starting... (will sleep {1}ms)", methodName, millisecondsTimeoutForLock);

            Console.WriteLine(logItem);

            Thread.Sleep(millisecondsTimeoutForLock);

            victim[nodeNo].Append(logItem);

            var logItemEnd = new LogItem(logItem);
            logItemEnd.Operation = String.Format("{0}() finished", methodName);
            logItemEnd.End = DateTime.Now;
            victim[nodeNo].Append(logItemEnd);
            Console.WriteLine(logItemEnd);
        }

        static void Foo2(int nodeNo, int mSec, LogItem logItem)
        {
            const string methodName = "Foo2";

            logItem.Begin = DateTime.Now;

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var millisecondsTimeoutForLock = mSec * rnd.Next(10);

            logItem.Operation = String.Format("{0}() starting... (will sleep {1}ms)", methodName, millisecondsTimeoutForLock);

            Console.WriteLine(logItem);

            Thread.Sleep(millisecondsTimeoutForLock);

            victim[nodeNo].Append(logItem);

            var logItemEnd = new LogItem(logItem);
            logItemEnd.Operation = String.Format("{0}() finished", methodName);
            logItemEnd.End = DateTime.Now;
            victim[nodeNo].Append(logItemEnd);
            Console.WriteLine(logItemEnd);
        }
    }
}
