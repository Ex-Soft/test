using System;

namespace RoaminSMPP
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				SMPPCommunicator
					SMPPCommunicator = new SMPPCommunicator();

				SMPPCommunicator.Host = "212.58.160.139";
				SMPPCommunicator.Port = 16001;
				SMPPCommunicator.SystemId = "Entri";
				SMPPCommunicator.Password = "73Nsy2Mw";
				SMPPCommunicator.BindType = RoaminSMPP.Packet.Request.SmppBind.BindingType.BindAsTransceiver;
				SMPPCommunicator.TonType = RoaminSMPP.Packet.Pdu.TonType.Alphanumeric;
				SMPPCommunicator.NpiType = RoaminSMPP.Packet.Pdu.NpiType.ISDN;
				SMPPCommunicator.AddressRange = "N3";
				SMPPCommunicator.Bind();
				SMPPCommunicator.Unbind();
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "InnerException.Message" + eException.InnerException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
		}
	}
}
