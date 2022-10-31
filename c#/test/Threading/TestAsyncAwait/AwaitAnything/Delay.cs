using System.Runtime.CompilerServices;

namespace AwaitAnything;

public class /*struct*/ Delay
{
    public TimeSpan TimeSpan { get; }

    private Delay(TimeSpan timeSpan)
    {
        TimeSpan = timeSpan;
    }

    public static Delay Seconds(int seconds)
    {
        return new Delay(TimeSpan.FromSeconds(seconds));
    }

    //public TaskAwaiter GetAwaiter()
    //{
    //    return Task.Delay(TimeSpan).GetAwaiter();
    //}
}