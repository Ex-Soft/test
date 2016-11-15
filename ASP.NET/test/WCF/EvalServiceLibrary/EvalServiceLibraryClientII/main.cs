using System;
using System.Net;
using System.ServiceModel;
using EvalServiceLibrary;

namespace EvalServiceLibraryClientII
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
                    endPointAddr = "net.tcp://" + _ipAddress.ToString() + ":8000/EvalService";

                NetTcpBinding
                    tcpBinding = new NetTcpBinding();

                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None;

                EndpointAddress
                    endpointAddress = new EndpointAddress(endPointAddr);

                Console.WriteLine("Attempt to connect to: " + endPointAddr);

                IEvalService
                    proxy = ChannelFactory<IEvalService>.CreateChannel(tcpBinding, endpointAddress);

                using (proxy as IDisposable)
                {
                    Eval
                        eval;

                    eval = new Eval {Comments = "CommentsField1", Submitter = "Submitter1", TimeSubmitted = DateTime.Now};
                    proxy.SubmitEval(eval);
                    eval = new Eval {Comments = "CommentsField2", Submitter = "Submitter2", TimeSubmitted = DateTime.Now};
                    proxy.SubmitEval(eval);
                    eval = new Eval {Comments = "CommentsField3", Submitter = "Submitter3", TimeSubmitted = DateTime.Now};
                    proxy.SubmitEval(eval);

                    Eval[]
                        evals = proxy.GetEvals();

                    foreach (Eval e in evals)
                        Console.WriteLine("{0}\t{1}\t{2}", e.Id, e.Submitter, e.TimeSubmitted);
                }
            }
            catch(Exception eException)
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
