using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.ServiceModel;

namespace TestWCFClientMT
{
    class WcfClientThread : IDisposable
    {
        StreamWriter
            file;

        Thread
            Thread;

        bool
            disposed;

        public WcfClientThread(string ThreadName)
        {
            disposed = false;

            string
                FileName = "thread_f_" + ThreadName + ".txt";

            if (File.Exists(FileName))
                File.Delete(FileName);

            try
            {
                file = new StreamWriter(FileName, true, Encoding.GetEncoding(1251));
            }
            catch
            {
                GC.SuppressFinalize(this);
                throw;
            }

            if (!file.AutoFlush)
                file.AutoFlush = true;

            Thread = new Thread(run);
            Thread.Name = ThreadName;
            Thread.Start();
        }

        public void run()
        {
            string
                Msg;

            file.WriteLine(Msg = string.Format("{0}\tThread Id: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name));
            Console.WriteLine(Msg);

            try
            {
                IPHostEntry
                    ips = Dns.GetHostEntry(Dns.GetHostName());

                IPAddress
                    _ipAddress = ips.AddressList[1];

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

                file.WriteLine(Msg=string.Format("{0}\tAttempt to connect to: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), endPointAddr));
                Console.WriteLine(Msg);

                TestWCF.IServiceContract
                    proxy = ChannelFactory<TestWCF.IServiceContract>.CreateChannel(tcpBinding, endpointAddress);

                file.WriteLine(Msg=string.Format("{0}\tConnected", DateTime.Now.ToString("HH:mm:ss.fffffff")));
                Console.WriteLine(Msg);

                using (proxy as IDisposable)
                {
                    file.WriteLine(Msg=string.Format("{0}\tDoSmth({1}) started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name));
                    Console.WriteLine(Msg);
                    file.WriteLine(Msg=string.Format("{0}\tDoSmth({1}) finished (Result: \"{2}\")", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name, proxy.DoSmth(Thread.Name)));
                    Console.WriteLine(Msg);

                    TestWCF.DataContract
                        dataContract = new TestWCF.DataContract { StringField = Thread.Name };

                    file.WriteLine(Msg=string.Format("{0}\tDoSmthWithClass({1}) started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), dataContract.StringField));
                    Console.WriteLine(Msg);
                    file.WriteLine(Msg=string.Format("{0}\tDoSmthWithClass({1}) finished (Result: \"{2}\")", DateTime.Now.ToString("HH:mm:ss.fffffff"), dataContract.StringField, proxy.DoSmthWithClass(dataContract).StringField));
                    Console.WriteLine(Msg);
                }
            }
            catch (Exception eException)
            {
                file.WriteLine("{1}{0}{2}{0}Message: \"{3}\"{4}{0}StackTrace:{0}{5}",
                    Environment.NewLine,
                    DateTime.Now.ToString("HH:mm:ss.fffffff"),
                    eException.GetType().FullName,
                    eException.Message,
                    eException.InnerException != null ? Environment.NewLine + "InnerException.Message: \"" + eException.InnerException.Message + "\"" : string.Empty,
                    eException.StackTrace);
            }

            file.WriteLine(Msg=string.Format("{0}\tThread Id: {1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), Thread.Name));
            Console.WriteLine(Msg);
        }

        ~WcfClientThread()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (file != null)
                        file.Dispose();
                }
                disposed = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int
                DefaultMaxThreadsNumber = 10;

            int
                MaxThreadsNumber = DefaultMaxThreadsNumber;

            if (args.Length >= 1)
            {
                if (!int.TryParse(args[0], out MaxThreadsNumber))
                    MaxThreadsNumber = DefaultMaxThreadsNumber;
            }

            StreamWriter
                sw = new StreamWriter("main.txt", false, Encoding.GetEncoding(1251));

            if (!sw.AutoFlush)
                sw.AutoFlush = true;

            sw.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));
            
            Dictionary<int,WcfClientThread>
                clients=new Dictionary<int, WcfClientThread>();

            for (int i = 0; i < MaxThreadsNumber; ++i)
            {
                clients.Add(i, new WcfClientThread(Process.GetCurrentProcess().Id + "_" + i));
            }
            
            sw.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));
            sw.Close();
        }
    }
}
