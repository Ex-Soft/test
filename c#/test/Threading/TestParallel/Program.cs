using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TestParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} starting...");

            var data = new[]
            {
                new[] {1, 2, 3, 4, 5},
                new[] {10, 20, 30, 40, 50},
                new[] {100, 200, 300, 400, 500},
            };

            var result = Parallel.ForEach(data, Body);

            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} finished");
        }

        private static void Body(int[] ints, ParallelLoopState parallelLoopState, long arg3)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} starting...");
            var sum = ints.Sum();
            Thread.Sleep(5000);
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} finished");
        }
    }
}
