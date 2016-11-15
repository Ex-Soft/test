using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

// State object for receiving data from remote device.
public class StateObject
{
	// Client socket.
	public Socket workSocket = null;
	// Size of receive buffer.
	public const int BufferSize = 20;
	// Receive buffer.
	public byte[] buffer = new byte[BufferSize];
	// Received data string.
	public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient
{
	// The port number for the remote device.
	private const int port = 21;

	// ManualResetEvent instances signal completion.
	private static ManualResetEvent connectDone =
		new ManualResetEvent(false);
	private static ManualResetEvent sendDone =
		new ManualResetEvent(false);
	private static ManualResetEvent receiveDone =
		new ManualResetEvent(false);

	// The response from the remote device.
	private static String response = String.Empty;

	private static void StartClient()
	{
		// Connect to a remote device.
		try
		{
			// Establish the remote endpoint for the socket.
			// The name of the 
			// remote device is "host.contoso.com".
			IPAddress
				ipAddress = new IPAddress(new byte[] { 195, 135, 197, 29 });
			IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

			// Create a TCP/IP socket.
			Socket client = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);

			// Connect to the remote endpoint.
			client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
			connectDone.WaitOne();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			Send(client, "help\n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			Send(client, "user igor-n\n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			Send(client, "pass \n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			Send(client, "cwd paxheader\n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			/*
			Send(client, "list\n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();
			*/

			Send(client, "quit\n");
			sendDone.WaitOne();
			sendDone.Reset();

			Receive(client);
			receiveDone.WaitOne();
			Console.WriteLine("Response received : {0}", response);
			receiveDone.Reset();

			client.Shutdown(SocketShutdown.Both);
			client.Close();

			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void ConnectCallback(IAsyncResult ar)
	{
		//Console.WriteLine("ConnectCallback");

		try
		{
			Socket
				client = (Socket)ar.AsyncState;

			client.EndConnect(ar);
			Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());

			connectDone.Set();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void Receive(Socket client)
	{
		//Console.WriteLine("Receive");

		try
		{
			StateObject
				state = new StateObject();

			state.workSocket = client;
			client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void ReceiveCallback(IAsyncResult ar)
	{
		//Console.WriteLine("ReceiveCallback");

		try
		{
			StateObject
				state = (StateObject)ar.AsyncState;

			Socket
				client = state.workSocket;

			//Console.WriteLine("Socket.Available: {0}", client.Available);

			int
				bytesRead = client.EndReceive(ar);

			//Console.WriteLine("bytesRead: {0}", bytesRead);

			if (bytesRead > 0)
			{
				state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
				if (client.Available > 0)
					client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
				else
				{
					if (state.sb.Length > 1)
					{
						response = state.sb.ToString();
					}

					receiveDone.Set();
				}
			}
			else
			{
				if (state.sb.Length > 1)
				{
					response = state.sb.ToString();
				}

				receiveDone.Set();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void Send(Socket client, String data)
	{
		byte[]
			byteData = Encoding.ASCII.GetBytes(data);

		client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
	}

	private static void SendCallback(IAsyncResult ar)
	{
		try
		{
			Socket
				client = (Socket)ar.AsyncState;

			int
				bytesSent = client.EndSend(ar);

			Console.WriteLine("Sent {0} bytes to server.", bytesSent);

			sendDone.Set();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	public static int Main(String[] args)
	{
		StartClient();
		return 0;
	}
}