// http://lostechies.com/jimmybogard/2008/07/30/integrating-structuremap-with-wcf/
// http://orand.blogspot.com/2006/10/wcf-service-dependency-injection.html
// http://www.codeproject.com/KB/WCF/diwcf.aspx
// http://wcf.codeplex.com/workitem/60

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace TestWCFHost
{
    public partial class MainForm : Form
    {
        ServiceHost
               host = null;

        string
            urlMeta=string.Empty,
            urlService = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            Append("Program started ...");
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry
                    ips = Dns.GetHostEntry(Dns.GetHostName());

                IPAddress
                    _ipAddress = ips.AddressList[0];

                string
                    _ipAddressStr = TestWCF.Common.Host; // _ipAddress.ToString();

                urlService = "net.tcp://" + _ipAddressStr + ":8000/" + TestWCF.Common.ServiceName;

                host = new StructureMapServiceHost(typeof(TestWCF.ServiceContract));

                host.Opening += new EventHandler(host_Opening);
                host.Opened += new EventHandler(host_Opened);
                host.Closing += new EventHandler(host_Closing);
                host.Closed += new EventHandler(host_Closed);

                NetTcpBinding
                    tcpBinding = new NetTcpBinding();

                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None;

                host.AddServiceEndpoint(typeof(TestWCF.IServiceContract), tcpBinding, urlService);

                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior
                        metadataBehavior = new ServiceMetadataBehavior();

                    metadataBehavior.HttpGetUrl = new Uri("http://" + _ipAddressStr + ":8001/" + TestWCF.Common.ServiceName);
                    metadataBehavior.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(metadataBehavior);
                    urlMeta = metadataBehavior.HttpGetUrl.ToString();
                }

                host.Open();
            }
            catch (Exception eException)
            {
                Append(string.Format("{1}{0}Message: \"{2}\"{3}{0}StackTrace:{0}{4}",
                    Environment.NewLine,
                    eException.GetType().FullName,
                    eException.Message,
                    eException.InnerException != null ? Environment.NewLine + "InnerException.Message: \"" + eException.InnerException.Message + "\"" : string.Empty,
                    eException.StackTrace));
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            HostClose();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HostClose();
        }

        void HostClose()
        {
            if (host != null && host.State == CommunicationState.Opened)
                host.Close();
        }

        void Append(string str)
        {
            textBox1.AppendText("\r\n" + str);
        }

        void host_Opening(object sender, EventArgs e)
        {
            Append("Service opening ... Stand by");
        }

        void host_Opened(object sender, EventArgs e)
        {
            Append("Service opened.");
            Append("Service URL:\t" + urlService);
            Append("Meta URL:\t" + urlMeta + " (Not that relevant)");
            Append("Waiting for clients...");
        }

        void host_Closing(object sender, EventArgs e)
        {
            Append("Service closing ... stand by");
        }

        void host_Closed(object sender, EventArgs e)
        {
            Append("Service closed");
        }
    }
}
