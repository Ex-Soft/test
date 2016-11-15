using System;
using System.Net.Sockets;

namespace tcpip
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpClient
				TcpClient=new TcpClient();

			try
			{
				TcpClient.Connect("195.135.197.29", 21);
			}
			finally
			{
				if (TcpClient.Connected)
					TcpClient.Close();
			}
		}
	}
}
