using System;
using System.Threading;

namespace TestAutoResetEvent
{
    class Program
    {
        const bool Event1InSignaledState = false;

        static readonly AutoResetEvent
            Event1 = new AutoResetEvent(Event1InSignaledState),
            Event2 = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                          "The threads wait on AutoResetEvent #1, which was created\r\n" +
                          "in the signaled state, so the first thread is released.\r\n" +
                          "This puts AutoResetEvent #1 into the unsignaled state.");
            Console.ReadLine();

            const int maxThreads = 3;

            for (int i = 0; i < maxThreads; i++)
            {
                var t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
                Console.WriteLine("Thrad {0} has started.", t.Name);
            }
            Thread.Sleep(250);

            for (int i = 0; i < (maxThreads - (Event1InSignaledState ? 1 : 0)); i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                Event1.Set();
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < maxThreads; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine();
                Event2.Set();
                Thread.Sleep(250);
            }

            Console.ReadLine();
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
            Event1.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            Event2.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }
    }
}
