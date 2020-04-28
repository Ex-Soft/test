using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace UnderTheHood
{
    public class MyAwaitableClass
    {
        public MyAwaiter GetAwaiter()
        {
            return new MyAwaiter();
        }
    }

    public class MyAwaiter : INotifyCompletion
    {
        public void GetResult()
        {

        }

        public bool IsCompleted
        {
            get { return false; }
        }

        public void OnCompleted(Action continuation)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        static async Task AwaitMyAwaitable()
        {
            MyAwaitableClass awaitableObject = new MyAwaitableClass();

            await awaitableObject;
        }

        static async Task FooAsync()
        {

        }
    }
}
