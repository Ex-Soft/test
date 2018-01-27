//#define TEST_LIST
//#define TEST_CONTINUE_WITH
//#define TEST_AWAITER
#define TEST_TASK_COMPLETION_SOURCE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Console;

namespace TestTask
{
    class TaskParam
    {
        public int
            i,
            mSec;
    }

    #if TEST_LIST
        class TaskParamWithList
        {
            public IEnumerable<int> List { get; set; }

            public TaskParamWithList(IEnumerable<int> list)
            {
                List = list;
            }

            public TaskParamWithList(TaskParamWithList obj) : this(obj.List)
            {}
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            Task task;

            #if TEST_TASK_COMPLETION_SOURCE

                int tmpInt;
                TaskAwaiter<int> awaiter = TestTaskCompletionSource(5000).GetAwaiter();
                awaiter.OnCompleted(() => tmpInt = awaiter.GetResult());

                tmpInt = TestTaskCompletionSource(10000).Result;

            #endif

            #if TEST_AWAITER
                Task<int> primeNumberTask = Task.Run(() => Enumerable.Range(2, 3000000).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
                var awaiter1 = primeNumberTask.GetAwaiter();
                awaiter1.OnCompleted(() =>
                {
                    int result = awaiter1.GetResult();
                    Console.WriteLine($"primeNumberTask: result = {result}");
                });

                try
                { 
                    task = Task.Run(() => MethodWithException());
                    var awaiter2 = task.GetAwaiter();
                    awaiter2.OnCompleted(() =>
                    {
                        awaiter2.GetResult();
                    });
                }
                catch (AggregateException e)
                {
                    WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                    for (int j = 0; j < e.InnerExceptions.Count; j++)
                    {
                        WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                    }
                }
                catch (Exception eException)
                {
                    WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            #endif

            #if TEST_LIST
                var listOfInt = new List<int>(new int[] {0, 1, 2, 3, 4});
                task = Task.Factory.StartNew(RunWithList, new TaskParamWithList(listOfInt));
                listOfInt.Clear();
                task.Wait();
                task.Dispose();

                listOfInt = new List<int>(new int[] {0, 1, 2, 3, 4});
                task = Task.Factory.StartNew(RunWithList, new TaskParamWithList(listOfInt.ToArray()));
                listOfInt.Clear();
                task.Wait();
                task.Dispose();
            #endif
            
            Action<object> action = Run;

            const int
                threadsMax = 5,
                mSec = 100;

            #if TEST_CONTINUE_WITH
                task = Task.Factory.StartNew(action, new TaskParam { i = 0, mSec = mSec });
                var taskII = task.ContinueWith(t => RunWithResult(new TaskParam { i = 1, mSec = mSec }));
                var taskIII = taskII.ContinueWith(t => RunWithResult(new TaskParam { i = 2, mSec = mSec }));
                //task.Dispose(); // Additional information: A task may only be disposed if it is in a completion state (RanToCompletion, Faulted or Canceled).
                taskIII.Wait();
                if (taskIII.IsCompleted)
                {
                    task.Dispose();

                    if (taskII.Status == TaskStatus.RanToCompletion)
                        Console.WriteLine(taskII.Result);
                    taskII.Dispose();

                    if (taskII.Status == TaskStatus.RanToCompletion)
                        Console.WriteLine(taskIII.Result);
                    taskIII.Dispose();
                }
            #endif

            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            Console.WriteLine("{0}\tSingle Task started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));
            //task = Task.Factory.StartNew(action, new TaskParam { i = 0, mSec = mSec });
            task = Task.Run(() => Run(new TaskParam { i = 0, mSec = mSec }));
            Console.WriteLine("{0}\tSingle Task IsCompleted = {1}", DateTime.Now.ToString("HH:mm:ss.fffffff"), task.IsCompleted);
            task.Wait();
            Console.WriteLine("{0}\tSingle Task IsCompleted = {1}", DateTime.Now.ToString("HH:mm:ss.fffffff"), task.IsCompleted);
            task.Dispose();
            Console.WriteLine("{0}\tSingle Task finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            Task[] tasks = new Task[threadsMax];

            for (int i = 0; i < threadsMax; ++i)
            {
                TaskParam param = new TaskParam { i = i, mSec = mSec };
                tasks[i]=Task.Factory.StartNew(action, param);
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

            Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            OnEnd();

            Console.ReadLine();
        }

        static void Run(object param)
        {
            TaskParam taskParam;

            if ((taskParam = param as TaskParam) == null)
                return;

            Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i);
            
            Random
                rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i, i);
                Thread.Sleep(taskParam.mSec * rnd.Next(10));
            }
            
            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i);
        }

        static void OnEnd()
        {
            Console.WriteLine("{0}\tOnEnd()", DateTime.Now.ToString("HH:mm:ss.fffffff"));   
        }

        static void MethodWithException()
        {
            throw new Exception("Achtung!!!");
        }

        #if TEST_CONTINUE_WITH
            static int RunWithResult(object param)
            {
                TaskParam taskParam;

                if ((taskParam = param as TaskParam) == null)
                    return 0;

                Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i);
            
                Random
                    rnd = new Random(Thread.CurrentThread.ManagedThreadId);

                for (int i = 0; i < 10; ++i)
                {
                    Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i, i);
                    Thread.Sleep(taskParam.mSec * rnd.Next(10));
                }
            
                Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.i);

                return taskParam.i;
            }
        #endif

        #if TEST_LIST
            static void RunWithList(object param)
            {
                var methodName = "RunWithList()";

                TaskParamWithList taskParam;

                if ((taskParam = param as TaskParamWithList) == null)
                    return;

                Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), methodName);
                Thread.Sleep(5000);
                Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), methodName, taskParam.List.Count());
                Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), methodName);
            }
        #endif

        #if TEST_TASK_COMPLETION_SOURCE

            static Task<int> TestTaskCompletionSource(int exitCode)
            {
                string message;
                Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
                WriteLine(message);

                TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();
                System.Timers.Timer timer = new System.Timers.Timer(1000) { AutoReset = false };

                timer.Elapsed += delegate
                {
                    timer.Dispose();

                    string _message_;
                    Debug.WriteLine(_message_ = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} b4 taskCompletionSource.SetResult({exitCode})");
                    WriteLine(_message_);
                    taskCompletionSource.SetResult(exitCode);
                    Debug.WriteLine(_message_ = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} after taskCompletionSource.SetResult({exitCode})");
                    WriteLine(_message_);
                };

                Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} b4 timer.Start()");
                WriteLine(message);
                timer.Start();
                Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} after timer.Start()");
                WriteLine(message);

                Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
                WriteLine(message);

                return taskCompletionSource.Task;
            }

        #endif
    }
}
