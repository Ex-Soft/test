using System.ServiceModel;

namespace TestASPnWCFService
{
    [ServiceContract(Namespace = "http://TestASPnWCFService")]
    public interface ITestService
    {
        [OperationContract]
        void DoWork();
    }
}
