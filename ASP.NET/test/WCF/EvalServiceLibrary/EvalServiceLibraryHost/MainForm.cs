using System;
using System.Windows.Forms;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EvalServiceLibraryHost
{
    public partial class MainForm : Form
    {
        ServiceHost
            host = null;

        string
            urlMeta,
            urlService = "";

        public MainForm()
        {
            InitializeComponent();
            Append("Program started ...");
        }

        void host_Opening(object sender, EventArgs e)
        {
            Append("Service opening ... Stand by");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry
                    ips = Dns.GetHostEntry(Dns.GetHostName());

                IPAddress
                    _ipAddress = ips.AddressList[0];

                urlService = "net.tcp://" + _ipAddress.ToString() + ":8000/EvalService";

                host = new ServiceHost(typeof(EvalServiceLibrary.EvalService));
                host.Opening += new EventHandler(host_Opening);
                host.Opened += new EventHandler(host_Opened);
                host.Closing += new EventHandler(host_Closing);
                host.Closed += new EventHandler(host_Closed);

                NetTcpBinding
                    tcpBinding = new NetTcpBinding();

                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None; // <- Very crucial

                host.AddServiceEndpoint(typeof(EvalServiceLibrary.IEvalService), tcpBinding, urlService);

                ServiceMetadataBehavior
                    metadataBehavior;

                metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (metadataBehavior == null)
                {
                    metadataBehavior = new ServiceMetadataBehavior();
                    metadataBehavior.HttpGetUrl = new Uri("http://" + _ipAddress.ToString() + ":8001/EvalService");
                    metadataBehavior.HttpGetEnabled = true;
                    metadataBehavior.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            HostClose();
        }

        void host_Closed(object sender, EventArgs e)
        {
            Append("Service closed");
        }

        void host_Closing(object sender, EventArgs e)
        {
            Append("Service closing ... stand by");
        }

        void host_Opened(object sender, EventArgs e)
        {
            Append("Service opened.");
            Append("Service URL:\t" + urlService);
            Append("Meta URL:\t" + urlMeta + " (Not that relevant)");
            Append("Waiting for clients...");
        }

        void Append(string str)
        {
            textBox1.AppendText("\r\n" + str);
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
    }
}