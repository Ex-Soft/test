#define TEST_TIMER
using System;
using System.Threading;

namespace TestLoop
{
	class TestLoop
	{
		#if TEST_TIMER
			static int
				Count=0;
		#endif

		[STAThread]
		public static void Main(string[] args)
		{
			const int
					  Max=10;

			#if TEST_TIMER
				System.Timers.Timer
					Timer1=new System.Timers.Timer();

				Timer1.Interval=1000;
				//Timer1.AutoReset=false;
				Timer1.AutoReset=true;
				Timer1.Elapsed+=new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
				Console.WriteLine("Timer1.Start(): "+DateTime.Now.ToString("hh:mm:ss.fffffff tt"));
				Timer1.Start(); // EQU Timer1.Enabled=true;
			#endif

			while(true)
			{
				if(args.Length>0)
					Thread.Sleep(1000);

				#if TEST_TIMER
					if(Count>Max-1)
					{
						Count=0;
						Timer1.Stop(); // EQU Timer1.Enabled=false;
						Console.WriteLine("Timer1.Stop(): "+DateTime.Now.ToString("hh:mm:ss.fffffff tt"));
						Console.Write("Enter...");
						Console.ReadLine();
						return;
					}
				#endif
			}
		}

		#if TEST_TIMER
		private static void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Console.WriteLine(Count+++" Timer1_Elapsed: System.Timers.ElapsedEventArgs.SignalTime=\""+e.SignalTime.ToString("hh:mm:ss.fffffff tt")+"\"");
		}
		#endif
	}
}