using System.Runtime.CompilerServices;

namespace UnderTheHood;

public class CustomAwaiter : INotifyCompletion
{
    public void GetResult()
    {}

    public bool IsCompleted => true;

    public void OnCompleted(Action continuation)
    {}
}

public class CustomAwaitableClass
{
    public CustomAwaiter GetAwaiter()
    {
        return new CustomAwaiter();
    }
}
