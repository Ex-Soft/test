#define TEST_THREAD
#define TEST_THREAD_FULL

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace TestThreads
{
	#if TEST_THREAD_FULL
		class TestThreadFull : IDisposable
		{
			StreamWriter
				file;

			int
				mSec;

			Thread
				Thread;

			bool
				disposed;

			public TestThreadFull(int mSec, string ThreadName, bool IsBackground)
			{
				this.mSec = mSec;
				this.disposed = false;

				string
					FileName = "thread_f_" + ThreadName + ".txt";

				if (File.Exists(FileName))
					File.Delete(FileName);

				try
				{
					file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));
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

			~TestThreadFull()
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
						if(file!=null)
							file.Dispose();
					}
					disposed = true;
				}
			}
		}
	#endif

	#if TEST_THREAD
		class TestThread
		{
			StreamWriter
				file;

			int
				mSec;

			Thread
				Thread;

			public TestThread(StreamWriter file, int mSec, string Id, bool IsBackground)
			{
				this.file = file;
				this.mSec = mSec;
				Thread = new Thread(new ThreadStart(this.run));
				Thread.Name = Id;
				Thread.IsBackground = IsBackground;
				Thread.Start();
			}

			public void run()
			{
				if (!file.AutoFlush)
					file.AutoFlush = true;

				file.WriteLine("{0}\tThread Id: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

				Random
					rnd = new Random(Thread.ManagedThreadId);

				for (int i = 0; i < 10; ++i)
				{
					file.WriteLine("{0}\tThread Id: {1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
					Thread.Sleep(mSec * rnd.Next(10));
				}

				file.WriteLine("{0}\tThread Id: {1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

				file.Close();
			}
		}
	#endif

	class Program
	{
		static void Main(string[] args)
		{
			StreamWriter
				sw = new StreamWriter("main.txt", false, Encoding.GetEncoding(1251));

			if (!sw.AutoFlush)
				sw.AutoFlush = true;

			sw.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));

			for (int i = 0; i < 2; ++i)
			{
				int
					mSec = 1000;

				bool
					IsBackground = false;

				#if TEST_THREAD_FULL
					StartThread(mSec, i, IsBackground);
				#endif
				#if TEST_THREAD
					StartThread(new StreamWriter("thread_" + i + ".txt", false, Encoding.GetEncoding(1251)), mSec, i, IsBackground);
				#endif
			}

			sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
			sw.Close();
		}

		#if TEST_THREAD_FULL
			static void StartThread(int mSec, int id, bool IsBackground)
			{
				TestThreadFull
					TestThread = new TestThreadFull(mSec, id.ToString(), IsBackground);
			}
		#endif

		#if TEST_THREAD
			static void StartThread(StreamWriter sw, int mSec, int id, bool IsBackground)
			{
				TestThread
					TestThread = new TestThread(sw, mSec, id.ToString(), IsBackground);
			}
		#endif
	}
}
