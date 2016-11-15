using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

namespace TestServiceIII
{
	class TestThread : IDisposable
	{
		StreamWriter
			file;

		Program.SendPtr
			Send;

		string
			Str;

		long
			NumberOfPostsPerThread;

		int?
			mSec;

		Thread
			Thread;

		bool
			disposed;

		public TestThread(string ThreadName, Program.SendPtr Send, string Str, long NumberOfPostsPerThread, int? mSec)
		{
			this.Send = Send;
			this.Str = Str;
			this.NumberOfPostsPerThread = NumberOfPostsPerThread;
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
			Thread.Start();
		}

		public void run()
		{
			file.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);

			Random
				rnd = new Random(Thread.ManagedThreadId);

			DateTime
				Start,
				Stop;

			TimeSpan
				Diff;

			for (int i = 0; i < NumberOfPostsPerThread; ++i)
			{

				Start=DateTime.Now;
				file.WriteLine("{0}\t{1} i={2} (start...)", Start.ToString("HH:mm:ss.fffffff"), Thread.Name, i);
				Send(Str);
				Stop=DateTime.Now;
				Diff = Stop - Start;
				file.WriteLine("{0}\t{1} i={2} (finished {3} sec)", Stop.ToString("HH:mm:ss.fffffff"), Thread.Name, i, Diff.TotalSeconds);
				if (mSec.HasValue)
					Thread.Sleep(mSec.Value * rnd.Next(10));
			}

			file.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name);
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
						file.Dispose();
				}
				disposed = true;
			}
		}
	}

	class Program
	{
		public delegate void SendPtr(string str);

		static void Main(string[] args)
		{
			if (args.Length == 0)
				Console.WriteLine("Usage: TestServiceIII <NumberOfThreads> <NumberOfPostsPerThread> [Delay]");

			string
				SendStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><message mid=\"511\" nodeId=\"0\"><service>delivery-report</service><status date = \"Tue, 19 Apr 2011 09:12:00 GMT\" >Delivered</status></message>";

			int
				NumberOfThreads = 1;

			long
				NumberOfPostsPerThread = 1;

			int?
				mSec = null;

			if (args.Length >= 1)
			{
				if (!int.TryParse(args[0], out NumberOfThreads))
					NumberOfThreads = 1;
			}

			if (args.Length >= 2)
			{
				if (!long.TryParse(args[1], out NumberOfPostsPerThread))
					NumberOfPostsPerThread = 1;
			}

			if (args.Length >= 3)
			{
				int
					tmpInt;

				mSec = int.TryParse(args[2], out tmpInt) ? (int?)tmpInt : null;
			}

			string
				FileName = "main.txt";

			if (File.Exists(FileName))
				File.Delete(FileName);

			StreamWriter
				sw = new StreamWriter(FileName, false, Encoding.GetEncoding(1251));

			if (!sw.AutoFlush)
				sw.AutoFlush = true;

			List<TestThread>
				list = new List<TestThread>();

			FileName = string.Format("Number of threads: {1}{0}Number of posts per thread: {2}{0}Delay: {3}", Environment.NewLine, NumberOfThreads, NumberOfPostsPerThread, mSec.HasValue ? mSec.Value.ToString() : "null");

			Console.WriteLine(FileName);
			sw.WriteLine(FileName);

			sw.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));
			for (int i = 0; i < NumberOfThreads; ++i)
				list.Add(new TestThread("Thread# " + i, Send, SendStr, NumberOfPostsPerThread, mSec));
			sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
			sw.Close();
		}

		static void Send(string str)
		{
			WebRequest
				request = WebRequest.Create("http://sms.n3.com.ua/smsgateway.asmx/Receive");

			request.ContentType = "text/xml";
			request.Method = "POST";

			request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("sms-user:_KtybyUhfl_")));

			byte[]
				bytes = System.Text.Encoding.UTF8.GetBytes(str);

			request.ContentLength = bytes.Length;

			Stream
				os = request.GetRequestStream();

			os.Write(bytes, 0, bytes.Length);
			os.Close();

			WebResponse
				response = request.GetResponse();

			StreamReader
				sr = new StreamReader(response.GetResponseStream());

			string
				result = sr.ReadToEnd().Trim();
		}
	}
}
