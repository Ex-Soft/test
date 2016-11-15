using System;
using System.ServiceModel;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string
                    ipAddressStr = "localhost",
                    endPointAddr = "http://" + ipAddressStr + ":8080/" + "WCFWindowsServiceSample";

                WSHttpBinding
                    wsHttpBinding = new WSHttpBinding();

                EndpointAddress
                    endpointAddress = new EndpointAddress(endPointAddr);

                Service.ICalculator
                    proxy = ChannelFactory<Service.ICalculator>.CreateChannel(wsHttpBinding, endpointAddress);

                using (proxy as IDisposable)
                {
                    var result = proxy.Add(1, 2);
                    Console.WriteLine(result);

                    result = proxy.Subtract(5, 3);
                    Console.WriteLine(result);

                    result = proxy.Multiply(6, 8);
                    Console.WriteLine(result);

                    result = proxy.Divide(20, 4);
                    Console.WriteLine(result);
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
