//#define USE_TASK_COMPLETION_SOURCE
//#define USE_TASK_FROM_RESULT
//#define USE_TASK_RUN
#define USE_TASK_FACTORY_STARTNEW

using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using static System.Console;

namespace TestAsyncAwaitConApp
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var exitCode = 0;
            if (args.Length != 0)
                int.TryParse(args[0], out exitCode);

            string message;
            Debug.WriteLine(message = $"Main({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            Debug.WriteLine(message = $"Main({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return await DoAsyncWork(exitCode);
        }

        #if USE_TASK_COMPLETION_SOURCE

        static async Task<int> DoAsyncWork(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();
            taskCompletionSource.SetResult(Foo(exitCode));

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return await taskCompletionSource.Task;
        }

        #endif

        #if USE_TASK_FROM_RESULT

        static async Task<int> DoAsyncWork(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return await Task.FromResult(Foo(exitCode));
        }

        #endif

        #if USE_TASK_RUN

        static async Task<int> DoAsyncWork(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return await Task.Run(() => Foo(exitCode));
        }

        #endif
        

        #if USE_TASK_FACTORY_STARTNEW

        static async Task<int> DoAsyncWork(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return await Task<int>.Factory.StartNew(() => Foo(exitCode));
        }

        #endif

        static int Foo(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");
            WriteLine(message);

            Thread.Sleep(5000);

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}) Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
            WriteLine(message);

            return exitCode;
        }
    }
}
