#define WRITE_TO_EVENT_LOG

using System;
using System.Configuration;
using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Web;
using System.ServiceProcess;

namespace VictimService
{
    public partial class VictimService : ServiceBase
    {
        WebServiceHost _serviceHost;

        public VictimService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var methodName = string.Format("{0}.OnStart()", ServiceName);

            #if WRITE_TO_EVENT_LOG
                WriteToEventLog(methodName + " starting...");
            #endif

            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();

                _serviceHost = new WebServiceHost(typeof(Victim.Victim), new Uri(GetEndPointAddress("endPointAddress")));
                _serviceHost.Open();

                #if WRITE_TO_EVENT_LOG
                    WriteToEventLog(methodName + string.Format(" \"{0}\" ServiceHost.State = \"{1}\" GCSettings.IsServerGC = \"{2}\" GCSettings.LatencyMode = \"{3}\"", _serviceHost.BaseAddresses.Count > 0 ? _serviceHost.BaseAddresses[0].AbsoluteUri : "ServiceHost.BaseAddresses.Count == 0", _serviceHost.State, GCSettings.IsServerGC, GCSettings.LatencyMode));
                #endif
            }
            catch (Exception eException)
            {
                WriteToEventLog(methodName + string.Format(" Exception: \"{0}\" \"{1}\"", eException.GetType().FullName, eException.Message));
            }

            #if WRITE_TO_EVENT_LOG
                WriteToEventLog(methodName + " finished");
            #endif
        }

        protected override void OnStop()
        {
            var methodName = string.Format("{0}.OnStop()", ServiceName);

            #if WRITE_TO_EVENT_LOG
                WriteToEventLog(methodName + " starting...");
            #endif

            try
            {
                if (_serviceHost == null)
                    return;

                _serviceHost.Close();
                _serviceHost = null;
            }
            catch (Exception eException)
            {
                WriteToEventLog(methodName + string.Format(" Exception: \"{0}\" \"{1}\"", eException.GetType().FullName, eException.Message));
            }

            #if WRITE_TO_EVENT_LOG
                WriteToEventLog(methodName + " finished");
            #endif
        }

        void WriteToEventLog(string eventMessage)
        {
            var tmpEventLog = new EventLog { Source = ServiceName };

            tmpEventLog.WriteEntry(eventMessage, EventLogEntryType.Information);
        }

        string GetEndPointAddress(string key)
        {
            var endPointAddress = ConfigurationManager.AppSettings[key];

            return !string.IsNullOrEmpty(endPointAddress) ? endPointAddress : "http://localhost/" + ServiceName;
        }
    }
}
