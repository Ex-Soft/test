using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace TestThreadsIV
{
	class MainThread : IDisposable
	{
		int
			Id,
			mSec,
			NumberOfChildThreads;

		string
			ThreadName;

		ListBox
			ListBoxMainThreadLog,
			ListBoxChildThreadLog;

		MainForm.ThreadFinishedEvent
			callback;

		Thread
			Thread;

		bool
			disposed;

		Dictionary<int, ChildThread>
			ChildThreads;

		public MainThread(int Id, int mSec, string ThreadName, bool IsBackground, ListBox ListBoxMainThreadLog, int NumberOfChildThreads, ListBox ListBoxChildThreadLog, MainForm.ThreadFinishedEvent callback)
		{
			this.Id = Id;
			this.mSec = mSec;
			this.ThreadName = ThreadName;
			this.ListBoxMainThreadLog = ListBoxMainThreadLog;
			this.NumberOfChildThreads = NumberOfChildThreads;
			this.ListBoxChildThreadLog = ListBoxChildThreadLog;
			this.callback = callback;

			ChildThreads = new Dictionary<int, ChildThread>();

			disposed = false;

			Thread = new Thread(new ThreadStart(this.run));
			Thread.Name = ThreadName;
			Thread.IsBackground = IsBackground;
			Thread.Start();
		}

		public void run()
		{
			string
				Msg = string.Format("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			if (ListBoxMainThreadLog.InvokeRequired)
				ListBoxMainThreadLog.Invoke(new MethodInvoker(delegate { ListBoxMainThreadLog.Items.Add(Msg); }));
			else
				ListBoxMainThreadLog.Items.Add(Msg);

			for (int i = 0; i < NumberOfChildThreads; ++i)
				ChildThreads.Add(i, new ChildThread(i, mSec, Thread.Name + " ChildThread# " + i, Thread.IsBackground, ListBoxChildThreadLog));

			for (int i = 0; i < ChildThreads.Count; ++i)
				ChildThreads[i].Thread.Join();

			Msg = string.Format("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
			if (ListBoxMainThreadLog.InvokeRequired)
				ListBoxMainThreadLog.Invoke(new MethodInvoker(delegate { ListBoxMainThreadLog.Items.Add(Msg); }));
			else
				ListBoxMainThreadLog.Items.Add(Msg);

			if (callback != null)
				callback(Id);
		}

		public void stop()
		{
			string
				Msg = string.Format("{0}\t{1} got a stop signal", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			if (ListBoxMainThreadLog.InvokeRequired)
				ListBoxMainThreadLog.Invoke(new MethodInvoker(delegate { ListBoxMainThreadLog.Items.Add(Msg); }));
			else
				ListBoxMainThreadLog.Items.Add(Msg);

			for (int i = 0; i < ChildThreads.Count; ++i)
				ChildThreads[i].stop();
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
