// https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/interop-with-other-asynchronous-patterns-and-types?redirectedfrom=MSDN#from-wait-handles-to-tap
// https://stackoverflow.com/questions/18756354/wrapping-manualresetevent-as-awaitable-task/68632819
// https://blog.stephencleary.com/2012/07/async-interop-with-iasyncresult.html

// https://ask-dev.ru/info/82493/which-blocking-operations-cause-an-sta-thread-to-pump-com-messages
// https://stackoverflow.com/questions/21642381/how-to-wait-for-waithandle-while-serving-wpf-dispatcher-events

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllWinApp
{
    public static class WaitHandleExtensions
    {
        public static Task WaitOneAsync(this WaitHandle waitHandle, CancellationToken cancellationToken, int timeoutMilliseconds = Timeout.Infinite)
        {
            if (waitHandle == null)
                throw new ArgumentNullException(nameof(waitHandle));

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            CancellationTokenRegistration ctr = cancellationToken.Register(() => tcs.SetCanceled());
            TimeSpan timeout = timeoutMilliseconds > Timeout.Infinite ? TimeSpan.FromMilliseconds(timeoutMilliseconds) : Timeout.InfiniteTimeSpan;

            RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(waitHandle,
                (_, timedOut) =>
                {
                    if (timedOut)
                    {
                        tcs.TrySetCanceled();
                    }
                    else
                    {
                        tcs.TrySetResult(true);
                    }
                },
                null, timeout, true);

            Task<bool> task = tcs.Task;

            _ = task.ContinueWith(_ =>
            {
                rwh.Unregister(null);
                return ctr.Unregister();
            }, CancellationToken.None);

            return task;
        }
    }
}
