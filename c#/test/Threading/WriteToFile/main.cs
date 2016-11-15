using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;

namespace WriteToFile
{
	class WriterToFile
	{
		TextWriter
			file;

		public int
			mSec;

		public Thread
			Thread;

		public WriterToFile(TextWriter aFile, int amSec, string aId)
		{
			file=aFile;
			mSec=amSec;
			Thread=new Thread(new ThreadStart(this.run));
			Thread.Name=aId;
			Thread.Start();
		}

		public void run()
		{
			file.WriteLine("Thread Id: "+Thread.Name+" started...");

			Random
				rnd=new Random(System.AppDomain.GetCurrentThreadId());

			for(int i=0; i<10; ++i)
			{
				file.WriteLine("Thread Id: "+Thread.Name+" i="+i);
				Thread.Sleep(mSec*rnd.Next(10));
			}
			file.WriteLine("Thread Id: "+Thread.Name+" finished");
		}
	}

	class WriteToFile
	{
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
				LogFileName="test.txt";

			StreamWriter 
				sw=new StreamWriter(LogFileName,false,Encoding.GetEncoding(1251));
			
			if(sw==null || sw.BaseStream==null || !sw.BaseStream.CanWrite)
			{
				Console.WriteLine("Can't create log file \""+LogFileName+"\"");
			}

			if(!sw.AutoFlush)
				sw.AutoFlush=true;

			TextWriter
				file=TextWriter.Synchronized(sw);

			ArrayList
				Threads=new ArrayList();

			int
				i;

			for(i=0; i<ThreadsCount; ++i)
				Threads.Add(new WriterToFile(file,mSec,"#"+i));

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

			file.Close();
		}
	}
}