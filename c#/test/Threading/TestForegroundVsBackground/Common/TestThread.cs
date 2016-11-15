using System;
using System.IO;
using System.Threading;

namespace Common
{
	class TestThread : IDisposable
	{
		StreamWriter
			file;

		int
			mSec;

		Thread
			Thread;

		bool
			disposed;

		public TestThread(int mSec, string ThreadName, bool IsBackground)
		{
			this.mSec = mSec;
			this.disposed = false;

			string
				FileName = "thread_f_" + ThreadName + ".txt";

			if (File.Exists(FileName))
				File.Delete(FileName);

			try
			{
				file = new StreamWriter(FileName, true, System.Text.Encoding.UTF8);
			}
			catch
			{
				GC.SuppressFinalize(this);
				throw;
			}

			if (!file.AutoFlush)
				file.AutoFlush = true;

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = ThreadName;
			Thread.IsBackground = IsBackground;
			Thread.Start();
		}

		public void run()
		{
			file.WriteLine("{0}\tThread Id: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			Random
				rnd = new Random(Thread.ManagedThreadId);

			for (int i = 0; i < 10; ++i)
			{
				file.WriteLine("{0}\tThread Id: {1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
				Thread.Sleep(mSec * rnd.Next(10));
			}

			file.WriteLine("{0}\tThread Id: {1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
		}

		~TestThread()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (file != null)
					{
						file.Flush();
						file.Close();
						file.Dispose();
					}
				}
				disposed = true;
			}
		}
	}
}
