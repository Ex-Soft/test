using System;
using System.Threading;
using System.Windows.Forms;

namespace TestThreadsIII
{
	class MainThread : IDisposable
	{
		int
			Id,
			mSec;

		string
			ThreadName;

		ListBox
			ListBoxLog;

		MainForm.ThreadFinishedEvent
			callback;

		Thread
			Thread;

		bool
			IsStop,
			disposed;

		public MainThread(int Id, int mSec, string ThreadName, bool IsBackground, ListBox ListBoxLog, MainForm.ThreadFinishedEvent callback)
		{
			this.Id = Id;
			this.mSec = mSec;
			this.ThreadName = ThreadName;
			this.ListBoxLog = ListBoxLog;
			this.callback = callback;

			this.IsStop = false;

			this.disposed = false;

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = ThreadName;
			Thread.IsBackground = IsBackground;
			Thread.Start();
		}

		public void run()
		{
			string
				Msg = string.Format("{0}\tThread Id: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			if (ListBoxLog.InvokeRequired)
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(Msg); }));
			else
				ListBoxLog.Items.Add(Msg);

			Random
				rnd = new Random(Thread.ManagedThreadId);

			for (int i = 0; i < 10; ++i)
			{
				if (IsStop)
					break;

				Msg = string.Format("{0}\tThread Id: {1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
				if (ListBoxLog.InvokeRequired)
					ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(Msg); }));
				else
					ListBoxLog.Items.Add(Msg);

				Thread.Sleep(mSec * rnd.Next(10));
			}

			Msg = string.Format("{0}\tThread Id: {1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
			if (ListBoxLog.InvokeRequired)
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(Msg); }));
			else
				ListBoxLog.Items.Add(Msg);

			if (callback != null)
				callback(Id);
		}

		public void stop()
		{
			string
				Msg = string.Format("{0}\tThread Id: {1} got a stop signal", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			if (ListBoxLog.InvokeRequired)
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(Msg); }));
			else
				ListBoxLog.Items.Add(Msg);

			IsStop = true;
		}

		public bool IsAlive
		{
			get
			{
				return Thread.IsAlive;
			}
		}

		public ThreadState ThreadState
		{
			get
			{
				return Thread.ThreadState;
			}
		}

		~MainThread()
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
					/*if (file != null)
						file.Dispose();*/
				}
				disposed = true;
			}
		}
	}
}
