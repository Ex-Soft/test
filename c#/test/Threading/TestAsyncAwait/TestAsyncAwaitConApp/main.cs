using System.Diagnostics;
using System.Reflection;

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
            Debug.WriteLine(message = $"Main({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): Before await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            int result = 0;

            switch (exitCode)
            {
                case 0:
                {
                    result = await DoAsyncWorkUseTaskCompletionSource(exitCode);
                    break;
                }
                case 1:
                {
                    result = await DoAsyncWorkUseTaskFromResult(exitCode);
                    break;
                }
                case 2:
                {
                    result = await DoAsyncWorkUseTaskRun(exitCode);
                    break;
                }
                case 3:
                {
                    result = await DoAsyncWorkUseTaskFactoryStartNew(exitCode);
                    break;
                }
            }

            Debug.WriteLine(message = $"Main({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): After await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return result;
        }

        static async Task<int> DoAsyncWorkUseTaskCompletionSource(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"DoAsyncWorkUseTaskCompletionSource({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): Before await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();
            taskCompletionSource.SetResult(Foo(exitCode));

            var result = await taskCompletionSource.Task;

            Debug.WriteLine(message = $"DoAsyncWorkUseTaskCompletionSource({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): After await  Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return result;
        }

        static async Task<int> DoAsyncWorkUseTaskFromResult(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"DoAsyncWorkUseTaskFromResult({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): Before await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            var result = await Task.FromResult(Foo(exitCode));

            Debug.WriteLine(message = $"DoAsyncWorkUseTaskFromResult({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): After await  Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return result;
        }

        static async Task<int> DoAsyncWorkUseTaskRun(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"DoAsyncWorkUseTaskRun({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): Before await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            var result = await Task.Run(() => Foo(exitCode));

            Debug.WriteLine(message = $"DoAsyncWorkUseTaskRun({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): After await  Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return result;
        }

        static async Task<int> DoAsyncWorkUseTaskFactoryStartNew(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"DoAsyncWorkUseTaskFactoryStartNew({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): Before await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            var result = await Task<int>.Factory.StartNew(() => Foo(exitCode));

            Debug.WriteLine(message = $"DoAsyncWorkUseTaskFactoryStartNew({exitCode}) {MethodBase.GetCurrentMethod().Name}({exitCode}): After await Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return result;
        }

        static int Foo(int exitCode)
        {
            string message;
            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}): Before sleep Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            Thread.Sleep(5000);

            Debug.WriteLine(message = $"{MethodBase.GetCurrentMethod().Name}({exitCode}): After sleep Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            WriteLine(message);

            return exitCode;
        }
    }
}
