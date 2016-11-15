//#define WAIT_FOR_EXIT
//#define TEST_BCP
using System;
using System.Diagnostics;
using System.IO;

namespace Exec_Test
{
	class Exec_Test
	{
		[STAThread]
		static void Main(string[] args)
		{
			Process
				App;

			#if TEST_BCP
				App=new Process();
				App.StartInfo.FileName="bcp.exe";
				App.StartInfo.Arguments="veksel.dbo.param out e:\\1.txt -SNOZHENKO -Usa -P -c";
				try
				{
					if(App.Start())
					{
						App.WaitForExit();
						Console.WriteLine("App.ExitCode="+App.ExitCode.ToString());
						App.Close();
					}
				}
				catch(Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);				
				}
			#endif

			if(args.Length==0)
				return;

			App=new Process();
			App.StartInfo.FileName=Path.GetFileName(args[0]);
			App.StartInfo.WorkingDirectory=Path.GetDirectoryName(args[0]);
			App.StartInfo.WindowStyle=ProcessWindowStyle.Hidden;
			App.EnableRaisingEvents=true;
			App.Exited+=new EventHandler(App_Exited);
			
			try
			{
				if(App.Start())
				{
					Console.WriteLine("App.BasePriority="+App.BasePriority.ToString());
					Console.WriteLine("App.Handle="+App.Handle.ToString());
					Console.WriteLine("App.Id="+App.Id.ToString());
					Console.WriteLine("App.MachineName="+App.MachineName);
					Console.WriteLine("App.MainWindowTitle="+App.MainWindowTitle);
					Console.WriteLine("App.ProcessName="+App.ProcessName);
					Console.WriteLine();
					#if WAIT_FOR_EXIT
						App.WaitForExit();
						Console.WriteLine("App.ExitCode="+App.ExitCode.ToString());
						App.Close();
					#else
						string[]
							ProcessNames=new string[]{Process.GetCurrentProcess().ProcessName,App.ProcessName,"Explorer"};

						Process[]
							ProcessList;

						for(int i=0; i<ProcessNames.Length; ++i)
						{
							ProcessList=Process.GetProcessesByName(ProcessNames[i]);

							for(int ii=0; ii<ProcessList.Length; ++ii)
							{
								Console.WriteLine("ProcessList["+ii+"].BasePriority="+ProcessList[ii].BasePriority.ToString());
								Console.WriteLine("ProcessList["+ii+"].Handle="+ProcessList[ii].Handle.ToString());
								Console.WriteLine("ProcessList["+ii+"].Id="+ProcessList[ii].Id.ToString());
								Console.WriteLine("ProcessList["+ii+"].MachineName="+ProcessList[ii].MachineName);
								Console.WriteLine("ProcessList["+ii+"].MainWindowTitle="+ProcessList[ii].MainWindowTitle);
								Console.WriteLine("ProcessList["+ii+"].ProcessName="+ProcessList[ii].ProcessName);
								Console.WriteLine();
							}
							Console.WriteLine();
						}

						App.Kill();
						Console.WriteLine("App_Exited(): App.ExitCode="+App.ExitCode.ToString());
					#endif
				}
				else
				{
					throw new Exception(App.ExitCode.ToString());
				}
			}
			catch(Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);				
			}
		}
		
		private static void App_Exited(object sender, EventArgs e)
		{
			Process
				App;

			if((App=sender as Process)==null)
				return;

			Console.WriteLine("\tApp_Exited(): App.ExitCode="+App.ExitCode.ToString());
		}
		
	}
}
