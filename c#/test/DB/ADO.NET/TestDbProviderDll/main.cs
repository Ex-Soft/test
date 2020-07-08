using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Threading;

namespace TestDbProviderDll
{
	class AppData
	{
		public int
			ConnectionCount,
			Sec;

		public bool
			TestMultiThread;

		public string
			IniFileName;

		public ArrayList
			SQLs=new ArrayList();

		public AppData(int aConnectionCount, int aSec, bool aTestMultiThread, string aIniFileName)
		{
			ConnectionCount=aConnectionCount;
			Sec=aSec;
			TestMultiThread=aTestMultiThread;
			IniFileName=aIniFileName;
		}

		public AppData(AppData aObj):this(aObj.ConnectionCount,aObj.Sec,aObj.TestMultiThread,aObj.IniFileName)
		{}
		//---------------------------------------------------------------------------

		public AppData():this(int.MinValue,int.MinValue,false,string.Empty)
		{}
		//---------------------------------------------------------------------------

		public void ParseCmdLine(string[] args)
		{
			char
				Separator=':';

			string
				Param;

			int
				SeparatorPos;

			for(int i=0; i<args.Length; ++i)
			{
				Param=args[i];
				if(Param.Length<=1 || Param[0]!='-')
					continue;
				
				Param=Param.Remove(0,1).ToLower();
				
				if((SeparatorPos=Param.IndexOf(Separator))<0)
					continue;

				switch(Param.Substring(0,SeparatorPos))
				{
					case "cnt" :
					{
						try
						{
							ConnectionCount=Convert.ToInt32(Param.Substring(SeparatorPos+1));
						}
						catch
						{
							;
						}
						continue;
					}
					case "sec" :
					{
						try
						{
							Sec=Convert.ToInt32(Param.Substring(SeparatorPos+1));
						}
						catch
						{
							;
						}
						continue;
					}
					case "thrd" :
					{
						TestMultiThread = Param.Substring(SeparatorPos+1)=="true";
						continue;
					}
					case "ini" :
					{
						Param=Param.Substring(SeparatorPos+1);
						if(!Path.IsPathRooted(Param))
							Param=Path.GetFullPath(Directory.GetCurrentDirectory()+Path.DirectorySeparatorChar+Param);
						if(File.Exists(Param))
							IniFileName=Param;
						continue;	
					}
				}
			}
		}
		//---------------------------------------------------------------------------

		public void ReadIniFile()
		{
			if(IniFileName==string.Empty || !File.Exists(IniFileName))
				return;

			StreamReader
				sr=null;

			try
			{
				try
				{
					string
						s,
						MultiLineCommentBegin="/*",
						MultiLineCommentEnd="*/",
						Term="go";

					StringBuilder
						SQLText=new StringBuilder();

					int
						Pos,
						MultiLineCommentPosBegin,
						MultiLineCommentPosEnd;

					char
						Separator;

					bool
						IsMultiLineCommentPresent=false;

					sr=new StreamReader(IniFileName,Encoding.GetEncoding(1251));
					while((s=sr.ReadLine())!=null)
					{
						s=s.Trim();

						if(s==string.Empty
							|| s[0]==';'
							|| s[0]=='#'
							|| (s.Length>=2 && s[0]=='/' && s[1]=='/'))
							continue;

						while((MultiLineCommentPosBegin=s.IndexOf(MultiLineCommentBegin))>=0 && (MultiLineCommentPosEnd=s.IndexOf(MultiLineCommentEnd))>=0 && MultiLineCommentPosEnd>MultiLineCommentPosBegin)
							s=s.Substring(0,MultiLineCommentPosBegin)+s.Substring(MultiLineCommentPosEnd+MultiLineCommentEnd.Length);

						if(IsMultiLineCommentPresent)
						{
							if((MultiLineCommentPosEnd=s.IndexOf(MultiLineCommentEnd))>=0)
							{
								s=s.Substring(MultiLineCommentPosEnd+MultiLineCommentEnd.Length);
								IsMultiLineCommentPresent=false;
							}
							else
								continue;
						}

						if(!IsMultiLineCommentPresent)
						{
							if((MultiLineCommentPosBegin=s.IndexOf(MultiLineCommentBegin))>=0)
							{
								s=s.Substring(0,MultiLineCommentPosBegin);
								IsMultiLineCommentPresent=true;
							}
						}

						Separator=';';
						if(Misc.Misc.DelimiterCount(s,Separator)>0
							&& (s=Misc.Misc.ExtractToken(s,Separator,0))==string.Empty)
							continue;

						Separator='#';
						if(Misc.Misc.DelimiterCount(s,Separator)>0
							&& (s=Misc.Misc.ExtractToken(s,Separator,0))==string.Empty)
							continue;

						if((Pos=s.IndexOf("//"))>=0 && (s=s.Substring(0,Pos))==string.Empty)
							continue;

						s=s.Trim();
						if(s==string.Empty)
							continue;

						if(SQLText.Length!=0)
							SQLText.Append(Environment.NewLine);

						while((Pos=s.ToLower().IndexOf(Term))>=0)
						{
							SQLText.Append(s.Substring(0,Pos).Trim());
							SQLs.Add(SQLText.ToString());
							SQLText.Length=0;
							s=s.Substring(Pos+Term.Length).Trim();
						}

						s=s.Trim();
						if(s==string.Empty)
							continue;

						SQLText.Append(s);
					}
					sr.Close();
					sr=null;

					for(Pos=0; Pos<SQLs.Count; ++Pos)
					{
						s=(string)SQLs[Pos];
						if(s.EndsWith(Environment.NewLine))
							SQLs[Pos]=s.Substring(0,s.Length-Environment.NewLine.Length);
					}
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(sr!=null)
					sr.Close();
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------

	class LogFile
	{
		public StreamWriter
			File;

		public LogFile()
		{
			File=null;
		}

		public void Open(string Prefix)
		{
			string
				LogFileName=string.Empty;

			try
			{
				LogFileName=Directory.GetCurrentDirectory()+Path.DirectorySeparatorChar+"log";
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}

			if(!Directory.Exists(LogFileName))
			{
				try
				{
					Directory.CreateDirectory(LogFileName);
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}

			LogFileName+=Path.DirectorySeparatorChar+Prefix+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".log";

			try
			{
				File=new StreamWriter(LogFileName,false,System.Text.Encoding.GetEncoding(1251));
				if(File==null || File.BaseStream==null || !File.BaseStream.CanWrite)
					throw(new Exception("Can't create log file \""+LogFileName+"\""));

				if(!File.AutoFlush)
					File.AutoFlush=true;
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
		}

		~LogFile()
		{
			if(File!=null)
				File.Close();
		}
	}

	class SybaseConnection
	{
		public int
			Sec;

		public Thread
			Thread;

		public ArrayList
			SQLs;

		public LogFile
			Log=null;

		public SybaseConnection(int aSec, string aId, ArrayList aSQLs)
		{
			Sec=aSec;
			SQLs=aSQLs;
			Log=new LogFile();
			Log.Open("thread_"+aId);
			Thread=new Thread(new ThreadStart(this.run));
			Thread.Name=aId;
			Thread.Start();
		}
		//---------------------------------------------------------------------------

		public void run()
		{
			string
				Message;

			try
			{
				Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Thread Id: "+Thread.Name+" started...";

				lock(Log)
				{
					Log.File.WriteLine(Message);
				}
				Console.WriteLine(Message);

				bill.DbProvider
					DbProvider=new bill.DbProvider();

				object
					tmpObject;

				if((tmpObject=DbProvider.ExecScalar("select count(*) from master..sysprocesses where (suid=1)"))!=null)
				{
					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Thread Id: "+Thread.Name+" processes count: "+Convert.ToInt32(tmpObject);
					if((tmpObject=DbProvider.ExecScalar("select @@spid"))!=null)
						Message+=" (@@SPID="+Convert.ToInt32(tmpObject)+")";
					lock(Log)
					{
						Log.File.WriteLine(Message);
					}
					Console.WriteLine(Message);
				}		

				Thread.Sleep(Sec*1000);

				if(SQLs.Count>0)
				{
					DataTable
						tmpDataTable=new DataTable();

					Random
						rnd=new Random(unchecked((int)DateTime.Now.Ticks)); 

					int
						idx;

					string
						SQLText;

					for(int i=0; i<SQLs.Count; ++i)
					{
						tmpDataTable.Reset();
						
						SQLText=(string)SQLs[idx=rnd.Next(SQLs.Count)];
						
						Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Thread Id: "+Thread.Name+" SQLText["+idx+"]:"+Environment.NewLine+Environment.NewLine+"\""+SQLText+"\""+Environment.NewLine;
						lock(Log)
						{
							Log.File.WriteLine(Message);
						}
						Console.WriteLine(Message);
						
						DbProvider.FillDataTable(SQLText,ref tmpDataTable);
						
						Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Thread Id: "+Thread.Name+" SQLText["+idx+"] done";
						lock(Log)
						{
							Log.File.WriteLine(Message);
						}
						Console.WriteLine(Message);

						Thread.Sleep(1000);
					}
				}

				Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Thread Id: "+Thread.Name+" finished";
				lock(Log)
				{
					Log.File.WriteLine(Message);
				}
				Console.WriteLine(Message);
			}
			catch (OleDbException eException)
			{
				Message=eException.GetType().FullName+Environment.NewLine+"ErrorCode="+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
				lock(Log)
				{
					Log.File.WriteLine(Message);
				}
				Console.WriteLine(Message);
			}
			catch(Exception eException)
			{
				Message=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
				lock(Log)
				{
					Log.File.WriteLine(Message);
				}
				Console.WriteLine(Message);
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------

	class TestDbProviderDll
	{
		[STAThread]
		static void Main(string[] args)
		{
			string
				Message;

			LogFile
				Log=null;

			try
			{
				Log=new LogFile();
				Log.Open("main_thread");

				Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread started...";
				Log.File.WriteLine(Message);
				Console.WriteLine(Message);

				if(args.Length<2)
				{
					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread  finished (Too few parameters in command line)";
					Log.File.WriteLine(Message);
					Console.WriteLine(Message);
					return;
				}

				AppData
					AppData=new AppData();

				AppData.ParseCmdLine(args);

				if(AppData.ConnectionCount==int.MinValue)
				{
					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread  finished (Invalid connection's count)";
					Log.File.WriteLine(Message);
					Console.WriteLine(Message);
					return;
				}
				if(AppData.Sec==int.MinValue)
				{
					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread  finished (Invalid second's value)";
					Log.File.WriteLine(Message);
					Console.WriteLine(Message);
					return;
				}

				AppData.ReadIniFile();

				ArrayList
					Connections=new ArrayList();

				int
					i;

				if(AppData.TestMultiThread)
				{
					for(i=0; i<AppData.ConnectionCount; ++i)
						Connections.Add(new SybaseConnection(AppData.Sec,"#"+i,AppData.SQLs));
			
					bool
						IsAlive;

					do
					{
						Console.Write(".");
						Thread.Sleep(1000);

						IsAlive=false;
						for(i=0; i<Connections.Count; ++i)
							IsAlive|=((SybaseConnection)Connections[i]).Thread.IsAlive;
					}while(IsAlive);

					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"All thread(s) finished";
					Log.File.WriteLine(Message);
					Console.WriteLine(Message);
				}

				bill.DbProvider
					DbProvider;

				object
					tmpObject;

				Connections.Clear();

				for(i=0; i<AppData.ConnectionCount; ++i)
				{
					DbProvider=new bill.DbProvider();

					Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread: connection# "+i+" opened";
					Log.File.Write(Message);
					Console.Write(Message);
						
					Connections.Add(DbProvider);
						
					if((tmpObject=DbProvider.ExecScalar("select count(*) from master..sysprocesses where (suid=1)"))!=null)
					{
						Message=" (processes count: "+Convert.ToInt32(tmpObject)+")";
						if((tmpObject=DbProvider.ExecScalar("select @@spid"))!=null)
							Message+=" (@@SPID="+Convert.ToInt32(tmpObject)+")";
						Log.File.Write(Message);
						Console.Write(Message);
					}
					Message="...";
					Log.File.WriteLine(Message);
					Console.WriteLine(Message);
				}

				for(i=0; i<AppData.Sec; ++i)
				{
					Console.Write(".");
					Thread.Sleep(1000);
				}

				if(AppData.SQLs.Count>0)
				{
					DataTable
						tmpDataTable=new DataTable();

					Random
						rnd=new Random(unchecked((int)DateTime.Now.Ticks)); 

					string
						SQLText;

					int
						idx;

					for(i=0; i<Connections.Count; ++i)
					{
						if((DbProvider=Connections[i] as bill.DbProvider)==null)
							continue;

						for(int s=0; s<AppData.SQLs.Count; ++s)
						{
							tmpDataTable.Reset();

							SQLText=(string)AppData.SQLs[idx=rnd.Next(AppData.SQLs.Count)];

							Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread connection# "+i+" SQLText["+idx+"]:"+Environment.NewLine+Environment.NewLine+"\""+SQLText+"\""+Environment.NewLine;
							Log.File.WriteLine(Message);
							Console.WriteLine(Message);
								
							DbProvider.FillDataTable(SQLText,ref tmpDataTable);

							Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread connection# "+i+" SQLText["+idx+"] done";
							Log.File.WriteLine(Message);
							Console.WriteLine(Message);

							Thread.Sleep(1000);
						}
					}
				}

				Log.File.WriteLine();
				Console.WriteLine();
			}
			catch (OleDbException eException)
			{
				Message=eException.GetType().FullName+Environment.NewLine+"ErrorCode="+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
				Log.File.WriteLine(Message);
				Console.WriteLine(Message);
			}
			catch(Exception eException)
			{
				Message=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
				Log.File.WriteLine(Message);
				Console.WriteLine(Message);
			}

			Message=DateTime.Now.ToString("HH:mm:ss.ffff")+'\t'+"Main thread finished";
			Log.File.WriteLine(Message);
			Console.WriteLine(Message);

			Console.ReadLine();
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}
