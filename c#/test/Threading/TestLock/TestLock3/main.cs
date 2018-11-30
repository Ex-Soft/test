using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TestLock3
{
    class BlockingQueue<T>
    {
        readonly int _Size = 0;
        readonly Queue<T> _Queue = new Queue<T>();
        readonly object _Key = new object();
        bool _Quit = false;

        public BlockingQueue(int size)
        {
            _Size = size;
        }

        public void Quit()
        {
            lock (_Key)
            {
                _Quit = true;

                Monitor.PulseAll(_Key);
            }
        }

        public bool Enqueue(T t)
        {
            lock (_Key)
            {
                while (!_Quit && _Queue.Count >= _Size) Monitor.Wait(_Key);

                if (_Quit) return false;

                _Queue.Enqueue(t);

                Monitor.PulseAll(_Key);
            }

            return true;
        }

        public bool Dequeue(out T t)
        {
            t = default(T);

            lock (_Key)
            {
                while (!_Quit && _Queue.Count == 0) Monitor.Wait(_Key);

                if (_Queue.Count == 0) return false;

                t = _Queue.Dequeue();

                Monitor.PulseAll(_Key);
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Test(); // https://www.codeproject.com/Articles/28785/Thread-synchronization-Wait-and-Pulse-demystified

            object sync = new object();
            var thread = new Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    Debug.WriteLine("b4 inner lock (sync)");
                    lock (sync)
                    {
                        Debug.WriteLine("b4 Monitor.PulseAll(sync)");
                        Monitor.PulseAll(sync);
                        Debug.WriteLine("after Monitor.PulseAll(sync)");
                    }
                }
            });

            thread.Start();

            Debug.WriteLine("b4 lock (sync)");
            lock (sync)
            {
                Debug.WriteLine("b4 Monitor.Wait(sync)");
                //Work();
                var result = Monitor.Wait(sync);
                Debug.WriteLine($"after Monitor.Wait(sync) {result}");
            }
            Debug.WriteLine("test");
        }

        private static void Work()
        {
            Thread.Sleep(1000);
        }

        private static void Test()
        {
            var q = new BlockingQueue<int>(4);

            // Producer
            new Thread(() =>
            {
                for (int x = 0; ; x++)
                {
                    if (!q.Enqueue(x)) break;
                    Trace.WriteLine(x.ToString("0000") + " >");
                }
                Trace.WriteLine("Producer quitting");
            }).Start();

            // Consumers
            for (int i = 0; i < 2; i++)
            {
                new Thread(() =>
                {
                    for (; ; )
                    {
                        Thread.Sleep(100);
                        int x = 0;
                        if (!q.Dequeue(out x)) break;
                        Trace.WriteLine("     < " + x.ToString("0000"));
                    }
                    Trace.WriteLine("Consumer quitting");
                }).Start();
            }

            Thread.Sleep(1000);

            Trace.WriteLine("Quitting");

            q.Quit();
        }
    }
}
