//#define USE_DICTIONARY

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestI
{
    class Program
    {
        #if !USE_DICTIONARY
            static ConcurrentDictionary<string, int> _dictionary = new ConcurrentDictionary<string, int>();
        #else
            static Dictionary<string, int> _dictionary = new Dictionary<string, int>();
        #endif

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(A));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Average: {0}", _dictionary.Values.Average());
            Console.ReadLine();
        }

        static void A()
        {
            for (int i = 0; i < 1000; i++)
            {
                _dictionary.
                    #if !USE_DICTIONARY
                        TryAdd
                    #else
                        Add
                    #endif
                        (i.ToString(), i);
            }
        }
    }
}
