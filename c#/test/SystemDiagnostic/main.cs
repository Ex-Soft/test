// http://support.microsoft.com/kb/815788

//#define TEST_SIMPLE
//#define TEST_FULL
#define TEST_DELETE

using System;
using System.Diagnostics;

namespace SystemDiagnostic
{
	class Program
	{
		static void Main(string[] args)
		{
		    try
		    {
                #if TEST_SIMPLE
		            EventLog tmpEventLog = new EventLog();
		            tmpEventLog.Source = "Test EventLog";
		            tmpEventLog.WriteEntry("Test EventLog.WriteEntry()", EventLogEntryType.Information);
                #endif

                #if TEST_FULL
                    if (!EventLog.SourceExists("MySource"))
                    {
                        EventLog.CreateEventSource("MySource", "MyNewLog");
                        Console.WriteLine("CreatedEventSource");
                        Console.WriteLine("Exiting, execute the application a second time to use the source.");
                        return;
                    }

                    EventLog myLog = new EventLog();
                    myLog.Source = "MySource";
                    myLog.WriteEntry("Writing to event log.");
                #endif

                #if TEST_DELETE
                    EventLog.Delete("MyNewLog");
                #endif
		    }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
		}
	}
}
