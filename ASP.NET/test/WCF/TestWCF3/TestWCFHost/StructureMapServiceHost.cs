using System;
using System.Diagnostics;
using System.ServiceModel;

namespace TestWCFHost
{
    public class StructureMapServiceHost : ServiceHost
    {
        public StructureMapServiceHost()
        {}

        public StructureMapServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {}

        protected override void OnOpening()
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "Test WCF";
            tmpEventLog.WriteEntry("StructureMapServiceHost.OnOpening()", EventLogEntryType.Information);

            Description.Behaviors.Add(new StructureMapServiceBehavior());
            base.OnOpening();
        }
    }
}
