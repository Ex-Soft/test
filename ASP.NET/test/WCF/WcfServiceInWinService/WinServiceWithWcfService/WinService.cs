using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;

namespace WinServiceWithWcfService
{
    public partial class WinService : ServiceBase
    {
        ServiceHost _serviceHost;

        public WinService()
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

                //var baseAddressHttp = new Uri("http://localhost:8080/WcfServiceHost");

                _serviceHost = new ServiceHost(typeof(WcfServiceHost.WcfServiceHost)/*, baseAddressHttp*/);

                _serviceHost.Opening += ServiceHostOpening;
                _serviceHost.Opened += ServiceHostOpened;
                _serviceHost.Closing += ServiceHostClosing;
                _serviceHost.Closed += ServiceHostClosed;
                _serviceHost.Faulted += ServiceHostFaulted;
                _serviceHost.UnknownMessageReceived += ServiceHostUnknownMessageReceived;

                _serviceHost.Open();

                WriteToEventLog(methodName + string.Format(" \"{0}\" ServiceHost.State = \"{1}\"", _serviceHost.BaseAddresses.Count > 0 ? _serviceHost.BaseAddresses[0].AbsoluteUri : "ServiceHost.BaseAddresses.Count == 0", _serviceHost.State));
            }
            catch (Exception eException)
            {
                WriteToEventLog(methodName + string.Format(" Exception: \"{0}\" \"{1}\"", eException.GetType().FullName, eException.Message));
            }

            WriteToEventLog(methodName + " finished");
        }

        void ServiceHostUnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            WriteToEventLog("ServiceHostUnknownMessageReceived");
        }

        void ServiceHostFaulted(object sender, EventArgs e)
        {
            WriteToEventLog("ServiceHostFaulted");
        }

        void ServiceHostClosing(object sender, EventArgs e)
        {
            WriteToEventLog("ServiceHostClosing");
        }

        void ServiceHostClosed(object sender, EventArgs e)
        {
            WriteToEventLog("ServiceHostClosed");
        }

        private void ServiceHostOpening(object sender, EventArgs e)
        {
            WriteToEventLog("ServiceHostOpening");
        }

        void ServiceHostOpened(object sender, EventArgs e)
        {
            WriteToEventLog("ServiceHostOpened");
        }

        protected override void OnStop()
        {
            var methodName = string.Format("{0}.OnStop()", ServiceName);

            WriteToEventLog(methodName + " starting...");

            try
            {
                if (_serviceHost == null)
                    return;

                WriteToEventLog(methodName + string.Format(" \"{0}\" ServiceHost.State = \"{1}\"", _serviceHost.BaseAddresses.Count > 0 ? _serviceHost.BaseAddresses[0].AbsoluteUri : "ServiceHost.BaseAddresses.Count == 0", _serviceHost.State));

                _serviceHost.Close();

                _serviceHost.UnknownMessageReceived -= ServiceHostUnknownMessageReceived;
                _serviceHost.Faulted -= ServiceHostFaulted;
                _serviceHost.Closed -= ServiceHostClosed;
                _serviceHost.Closing -= ServiceHostClosing;
                _serviceHost.Opened -= ServiceHostOpened;
                _serviceHost.Opening -= ServiceHostOpening;

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
