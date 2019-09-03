using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
            TestDictionary();
            TestConcurrentDictionary();

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

        private static void TestDictionary()
        {
            var dictionary = new Dictionary<int, IEnumerable<string>>();

            try
            {
                Parallel.ForEach(Enumerable.Range(0, 10), item =>
                {
                    //dictionary[item] = GetValue(item, Enumerable.Range(1, 124));
                    dictionary.Add(item, GetValue(item, Enumerable.Range(1, 124)));
                });
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void TestConcurrentDictionary()
        {
            var dictionary = new ConcurrentDictionary<int, IEnumerable<string>>();

            try
            {
                Parallel.ForEach(Enumerable.Range(0, 10), item =>
                {
                    dictionary.TryAdd(item, GetValue(item, Enumerable.Range(1, 124)));
                });
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        private static IEnumerable<string> GetValue(int item, IEnumerable<int> items)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} starting...");

            return items
                .AsParallel()
                .Select(i => GetItemValue(i))
                .Where(i => !string.IsNullOrEmpty(i))
                .Distinct()
                .ToArray();
        }

        private static string GetItemValue(int item)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} starting...");

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(100 * rnd.Next(10));

            return $"{MethodBase.GetCurrentMethod().Name}() ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}";
        }
    }
}
