using System;
using System.Net;
using System.ServiceModel;

namespace TestWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPHostEntry
                    ips = Dns.GetHostEntry(Dns.GetHostName());

                IPAddress
                    _ipAddress = ips.AddressList[0];

                string
                    _ipAddressStr = TestWCF.Common.Host; // _ipAddress.ToString();

                string
                    endPointAddr = "net.tcp://" + _ipAddressStr + ":8000/" + TestWCF.Common.ServiceName;

                NetTcpBinding
                    tcpBinding = new NetTcpBinding();

                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None;

                EndpointAddress
                    endpointAddress = new EndpointAddress(endPointAddr);

                Console.WriteLine("Attempt to connect to: " + endPointAddr);

                TestWCF.IServiceContract
                    proxy = ChannelFactory<TestWCF.IServiceContract>.CreateChannel(tcpBinding, endpointAddress);

                using (proxy as IDisposable)
                {
                    Console.WriteLine("{0}", proxy.DoSmth(null));

                    TestWCF.DataContract
                        dataContract = new TestWCF.DataContract {StringField = "StringField"};

                    Console.WriteLine("{0}", proxy.DoDmthWithClass(dataContract).StringField);
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine("{1}{0}Message: \"{2}\"{3}{0}StackTrace:{0}{4}",
                    Environment.NewLine,
                    eException.GetType().FullName,
                    eException.Message,
                    eException.InnerException != null ? Environment.NewLine + "InnerException.Message: \"" + eException.InnerException.Message + "\"" : string.Empty,
                    eException.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
