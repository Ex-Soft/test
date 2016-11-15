using System;
using System.IO;
using System.Text;
using Common;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamWriter
				sw = new StreamWriter("main.txt", false, Encoding.UTF8);

			if (!sw.AutoFlush)
				sw.AutoFlush = true;

			sw.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));

			for (int i = 0; i < 2; ++i)
			{
				int
					mSec = 1000;

				bool
					IsBackground = false;

				StartThread(mSec, i, IsBackground);
			}

			sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
			sw.Close();
		}

		static void StartThread(int mSec, int id, bool IsBackground)
		{
			TestThread
				TestThread = new TestThread(mSec, id.ToString(), IsBackground);
		}
	}
}
