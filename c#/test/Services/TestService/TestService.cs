using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
namespace TestService
{
	public partial class TestService : ServiceBase
	{
		Timer
			_t = null;

		public TestService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestService";
			tmpEventLog.WriteEntry("TestService.OnStart()", EventLogEntryType.Information);

			_t = new Timer(WriteToEventLog, null, 0, 5000);
		}

		protected override void OnStop()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestService";
			tmpEventLog.WriteEntry("TestService.OnStop()", EventLogEntryType.Information);

			_t.Dispose();
		}

		void WriteToEventLog(object state)
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestService";
			tmpEventLog.WriteEntry("TestService.WriteToEventLog()", EventLogEntryType.Information);
		}
	}
}
