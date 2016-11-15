using System.Diagnostics;
using System.ServiceModel;
using System.Threading;

namespace TestWCF
{
    // http://msdn.microsoft.com/en-us/library/ff183865.aspx (Managing Concurrency)
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)] // default
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServiceContract : IServiceContract
    {
        IBusinessLogic
            _businessLogic;

        private const int
            mSec = 60000;

        public ServiceContract(IBusinessLogic businessLogic)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";
            tmpEventLog.WriteEntry("ServiceContract.ServiceContract()", EventLogEntryType.Information);

            _businessLogic = businessLogic;
        }

        public string DoSmth(string inp)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmth({0}) before sleep", inp), EventLogEntryType.Information);
            Thread.Sleep(mSec);
            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmth({0}) after sleep", inp), EventLogEntryType.Information);

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmth({0}) before BusinessLogic.DoSmth()", inp), EventLogEntryType.Information);

            string
                result=_businessLogic.DoSmth(inp);

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmth({0}) after BusinessLogic.DoSmth()", inp), EventLogEntryType.Information);

            return result;
        }

        public DataContract DoSmthWithClass(DataContract dataContract)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmthWithClass({0}) before sleep", dataContract.StringField), EventLogEntryType.Information);
            Thread.Sleep(mSec);
            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmthWithClass({0}) after sleep", dataContract.StringField), EventLogEntryType.Information);

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmthWithClass({0}) before BusinessLogic.DoSmthWithClass()", dataContract.StringField), EventLogEntryType.Information);

            DataContract
                result=(DataContract)_businessLogic.DoSmthWithClass(dataContract);

            tmpEventLog.WriteEntry(string.Format("ServiceContract.DoSmthWithClass({0}) after BusinessLogic.DoSmthWithClass()", dataContract.StringField), EventLogEntryType.Information);

            return result;
        }
    }
}
