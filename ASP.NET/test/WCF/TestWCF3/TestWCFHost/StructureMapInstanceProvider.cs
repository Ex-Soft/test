using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace TestWCFHost
{
    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private readonly Type
            _serviceType;

        public StructureMapInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";
            tmpEventLog.WriteEntry("StructureMapInstanceProvider.GetInstance()", EventLogEntryType.Information);

            return new TestWCF.ServiceContract(new TestWCF.BusinessLogic());
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
