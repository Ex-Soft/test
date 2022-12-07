// https://www.codeproject.com/Articles/5274659/How-to-Use-the-Csharp-Await-Keyword-on-Anything
// https://devblogs.microsoft.com/premier-developer/extending-the-async-methods-in-c/

using System.Runtime.CompilerServices;

namespace UnderTheHood;

public struct LazyAwaiter<T> : INotifyCompletion
{
    private readonly Lazy<T> _lazy;

    public LazyAwaiter(Lazy<T> lazy)
    {
        _lazy = lazy;
    }

    public T GetResult()
    {
        return _lazy.Value;
    }

    public bool IsCompleted
    {
        get
        {
            return _lazy.IsValueCreated;
        }
    }

    public void OnCompleted(Action continuation)
    {
        if (null != continuation)
            Task.Run(continuation);
    }
}

public static class LazyAwaiterExtensions
{
    public static LazyAwaiter<T> GetAwaiter<T>(this Lazy<T> lazy)
    {
        return new LazyAwaiter<T>(lazy);
    }
}