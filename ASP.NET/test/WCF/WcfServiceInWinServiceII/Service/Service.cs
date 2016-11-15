using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;

namespace Service
{
    [ServiceContract(Namespace = "http://WCFWindowsServiceSample")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }
    }

    public class CalculatorWindowsService : ServiceBase
    {
        ServiceHost _serviceHost = null;

        public CalculatorWindowsService()
        {
            ServiceName = "WCFWindowsServiceSample";
        }

        public static void Main()
        {
            Run(new CalculatorWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            var methodName = string.Format("{0}.OnStart()", ServiceName);

            WriteToEventLog(methodName + " starting");

            try
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();
                }

                _serviceHost = new ServiceHost(typeof(CalculatorService));

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

        protected override void OnStop()
        {
            var methodName = string.Format("{0}.OnStop()", ServiceName);

            WriteToEventLog(methodName + " starting...");

            try
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();

                    _serviceHost.UnknownMessageReceived -= ServiceHostUnknownMessageReceived;
                    _serviceHost.Faulted -= ServiceHostFaulted;
                    _serviceHost.Closed -= ServiceHostClosed;
                    _serviceHost.Closing -= ServiceHostClosing;
                    _serviceHost.Opened -= ServiceHostOpened;
                    _serviceHost.Opening -= ServiceHostOpening;

                    _serviceHost = null;
                }
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

        void WriteToEventLog(string eventMessage)
        {
            var tmpEventLog = new EventLog { Source = ServiceName };

            tmpEventLog.WriteEntry(eventMessage, EventLogEntryType.Information);
        }
    }

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFWindowsServiceSample";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
