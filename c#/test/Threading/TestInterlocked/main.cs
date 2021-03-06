﻿using System;
using System.Threading;

namespace TestInterlocked
{
    class Program
    {
        static int _value;
        static long _value1;

        static void Main(string[] args)
        {
            var thread1 = new Thread(Add);
            var thread2 = new Thread(Add);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(_value);

            thread1 = new Thread(IncrementDecrement);
            thread2 = new Thread(IncrementDecrement);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(_value);

            thread1 = new Thread(ExchangeCompareExchangeLong);
            thread1.Start();
            thread1.Join();
            Console.WriteLine(Interlocked.Read(ref _value1));

            Console.ReadLine();
        }

        private static void Add()
        {
            Interlocked.Add(ref _value, 1);
        }

        private static void IncrementDecrement()
        {
            Interlocked.Increment(ref _value);
            Interlocked.Decrement(ref _value);
            Interlocked.Decrement(ref _value);
        }

        private static void ExchangeCompareExchangeLong()
        {
            // Replace value with 10L
            var resultExchange = Interlocked.Exchange(ref _value1, 10L); // resultExchange = 0 _value1 = 10L
            Console.WriteLine($"resultExchange: {resultExchange}");

            // CompareExchange: if _value1 == 10L -> change to 20L
            var resultCompareExchange = Interlocked.CompareExchange(ref _value1, 20L, 10L); // resultExchange = 10L _value1 = 20L
            Console.WriteLine($"resultCompareExchange: {resultCompareExchange}");

            // CompareExchange: if _value1 == 10L -> change to 40L
            resultCompareExchange = Interlocked.CompareExchange(ref _value1, 40L, 10L); // resultExchange = 20L _value1 = 20L
            Console.WriteLine($"resultCompareExchange: {resultCompareExchange}");
        }
    }
}
