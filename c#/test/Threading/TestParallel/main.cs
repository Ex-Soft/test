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
        private const int
            OuterMinRange = 0,
            OuterMaxRange = 10,
            InnerMinRange = 0,
            InnerMaxRange = 10,
            msec = 100;

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
                Parallel.ForEach(Enumerable.Range(OuterMinRange, OuterMaxRange), item =>
                {
                    //dictionary[item] = GetValue(item, Enumerable.Range(InnerMinRange, InnerMaxRange));
                    dictionary.Add(item, GetValue(item, Enumerable.Range(InnerMinRange, InnerMaxRange)));
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
                Parallel.ForEach(Enumerable.Range(OuterMinRange, OuterMaxRange), item =>
                {
                    dictionary.TryAdd(item, GetValue(item, Enumerable.Range(InnerMinRange, InnerMaxRange)));
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
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

            return items
                .AsParallel()
                .Select(i => SelectItemValue(i))
                .Where(i => WhereItemValue(i))
                .Distinct()
                .ToArray();
        }

        private static string SelectItemValue(int item)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(msec * rnd.Next(10));

            return $"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}";
        }

        private static bool WhereItemValue(string item)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({item}) ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            return !string.IsNullOrEmpty(item);
        }
    }
}
