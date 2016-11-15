using System.Timers;

namespace TestService
{
	public class TestService : System.ServiceProcess.ServiceBase
	{
		private System.ComponentModel.Container components = null;

		Timer
			Timer1;

		public TestService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			Timer1=new Timer();
			Timer1.Interval=1000;
			Timer1.Elapsed+=new ElapsedEventHandler(Timer1_Elapsed);
			Timer1.AutoReset=true;
		}

		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new TestService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// TestService
			// 
			this.ServiceName = "TestService";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: Add code here to start your service.
			Log.Log.WriteToLog("OnStart()",false);
			Log.Log.WriteToLog("Timer1.Start()",true);
			Timer1.Start();
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
			Log.Log.WriteToLog("OnStop()",true);
			Log.Log.WriteToLog("Timer1.Stop()",true);
			Timer1.Stop();
		}

		private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
		{
			Log.Log.WriteToLog("Timer1_Elapsed",true);
		}
	}
}