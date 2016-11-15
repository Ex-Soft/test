using System;
using System.IO;
using System.Web;
using System.Text;
using System.Threading;

namespace TestServiceWithThreads
{
	public class Logger : IDisposable
	{
		bool
			disposed = false;

		StreamWriter
			OutputFile = null;

		volatile bool
			ShouldStop;

		public Logger(int Id)
		{
			string
				FileName = HttpContext.Current.Server.MapPath(null) + Path.DirectorySeparatorChar + "log# " + Id + ".log";

			if (File.Exists(FileName))
				File.Delete(FileName);

			OutputFile = new StreamWriter(FileName, true, Encoding.GetEncoding(1251));

			if (OutputFile != null && OutputFile.BaseStream != null && OutputFile.BaseStream.CanWrite)
			{
				if (!OutputFile.AutoFlush)
					OutputFile.AutoFlush = true;
			}

			ShouldStop = false;
		}

		public void SetShouldStop()
		{
			ShouldStop = true;
		}

		public void DoIt(int Count, int Milliseconds)
		{
			for (int i = 0; i < Count; ++i)
			{
				if (ShouldStop)
				{
					OutputFile.WriteLine("Terminated");
					break;
				}

				OutputFile.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fffffff tt"));
				Thread.Sleep(Milliseconds);
			}
			OutputFile.WriteLine("Finished");
		}

		~Logger()
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
					if (OutputFile != null)
					{
						OutputFile.Dispose();
					}
				}

				disposed = true;
			}
		}
	}
}