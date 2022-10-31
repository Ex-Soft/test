using System.Runtime.CompilerServices;

namespace AwaitAnything;

public static class Extensions
{
    public static TaskAwaiter GetAwaiter(this Delay delay)
    {
        return Task.Delay(delay.TimeSpan).GetAwaiter();
    }

    public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
    {
        return Task.Delay(timeSpan).GetAwaiter();
    }

    public static TimeSpan Seconds(this int integer)
    {
        return TimeSpan.FromSeconds(integer);
    }

    public static TaskAwaiter GetAwaiter(this int seconds)
    {
        return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
    }
}
