using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestThreadsIII
{
	public partial class MainForm : Form
	{
		public delegate void ThreadFinishedEvent(int Id);

		Dictionary<int, MainThread>
			MainThreads = new Dictionary<int, MainThread>();

		public MainForm()
		{
			InitializeComponent();
		}

		private void ButtonDoIt_Click(object sender, EventArgs e)
		{
			int
				NumberOfMainThreads,
				mSec;

			if (int.TryParse(TextBoxNumberOfMainThreads.Text, out NumberOfMainThreads)
				&& int.TryParse(TextBoxSleep.Text, out mSec))
			{
				ButtonStop.Enabled = !(ButtonDoIt.Enabled = false);
				
				ListBoxMainThreadsLog.Items.Add(string.Format("{0}", MainThreads.Count));

				for (int i = 0; i < NumberOfMainThreads; ++i)
					MainThreads.Add(i, new MainThread(i, mSec, "MainThread# " + i, CheckBoxIsBackground.Checked, ListBoxMainThreadsLog, RemoveThread));
			}
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < MainThreads.Count; ++i)
				if (MainThreads[i].IsAlive)
					MainThreads[i].stop();

			ButtonStop.Enabled = false;
		}

		void RemoveThread(int Id)
		{
			object
				forLock = new object();

			lock (forLock)
			{
				if (MainThreads.ContainsKey(Id))
				{
					string
						Msg = string.Format("Thread# {0} has been removed (IsAlive=\"{1}\", ThreadState=\"{2}\")", Id, MainThreads[Id].IsAlive, MainThreads[Id].ThreadState);

					MainThreads.Remove(Id);

					if (MainThreads.Count == 0)
					{
						if (ButtonStop.InvokeRequired)
							ButtonStop.Invoke(new MethodInvoker(delegate { ButtonStop.Enabled = false; }));
						else
							ButtonStop.Enabled = false;

						if (ButtonDoIt.InvokeRequired)
							ButtonDoIt.Invoke(new MethodInvoker(delegate { ButtonDoIt.Enabled = true; }));
						else
							ButtonDoIt.Enabled = true;
					}

					if (ListBoxMainThreadsLog.InvokeRequired)
						ListBoxMainThreadsLog.Invoke(new MethodInvoker(delegate { ListBoxMainThreadsLog.Items.Add(Msg); }));
					else
						ListBoxMainThreadsLog.Items.Add(Msg);
				}
			}
		}

		private void ButtonShow_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < MainThreads.Count; ++i)
			{
				string
					Msg = string.Format("Thread# {0}: IsAlive=\"{1}\", ThreadState=\"{2}\"", i, MainThreads[i].IsAlive, MainThreads[i].ThreadState);

				if (ListBoxMainThreadsLog.InvokeRequired)
					ListBoxMainThreadsLog.Invoke(new MethodInvoker(delegate { ListBoxMainThreadsLog.Items.Add(Msg); }));
				else
					ListBoxMainThreadsLog.Items.Add(Msg);
			}
		}
	}
}
