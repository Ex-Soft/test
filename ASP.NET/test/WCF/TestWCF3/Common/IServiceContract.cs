using System.ServiceModel;

namespace TestWCF
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        string DoSmth(string inp);

        [OperationContract]
        DataContract DoSmthWithClass(DataContract dataContract);
    }
}
