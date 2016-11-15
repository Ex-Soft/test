using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AsynchronousClientSocketIV
{
	class Program
	{
		const int
			MAX_LENGTH = 256;

		static byte[]
			buffer = new byte[MAX_LENGTH];

		static ManualResetEvent
			connectDone = new ManualResetEvent(false);

		static void Main(string[] args)
		{
			Socket
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				Connect(socket);
				connectDone.WaitOne();
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
			finally
			{
				if (socket != null && socket.Connected)
				{
					Console.WriteLine("finally: Socket.Shutdown()/Socket.Close()");
					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
				}
			}
		}

		static void Connect(Socket socket)
		{
			Console.WriteLine("Connect");

			IPAddress
				ipAddress = IPAddress.Parse("195.135.197.29");

			IPEndPoint
				remoteEP = new IPEndPoint(ipAddress, 21);

			socket.BeginConnect(remoteEP, result => {
				Console.WriteLine("ConnectCallback");
				socket.EndConnect(result);
				connectDone.Set();
			}, null);
		}
	}
}
