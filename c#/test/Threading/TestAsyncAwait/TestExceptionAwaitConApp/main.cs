//#define THROW_EXCEPTION

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestExceptionAwaitConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Func<Task> fWithException = MethodWithExceptionAsync;
            Func<Task<long>> fWithExceptionAndReturnValueAsync = MethodWithExceptionAndReturnValueAsync;
            Task task;
            Task<long> taskLong;
            long result;

            try
            {
                task = fWithException.Invoke();
                if (task != null)
                {
                    await task;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                taskLong = fWithExceptionAndReturnValueAsync.Invoke();
                if (taskLong != null)
                {
                    result = await taskLong;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                result = await fWithExceptionAndReturnValueAsync.Invoke();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                await Task.Factory.StartNew(() => MethodWithException());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            TaskAwaiter taskAwaiter;
            try
            {
                task = Task.Run(MethodWithException);
                taskAwaiter = task.GetAwaiter();
                taskAwaiter.GetResult();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                taskLong = Task.Run(MethodWithExceptionAndReturnValue);
                result = taskLong.Result;
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                taskLong = Task.Run(MethodWithExceptionAndReturnValue);
                result = await taskLong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        static void MethodWithException()
        {
            #if THROW_EXCEPTION
                throw new Exception("Tadam!!!");
            #endif
        }

        static long MethodWithExceptionAndReturnValue()
        {
            #if THROW_EXCEPTION
                throw new Exception("Tadam!!!");
            #endif
            return DateTime.Now.Ticks;
        }

        static async Task MethodWithExceptionAsync()
        {
            #if THROW_EXCEPTION
                throw new Exception("Tadam!!!");
            #endif
            await Task.CompletedTask;
        }

        static async Task<long> MethodWithExceptionAndReturnValueAsync()
        {
            #if THROW_EXCEPTION
                throw new Exception("Tadam!!!");
            #endif
            return await Task.FromResult(DateTime.Now.Ticks);
        }
    }
}
