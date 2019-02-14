using System.ServiceModel;

namespace TestASPnWCFService
{
    [ServiceContract(Namespace = "http://TestASPnWCFService")]
    public interface ITestService2
    {
        [OperationContract]
        void DoWork();
    }
}