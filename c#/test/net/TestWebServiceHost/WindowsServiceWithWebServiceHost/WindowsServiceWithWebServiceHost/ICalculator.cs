using System.ServiceModel;
using System.ServiceModel.Web;

namespace WindowsServiceWithWebServiceHost
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Add", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double Add(double n1, double n2);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Subtract", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double Subtract(double n1, double n2);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Multiply", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double Multiply(double n1, double n2);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Divide", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double Divide(double n1, double n2);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ToDouble", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double ToDouble(string str, out bool success);
    }
}
