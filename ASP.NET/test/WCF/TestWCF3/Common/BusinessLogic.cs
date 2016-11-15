using System.Diagnostics;

namespace TestWCF
{
    public class BusinessLogic : IBusinessLogic
    {
        public string DoSmth(string inp)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";

            tmpEventLog.WriteEntry(string.Format("BusinessLogic.DoSmth({0})", inp), EventLogEntryType.Information);

            return "return: " + (string.IsNullOrEmpty(inp) ? "\"" + inp + "\"" : "null");
        }

        public IDataContract DoSmthWithClass(IDataContract dataContract)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";

            tmpEventLog.WriteEntry(string.Format("BusinessLogic.DoSmthWithClass({0})", dataContract.StringField), EventLogEntryType.Information);

            dataContract.StringField = !string.IsNullOrEmpty(dataContract.StringField) ? dataContract.StringField + "+" + dataContract.StringField : "null";

            return dataContract;
        }
    }
}
