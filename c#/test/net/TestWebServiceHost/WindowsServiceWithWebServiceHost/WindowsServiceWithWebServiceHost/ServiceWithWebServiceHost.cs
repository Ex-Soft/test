using System;
using System.Diagnostics;
using System.ServiceModel.Web;
using System.ServiceProcess;

namespace WindowsServiceWithWebServiceHost
{
    public partial class ServiceWithWebServiceHost : ServiceBase
    {
        WebServiceHost _serviceHost;

        public ServiceWithWebServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var methodName = string.Format("{0}.OnStart()", ServiceName);

            WriteToEventLog(methodName + " starting...");

            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();

                _serviceHost = new WebServiceHost(typeof(CalculatorService), new Uri("http://localhost/Calculator"));
                _serviceHost.Open();

                WriteToEventLog(methodName + string.Format(" \"{0}\" ServiceHost.State = \"{1}\"", _serviceHost.BaseAddresses.Count > 0 ? _serviceHost.BaseAddresses[0].AbsoluteUri : "ServiceHost.BaseAddresses.Count == 0", _serviceHost.State));
            }
            catch (Exception eException)
            {
                WriteToEventLog(methodName + string.Format(" Exception: \"{0}\" \"{1}\"", eException.GetType().FullName, eException.Message));
            }

            WriteToEventLog(methodName + " finished");
        }

        protected override void OnStop()
        {
            var methodName = string.Format("{0}.OnStop()", ServiceName);

            WriteToEventLog(methodName + " starting...");

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

            WriteToEventLog(methodName + " finished");
        }

        void WriteToEventLog(string eventMessage)
        {
            var tmpEventLog = new EventLog { Source = ServiceName };

            tmpEventLog.WriteEntry(eventMessage, EventLogEntryType.Information);
        }
    }
}
