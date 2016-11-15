using System;
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
            return new TestWCF.ServiceContract(new TestWCF.BusinessLogic()); // ObjectFactory.GetInstance(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
