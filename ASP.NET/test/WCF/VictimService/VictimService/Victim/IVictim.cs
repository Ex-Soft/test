using System.ServiceModel;
using System.ServiceModel.Web;

namespace VictimService.Victim
{
    [ServiceContract]
    public interface IVictim
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "VictimMethod", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int VictimMethod(string paramString);
    }
}
