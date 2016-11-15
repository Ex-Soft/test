using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace TestWCFHost
{
    public class StructureMapServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ManualProxy.TargetFactory = () => new TestWCF.ServiceContract(new TestWCF.BusinessLogic());
            return base.CreateServiceHost(typeof(ManualProxy), baseAddresses);
        }
    }
}
