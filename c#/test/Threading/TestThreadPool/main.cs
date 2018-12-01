#define TEST_THREAD_POOL
#define TEST_THREAD_POOL_FULL

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace TestThreadPool
{
	#if TEST_THREAD_POOL_FULL
		class TestThreadPoolFull
		{
			StreamWriter
				file;

			int
				mSec;

			string
				Id;

			bool
				disposed;

			public TestThreadPoolFull(int mSec, string Id)
			{
				this.mSec = mSec;
				this.Id = Id;
				this.disposed = false;

				string
					FileName = "thread_f_" + Id + ".txt";

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
			}

			public void run()
			{
				file.WriteLine("{0}\tThread Id: {1} Thread.ManagedThreadId: {2} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId);

				Random
					rnd = new Random(Thread.CurrentThread.ManagedThreadId);

				for (int i = 0; i < 10; ++i)
				{
					file.WriteLine("{0}\tThread Id: {1} Thread.ManagedThreadId: {2} i={3}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId, i);
					Thread.Sleep(mSec * rnd.Next(10));
				}

				file.WriteLine("{0}\tThread Id: {1} Thread.ManagedThreadId: {2} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId);
			}

			~TestThreadPoolFull()
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

	#if TEST_THREAD_POOL
		class TestThreadPool
		{
			StreamWriter
				file;

			int
				mSec;

			string
				Id;

			public TestThreadPool(StreamWriter file, int mSec, string Id)
			{
				this.file = file;
				this.mSec = mSec;
				this.Id = Id;
			}

			public void run()
			{
				if (!file.AutoFlush)
					file.AutoFlush = true;

				file.WriteLine("{0}\tThreadPool Id: {1} Thread.ManagedThreadId: {2} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId);

				Random
					rnd = new Random(Thread.CurrentThread.ManagedThreadId);

				for (int i = 0; i < 10; ++i)
				{
					file.WriteLine("{0}\tThreadPool Id: {1} Thread.ManagedThreadId: {2} i={3}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId, i);
					Thread.Sleep(mSec * rnd.Next(10));
				}

				file.WriteLine("{0}\tThreadPool Id: {1} Thread.ManagedThreadId: {2} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Id, Thread.CurrentThread.ManagedThreadId);

				file.Close();
			}
		}
	#endif

	class _State_
	{
		virtual public int mSec { get; set; }
		virtual public string i { get; set; }

		public _State_(int mSec, string i)
		{
			this.mSec = mSec;
			this.i = i;
		}
	}

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
				_State_
					state = new _State_(1000, i.ToString());

				ThreadPool.QueueUserWorkItem(StartThread, state);
			}

			sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
		}

		static void StartThread(object state)
		{
			#if TEST_THREAD_POOL_FULL
				TestThreadPoolFull
					TestThreadPoolFull = new TestThreadPoolFull(((_State_)state).mSec, ((_State_)state).i);

				TestThreadPoolFull.run();
			#endif

			#if TEST_THREAD_POOL
				TestThreadPool
					TestThreadPool = new TestThreadPool(new StreamWriter("thread_" + ((_State_)state).i + ".txt", false, Encoding.GetEncoding(1251)), ((_State_)state).mSec, ((_State_)state).i);

				TestThreadPool.run();
			#endif
		}
	}
}
