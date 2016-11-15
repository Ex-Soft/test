using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SynchronousClientSocket
{
	class Program
	{
		static void Main(string[] args)
		{
			Socket
				socket = null;

			try
			{
				IPAddress
					ipAddress = new IPAddress(new byte[] { 195, 135, 197, 29 });

				IPEndPoint
					remoteEP = new IPEndPoint(ipAddress, 21);

				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				socket.Connect(remoteEP);
				Console.WriteLine("Socket connected to {0}", socket.RemoteEndPoint.ToString());

				const int
					MAX_BUFFER_LENGTH = 100;

				byte[]
					dataSend,
					dataReceive = new byte[MAX_BUFFER_LENGTH];

				int
					Cnt;

				Cnt = socket.Receive(dataReceive);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));

				dataSend = Encoding.ASCII.GetBytes("help\n");
				Cnt = socket.Send(dataSend);

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available>0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};

				dataSend = Encoding.ASCII.GetBytes("user igor-n\n");
				Cnt = socket.Send(dataSend);

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available > 0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};

				dataSend = Encoding.ASCII.GetBytes("pass \n");
				Cnt = socket.Send(dataSend);

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available > 0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};

				dataSend = Encoding.ASCII.GetBytes("cwd paxheader\n");
				Cnt = socket.Send(dataSend);

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available > 0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};

				dataSend = Encoding.ASCII.GetBytes("list\n");
				Cnt = socket.Send(dataSend);

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available > 0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};

				dataSend = Encoding.ASCII.GetBytes("quit\n");
				Cnt = socket.Send(dataSend);

				string
					tmpString;

				Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
				Console.WriteLine("Echoed test = {0}", tmpString=Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				while (socket.Available > 0)
				{
					Cnt = socket.Receive(dataReceive, MAX_BUFFER_LENGTH, SocketFlags.None);
					Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(dataReceive, 0, Cnt));
				};
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
			finally
			{
				if (socket != null && socket.Connected)
				{
					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
				}
			}

			Console.ReadLine();
		}
	}
}
