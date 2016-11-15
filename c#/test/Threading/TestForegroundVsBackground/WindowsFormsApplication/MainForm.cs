using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Common;

namespace WindowsFormsApplication
{
	public partial class MainForm : Form
	{
		StreamWriter sw;

		public MainForm()
		{
			InitializeComponent();

			sw = new StreamWriter("main.txt", false, Encoding.UTF8);

			if (!sw.AutoFlush)
				sw.AutoFlush = true;

			sw.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));
		}

		private void ButtonDoItClick(object sender, System.EventArgs e)
		{
			for (int i = 0; i < 2; ++i)
			{
				int
					mSec = 1000;

				StartThread(mSec, i, checkBoxBackground.Checked);
			}
		}

		private void MainFormOnFormClosed(object sender, FormClosedEventArgs e)
		{
			sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
			sw.Close();
		}

		static void StartThread(int mSec, int id, bool IsBackground)
		{
			TestThread TestThread = new TestThread(mSec, id.ToString(), IsBackground);
		}
	}
}
