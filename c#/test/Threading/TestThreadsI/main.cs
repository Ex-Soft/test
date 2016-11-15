using System;
using System.Collections.Generic;
using System.Threading;

namespace TestThreadsI
{
	class Program
	{
		public delegate void TestMethod();

		static void Main(string[] args)
		{
			Fn();

			TestMethod
				TestMethodPtr=Fn;

			List<PartThread>
				Threads = new List<PartThread>();

			for (int i = 0; i < 10; ++i)
				Threads.Add(new PartThread(TestMethodPtr, i));

			Console.ReadLine();
		}

		static void Fn()
		{
			Console.WriteLine(string.Format("\"{0}\"\tFn()", Thread.CurrentThread.Name));
		}
	}

	class PartThread
	{
		Program.TestMethod
			TestMethodPtr;

		public Thread
			Thread;

		public PartThread(Program.TestMethod TestMethodPtr, int ThreadNo)
		{
			this.TestMethodPtr = TestMethodPtr;

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = "Thread# " + ThreadNo;
			Thread.Start();
		}

		void run()
		{
			TestMethodPtr();
		}
	}
}
