//#define SYNC_BY_MUTEX
#define SYNC_BY_LOCK

using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace WriteToFileSelfSync
{
	class WriterToFile
	{
		public string
			FileName;

		public int
			mSec;

		public Thread
			Thread;

		public WriterToFile(string aFileName, int amSec, string aId)
		{
			FileName=aFileName;
			mSec=amSec;
			Thread=new Thread(new ThreadStart(this.run));
			Thread.Name=aId;
			Thread.Start();
		}
		//---------------------------------------------------------------------------

		public void WriteToFileReally(string FileName, string WriteString, bool Append)
		{
			try
			{
				#if SYNC_BY_MUTEX
					WriteToFileSelfSync.tmpMutex.WaitOne();
				#endif

				if(FileName==null
					|| WriteString==null
					|| (FileName=FileName.Trim())==string.Empty
					|| WriteString.Trim()==string.Empty)
					return;

				StreamWriter
					OutputFile=null;

				#if SYNC_BY_LOCK
					lock(typeof(StreamWriter))
					{
				#endif
				
				OutputFile=new StreamWriter(FileName,Append,System.Text.Encoding.GetEncoding(1251)); // Append ? File.AppendText(FileName) : File.CreateText(FileName);
				if(OutputFile!=null && OutputFile.BaseStream!=null && OutputFile.BaseStream.CanWrite)
				{
					if(!OutputFile.AutoFlush)
						OutputFile.AutoFlush=true;

					if(Append && OutputFile.BaseStream.Position!=0)
						OutputFile.Write(Environment.NewLine);

					OutputFile.Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff")+'\t'+WriteString);
				}

				if(OutputFile!=null)
					OutputFile.Close();

				#if SYNC_BY_LOCK
					}
				#elif SYNC_BY_MUTEX
					WriteToFileSelfSync.tmpMutex.ReleaseMutex();
				#endif
			}
			catch(Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);				
			}
		}
		//---------------------------------------------------------------------------

		public void run()
		{
			try
			{
				WriteToFileReally(FileName,"Thread Id: "+Thread.Name+" started...",true);

				Random
					rnd=new Random(System.AppDomain.GetCurrentThreadId());

				for(int i=0; i<10; ++i)
				{
					WriteToFileReally(FileName,"Thread Id: "+Thread.Name+" i="+i,true);
					Thread.Sleep(mSec*rnd.Next(10));
				}
				WriteToFileReally(FileName,"Thread Id: "+Thread.Name+" finished",true);
			}
			catch(Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);				
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------

	class WriteToFileSelfSync
	{
		#if SYNC_BY_MUTEX
			public static Mutex
				tmpMutex=null;
		#endif

		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Main thread started...");

			if(args.Length<2)
			{
				Console.WriteLine("Main thread  finished (Too few parameters in command line)");
				return;
			}

			int
				ThreadsCount,
				mSec;

			try
			{
				ThreadsCount=Convert.ToInt32(args[0]);
			}
			catch
			{
				Console.WriteLine("Main thread  finished (Invalid threads count)");
				return;
			}

			try
			{
				mSec=Convert.ToInt32(args[1]);
			}
			catch
			{
				Console.WriteLine("Main thread  finished (Invalid mSecond's value)");
				return;
			}

			string
				LogFileName=System.IO.Directory.GetCurrentDirectory();

			LogFileName=LogFileName.Substring(0,LogFileName.LastIndexOf("bin",LogFileName.Length-1))+"log.log";

			if(File.Exists(LogFileName))
				File.Delete(LogFileName);

			ArrayList
				Threads=new ArrayList();

			int
				i;

			#if SYNC_BY_MUTEX
				tmpMutex=new Mutex(false,"TestMutex");
			#endif

			for(i=0; i<ThreadsCount; ++i)
				Threads.Add(new WriterToFile(LogFileName,mSec,"#"+i));

			bool
				IsAlive;

			do
			{
				Console.Write(".");
				Thread.Sleep(mSec);

				IsAlive=false;
				for(i=0; i<Threads.Count; ++i)
					IsAlive|=((WriterToFile)Threads[i]).Thread.IsAlive;

			}while(IsAlive);

			#if SYNC_BY_MUTEX
				tmpMutex.Close();
			#endif
		}
	}
}
