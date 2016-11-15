//#define WITH_JOIN

using System;
using System.Collections.Generic;
using System.Threading;

namespace TestThreadsV
{
	class ThreadClass
	{
	    readonly int
			_mSec;

		public Thread
			Thread;

		public ThreadClass(int mSec, int threadNo, bool isBackground)
		{
			_mSec = mSec;

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = "Thread# " + threadNo;
			Thread.IsBackground = isBackground;
			Thread.Start();
		}

		void run()
		{
			Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			Random
				rnd = new Random(Thread.ManagedThreadId);

			for (int i = 0; i < 10; ++i)
			{
				Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
				Thread.Sleep(_mSec * rnd.Next(10));
			}

			Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));

			Dictionary<int, ThreadClass>
				threads = new Dictionary<int, ThreadClass>();

			int
				threadsMax = 5,
				mSec = 100;

			bool
				isBackground = false;

			for (int i = 0; i < threadsMax; ++i)
				threads.Add(i, new ThreadClass(mSec, i, isBackground));

			#if WITH_JOIN
				for (int i = 0; i < threads.Count; ++i)
					threads[i].Thread.Join();
			#endif

			Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            OnEnd();
		}

        static void OnEnd()
        {
            Console.WriteLine("{0}\tOnEnd()", DateTime.Now.ToString("HH:mm:ss.fffffff"));
        }
	}
}
