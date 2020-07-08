using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace TestConnectionPool
{
	class SybaseConnection
	{
		OleDbConnection
			cn=null;

		OleDbCommand
			cmd=null;

		public int
			Sec;

		public Thread
			Thread;

		public SybaseConnection(int aSec, string aId)
		{
			Sec=aSec;
			Thread=new Thread(new ThreadStart(this.run));
			Thread.Name=aId;
			Thread.Start();
		}

		public void run()
		{
			try
			{
				try
				{
					Console.WriteLine("Thread Id: "+Thread.Name+" started...");

					string
						ConnectionString;

					if((ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"])==null)
					{
						Console.WriteLine("Thread Id: "+Thread.Name+" finished (ConfigurationSettings.AppSettings[\"ConnectionString\"] is empty)");
						return;
					}

					cn=new OleDbConnection(ConnectionString);
					cn.Open();
					cmd=new OleDbCommand("select count(*) from master..sysprocesses where (suid=1)",cn);

					object
						tmpObject;

					if((tmpObject=cmd.ExecuteScalar())!=null)
						Console.WriteLine("Thread Id: "+Thread.Name+" processes count: "+Convert.ToInt32(tmpObject));
						
					Thread.Sleep(Sec*1000);
					cn.Close();
					cn=null;

					Console.WriteLine("Thread Id: "+Thread.Name+" finished");
				}
				catch (OleDbException eException)
				{
					Console.WriteLine("ErrorCode="+eException.ErrorCode.ToString()+"\nMessage: "+eException.Message+"\nSource: "+eException.Source+"\nStackTrace: "+eException.StackTrace+"\nTargetSite: "+eException.TargetSite);
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}			
			}
			finally
			{
				if(cn!=null && cn.State==ConnectionState.Open)
					cn.Close();
			}
		}
	}

	class TestConnectionPool
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
				ConnectionCount,
				Sec;

			try
			{
				ConnectionCount=Convert.ToInt32(args[0]);
			}
			catch
			{
				Console.WriteLine("Main thread  finished (Invalid connection's count)");
				return;
			}

			try
			{
				Sec=Convert.ToInt32(args[1]);
			}
			catch
			{
				Console.WriteLine("Main thread  finished (Invalid second's value)");
				return;
			}

			bool
				TestMultiThread=args.Length>=3;

			ArrayList
				Connections=new ArrayList();

			int
				i;

			if(TestMultiThread)
			{
				for(i=0; i<ConnectionCount; ++i)
					Connections.Add(new SybaseConnection(Sec,"#"+i));
			
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

				Console.WriteLine("All thread finished");
			}

			string
				ConnectionString;

			if((ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"])==null)
			{
				Console.WriteLine("Main thread finished (ConfigurationSettings.AppSettings[\"ConnectionString\"] is empty)");
				return;
			}

			Connections.Clear();

			OleDbConnection
				cn;

			OleDbCommand
				cmd=new OleDbCommand();

			cmd.CommandType=CommandType.Text;
			cmd.CommandText="select count(*) from master..sysprocesses where (suid=1)";

			object
				tmpObject;

			try
			{
				try
				{
					for(i=0; i<ConnectionCount; ++i)
					{
						cn=new OleDbConnection(ConnectionString);
						cn.Open();
						Console.Write("Main thread: connection# "+i+" opened");
						Connections.Add(cn);
						cmd.Connection=cn;
						if((tmpObject=cmd.ExecuteScalar())!=null)
							Console.Write(" (processes count: "+Convert.ToInt32(tmpObject)+")");
						Console.WriteLine("...");
					}
					Thread.Sleep(Sec*1000);
					for(i=0; i<Connections.Count; ++i)
					{
						cn=Connections[i] as OleDbConnection;
						if(cn!=null && cn.State==ConnectionState.Open)
						{
							cn.Close();
							Console.WriteLine("Main thread: connection# "+i+" closed...");
						}
					}
				}
				catch (OleDbException eException)
				{
					Console.WriteLine("ErrorCode="+eException.ErrorCode.ToString()+"\nMessage: "+eException.Message+"\nSource: "+eException.Source+"\nStackTrace: "+eException.StackTrace+"\nTargetSite: "+eException.TargetSite);
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}			
			}	
			finally
			{
				for(i=0; i<Connections.Count; ++i)
				{
					cn=Connections[i] as OleDbConnection;
					if(cn!=null && cn.State==ConnectionState.Open)
					{
						cn.Close();
						Console.WriteLine("Main thread: connection# "+i+" closed...");
					}
				}
			}

			Console.WriteLine("Main thread finished");
			Console.ReadLine();
		}
	}
}