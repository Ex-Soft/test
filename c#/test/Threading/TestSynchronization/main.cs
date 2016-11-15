using System;
using System.Collections.Generic;
using System.Threading;

namespace TestSynchronization
{
    class Victim
    {
        public void Foo(object data)
        {
            Random rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(100 * rnd.Next(10));

            List<string> list = new List<string>();

            Thread.Sleep(100 * rnd.Next(10));

            for (int i = 0; i < 5; ++i)
            {
                list.Add(i.ToString());
                Thread.Sleep(100 * rnd.Next(10));

                Console.WriteLine("ManagedThreadId={0}, Name={1}, data={2}, Count={3}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name, data, list.Count);
                Thread.Sleep(100 * rnd.Next(10));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int maxThread = 3;

            Victim victim = new Victim();
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < maxThread; ++i)
            {
                Thread thread = new Thread(victim.Foo);
                thread.Name = string.Format("Thread#{0}", i);
                threads.Add(thread);
                thread.Start(i);
            }

            Console.ReadLine();
        }
    }
}
