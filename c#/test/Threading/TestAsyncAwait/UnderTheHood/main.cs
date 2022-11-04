using static System.Console;

namespace UnderTheHood
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CustomAwaitableClass awaitableObject = new CustomAwaitableClass();
            await awaitableObject;

            var lazy = new Lazy<int>(() => 42);
            var result = await lazy;
            WriteLine(result);
        }
    }
}
