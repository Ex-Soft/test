using System;
using System.Configuration;
using System.ServiceModel;
using WcfServiceHost;

namespace TestWinServiceWithWcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var endPointAddr = ConfigurationManager.AppSettings["endPointAddr"];

                if (string.IsNullOrWhiteSpace(endPointAddr))
                    return;

                Console.WriteLine(endPointAddr);

                var wsHttpBinding = new WSHttpBinding();
                var endpointAddress = new EndpointAddress(endPointAddr);
                var proxy = ChannelFactory<IWcfServiceHost>.CreateChannel(wsHttpBinding, endpointAddress);

                using (proxy as IDisposable)
                {
                    var result = proxy.GetData(1);
                    Console.WriteLine(result);

                    var compositeType = proxy.GetDataUsingDataContract(new CompositeType { BoolValue = true, StringValue = "StringValue" });
                    Console.WriteLine("{{ BoolValue: {0}, StringValue: \"{1}\" }}", compositeType.BoolValue, compositeType.StringValue);
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
