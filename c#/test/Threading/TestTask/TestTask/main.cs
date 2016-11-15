//#define TEST_LIST
#define TEST_CONTINUE_WITH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

            task = Task.Factory.StartNew(action, new TaskParam { i = 0, mSec = mSec });
            task.Wait();
            task.Dispose();

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
    }
}
