using System;
using System.Threading;

namespace TestServiceWithThreads
{
	public class ThreadWithLogger : IDisposable
	{
		bool
			disposed = false;

		public Logger
			Logger = null;

		public Thread
			Thread;

		int
			Count,
			Milliseconds;

		public ThreadWithLogger(int Id, int Count, int Milliseconds)
		{
			this.Count = Count;
			this.Milliseconds = Milliseconds;

			this.Logger = new Logger(Id);

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = "Thread# " + Id;
			Thread.IsBackground = true;
			Thread.Start();
		}

		void run()
		{
			Logger.DoIt(Count, Milliseconds);
		}

		~ThreadWithLogger()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (Logger != null)
					{
						Logger.Dispose();
					}
				}

				disposed = true;
			}
		}
	}
}