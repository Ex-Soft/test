using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLockDictionaryNodeViaSimpleLock
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
        
        public LogItem(int threadNo, int iteration, string operation, int nodeNo, DateTime begin, DateTime? end=null)
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
            return $"{End?.ToString(FormatString) ?? Begin.ToString(FormatString)}\t{ThreadNo} i={Iteration} {Operation} {(End.HasValue ? $"(b4operation {Begin.ToString(FormatString)} wait {(End.Value - Begin).TotalMilliseconds}ms)" : string.Empty)}";
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
        static void Main(string[] args)
        {
            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString(LogItem.FormatString));

            var victim = new Dictionary<int, Log>();

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
                if (!victim.ContainsKey(i))
                    continue;

                Console.WriteLine();
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("node[{0}]", i);
                victim[i].WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            victim.Values.SelectMany(i => i._log).Where(i => i.End.HasValue && (i.End.Value-i.Begin).TotalMilliseconds > 0 && !i.Operation.StartsWith("has released node")).OrderBy(i => i.End.Value).ToList().ForEach(Console.WriteLine);

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

                    logItemBeforeLock = new LogItem(taskParam.i, i, $"trying to lock for check node {nodeNo}", nodeNo, dateTimeBeforeLock);
                    Console.WriteLine("{0}\t{1} i={2} trying to lock for check node {3}", dateTimeBeforeLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);
                    lock (taskParam.victim)
                    {
                        dateTimeAfterLock = DateTime.Now;
                        logItemAfterLock = new LogItem(taskParam.i, i, $"has locked for check node {nodeNo} successfully", nodeNo, dateTimeBeforeLock, dateTimeAfterLock);
                        Console.WriteLine("{0}\t{1} i={2} has locked for check node {3} successfully (b4lock {4} wait {5}ms)", dateTimeAfterLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds);

                        LogItem logItemNodeHasBeenAdded = null;

                        if (isNewNode = !taskParam.victim.ContainsKey(nodeNo))
                        {
                            taskParam.victim.Add(nodeNo, new Log());
                            logItemNodeHasBeenAdded = new LogItem(taskParam.i, i, $"node {nodeNo} has been added", nodeNo, DateTime.Now);
                            Console.WriteLine("{0}\t{1} i={2} node {3} has been added", DateTime.Now.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);
                        }

                        taskParam.victim[nodeNo].Append(logItemBeforeLock);
                        taskParam.victim[nodeNo].Append(logItemAfterLock);

                        if (logItemNodeHasBeenAdded != null)
                            taskParam.victim[nodeNo].Append(logItemNodeHasBeenAdded);

                        dateTimeAfterLock = DateTime.Now;
                        taskParam.victim[nodeNo].Append(new LogItem(taskParam.i, i, $"has released for check node {nodeNo} successfully", nodeNo, dateTimeBeforeLock, dateTimeAfterLock));
                        Console.WriteLine("{0}\t{1} i={2} has released for check node {3} successfully (b4lock {4} wait {5}ms)", DateTime.Now.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds);
                    }

                    dateTimeBeforeLock = DateTime.Now;
                    logItemBeforeLock = new LogItem(taskParam.i, i, $"trying to lock node {nodeNo}", nodeNo, dateTimeBeforeLock);
                    Console.WriteLine("{0}\t{1} i={2} trying to lock node {3}", dateTimeBeforeLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo);

                    lock (taskParam.victim[nodeNo])
                    {
                        dateTimeAfterLock = DateTime.Now;
                        var millisecondsTimeoutForLock = taskParam.mSec * rnd.Next(10);
                        taskParam.victim[nodeNo].Append(logItemBeforeLock);
                        taskParam.victim[nodeNo].Append(new LogItem(taskParam.i, i, $"has locked node {nodeNo} successfully (will sleep {millisecondsTimeoutForLock}ms)", nodeNo, dateTimeBeforeLock, dateTimeAfterLock));
                        Console.WriteLine("{0}\t{1} i={2} has locked node {3} successfully (will sleep {6}ms) (b4lock {4} wait {5}ms)", dateTimeAfterLock.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeBeforeLock.ToString(LogItem.FormatString), (dateTimeAfterLock - dateTimeBeforeLock).TotalMilliseconds, millisecondsTimeoutForLock);

                        if (isNewNode)
                        {
                            Foo1(taskParam.victim, nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));
                            Foo2(taskParam.victim, nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));
                        }
                        else
                            Foo2(taskParam.victim, nodeNo, taskParam.mSec, new LogItem(taskParam.i, i, string.Empty, nodeNo, DateTime.Now));

                        Thread.Sleep(millisecondsTimeoutForLock);

                        var tmpDateTime = DateTime.Now;
                        taskParam.victim[nodeNo].Append(new LogItem(taskParam.i, i, $"has released node {nodeNo} successfully", nodeNo, dateTimeAfterLock, tmpDateTime));
                        Console.WriteLine("{0}\t{1} i={2} has released node {3} successfully (b4lock {4} wait {5}ms)", tmpDateTime.ToString(LogItem.FormatString), taskParam.i, i, nodeNo, dateTimeAfterLock.ToString(LogItem.FormatString), (tmpDateTime - dateTimeAfterLock).TotalMilliseconds);
                    }
                }

                Thread.Sleep(millisecondsTimeout);
            }

            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString(LogItem.FormatString), taskParam.i);
        }

        static void Foo1(Dictionary<int, Log> victim, int nodeNo, int mSec, LogItem logItem)
        {
            const string methodName = "Foo2";

            logItem.Begin = DateTime.Now;

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var millisecondsTimeoutForLock = mSec * rnd.Next(10);

            logItem.Operation = $"{methodName}() starting... (will sleep {millisecondsTimeoutForLock}ms)";
            
            Console.WriteLine(logItem);

            Thread.Sleep(millisecondsTimeoutForLock);

            victim[nodeNo].Append(logItem);

            var logItemEnd = new LogItem(logItem);
            logItemEnd.Operation = $"{methodName}() finished";
            logItemEnd.End = DateTime.Now;
            victim[nodeNo].Append(logItemEnd);
            Console.WriteLine(logItemEnd);
        }

        static void Foo2(Dictionary<int, Log> victim, int nodeNo, int mSec, LogItem logItem)
        {
            const string methodName = "Foo2";

            logItem.Begin = DateTime.Now;

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var millisecondsTimeoutForLock = mSec * rnd.Next(10);

            logItem.Operation = $"{methodName}() starting... (will sleep {millisecondsTimeoutForLock}ms)";

            Console.WriteLine(logItem);

            Thread.Sleep(millisecondsTimeoutForLock);

            victim[nodeNo].Append(logItem);

            var logItemEnd = new LogItem(logItem);
            logItemEnd.Operation = $"{methodName}() finished";
            logItemEnd.End = DateTime.Now;
            victim[nodeNo].Append(logItemEnd);
            Console.WriteLine(logItemEnd);
        }
    }
}
