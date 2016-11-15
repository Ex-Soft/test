using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;

namespace AsynchronousClientSocketIII
{
	public partial class MainForm : Form
	{
		ClientSocket
			ServerSocket = null,
			ClientSocket1 = null;

		const string
			IP = "127.0.0.1";

		const int
			Port = 1313,
			MAX_LENGTH = 3;

		public MainForm()
		{
			InitializeComponent();
		}

		private void ServerBindButton_Click(object sender, EventArgs e)
		{
			IPAddress
				ipAddress = IPAddress.Parse(IP);

			IPEndPoint
				anEndPoint = new IPEndPoint(ipAddress, Port);

			ServerSocket = new ClientSocket("ServerSocket", MAX_LENGTH);

			ServerSocket.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			ServerSocket.socket.Blocking = checkBoxServerSocketBlocked.Checked;
			ServerSocket.socket.Bind(anEndPoint);
			ListBoxLog.Items.Add(string.Format("ServerSocket.Bind() (IsBound: {0})", ServerSocket.socket.IsBound));
			ServerBindButton.Enabled = false;
			ListBoxLog.Items.Add("ServerSocket.Listen()");
			ServerSocket.socket.Listen(10);
			ListBoxLog.Items.Add("ServerSocket.BeginAccept()");
			ServerSocket.socket.BeginAccept(result => {
				Socket
					socket = (Socket)ServerSocket.socket.EndAccept(result);

				if (ListBoxLog.InvokeRequired)
					ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add("ServerSocket.EndAccept() (" + socket.RemoteEndPoint.ToString() + ")"); }));
				else
					ListBoxLog.Items.Add("ServerSocket.EndAccept() (" + socket.RemoteEndPoint.ToString() + ")");

				if (ServerSocket.Sockets == null)
					ServerSocket.Sockets = new List<Socket>();

				ServerSocket.Sockets.Add(socket);

				if (listBoxClients.InvokeRequired)
					listBoxClients.Invoke(new MethodInvoker(delegate {
						listBoxClients.Items.Add("Client# " + ServerSocket.Sockets.Count + " (" + socket.RemoteEndPoint.ToString() + ")");
						listBoxClients.SelectedIndex = ServerSocket.Sockets.Count - 1;
						ButtonReceiveServer.Enabled = true;
						ButtonSendServer.Enabled = true;
					}));
				else
				{
					listBoxClients.Items.Add("Client# " + ServerSocket.Sockets.Count + " (" + socket.RemoteEndPoint.ToString() + ")");
					listBoxClients.SelectedIndex = ServerSocket.Sockets.Count - 1;
					ButtonReceiveServer.Enabled = true;
					ButtonSendServer.Enabled = true;
				}
			}, null);
		}

		private void ClientConnectButton_Click(object sender, EventArgs e)
		{
			Button
				ButtonConnect,
				ButtonReceive = null,
				ButtonSend = null;

			if ((ButtonConnect = sender as Button) == null)
				return;

			IPAddress
				ipAddress = IPAddress.Parse(IP);

			IPEndPoint
				remoteEP = new IPEndPoint(ipAddress, Port);

			ClientSocket
				tmpClientSocket = null;

			CheckBox
				tmpCheckBox = null;

			switch (ButtonConnect.Name)
			{
				case "ButtonConnectClient1":
				{
					tmpClientSocket = ClientSocket1 = new ClientSocket("ClientSocket1", MAX_LENGTH);
					tmpCheckBox = checkBoxClientSocket1Blocked;
					ButtonReceive = ButtonReceiveClient1;
					ButtonSend = ButtonSendClient1;

					break;
				}
			}

			if (tmpClientSocket != null)
			{
				tmpClientSocket.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				tmpClientSocket.socket.Blocking = tmpCheckBox.Checked;
				ClientConnect(tmpClientSocket, remoteEP);
				ButtonConnect.Enabled = false;
				ButtonReceive.Enabled = true;
				ButtonSend.Enabled = true;
			}
		}

		void ClientConnect(ClientSocket ClientSocket, IPEndPoint remoteEP)
		{
			ListBoxLog.Items.Add(string.Format("{0}.BeginConnect()", ClientSocket.Name));
			ClientSocket.socket.BeginConnect(remoteEP, result => {
				ClientSocket.socket.EndConnect(result);

				if (ListBoxLog.InvokeRequired)
				{
					ListBoxLog.Invoke(new MethodInvoker(delegate
					{
						ListBoxLog.Items.Add(string.Format("{0}.EndConnect()", ClientSocket.Name));
						ListBoxLog.Items.Add(string.Format("{0}.Connect() (Connected: {1})", ClientSocket1.Name, ClientSocket1.socket.Connected));
					}));
				}
				else
				{
					ListBoxLog.Items.Add(string.Format("{0}.EndConnect()", ClientSocket.Name));
					ListBoxLog.Items.Add(string.Format("{0}.Connect() (Connected: {1})", ClientSocket1.Name, ClientSocket1.socket.Connected));
				}
			}, null);
		}

		private void ButtonReceive_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if ((tmpButton = sender as Button) == null)
				return;

			ClientSocket
				Socket = null;

			switch (tmpButton.Name)
			{
				case "ButtonReceiveServer":
				{
					Socket = ServerSocket;
					break;
				}
				case "ButtonReceiveClient1":
				{
					Socket = ClientSocket1;
					break;
				}
			}

			if (Socket != null)
				Receive(Socket);
		}

		void Receive(ClientSocket Socket)
		{
			Socket
				s;

			if ((s = Socket.Sockets == null ? Socket.socket : (listBoxClients.SelectedIndex >= 0 && listBoxClients.SelectedIndex < Socket.Sockets.Count ? Socket.Sockets[listBoxClients.SelectedIndex] : null)) == null)
				return;

			ListBoxLog.Items.Add(string.Format("{0}.BeginReceive()", Socket.Name));
			s.BeginReceive(Socket.buffer, 0, Socket.buffer.Length, 0, new AsyncCallback(ReceiveCallback), Socket);
		}

		void ReceiveCallback(IAsyncResult ar)
		{
			ClientSocket
				Socket = (ClientSocket)ar.AsyncState;

			int
				SelectedIndex = -1;

			if (listBoxClients.InvokeRequired)
				listBoxClients.Invoke(new MethodInvoker(delegate { SelectedIndex = listBoxClients.SelectedIndex; }));
			else
				SelectedIndex = listBoxClients.SelectedIndex;

			Socket
				s;

			if ((s = Socket.Sockets == null ? Socket.socket : (SelectedIndex >= 0 && SelectedIndex < Socket.Sockets.Count ? Socket.Sockets[SelectedIndex] : null)) == null)
				return;

			int
				bytesRead = s.EndReceive(ar);

			if (ListBoxLog.InvokeRequired)
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(string.Format("{0}.EndReceive()", Socket.Name)); }));
			else
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(string.Format("{0}.EndReceive()", Socket.Name)); }));

			if (bytesRead > 0)
			{
				Socket.sb.Append(Encoding.ASCII.GetString(Socket.buffer, 0, bytesRead));

				if (s.Available > 0)
					s.BeginReceive(Socket.buffer, 0, Socket.buffer.Length, 0, new AsyncCallback(ReceiveCallback), Socket);
				else
				{
					if (Socket.sb.Length > 1)
					{
						string
							tmpString = Socket.sb.ToString();

						Socket.sb.Length = 0;
						if (ListBoxLog.InvokeRequired)
							ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(string.Format("{0} (Received {1} bytes Data {2})", Socket.Name, tmpString.Length, tmpString)); }));
						else
							ListBoxLog.Items.Add(string.Format("{0} (Received {1} bytes Data {2})", Socket.Name, tmpString.Length, tmpString));
					}
				}
			}
			else
			{
				if (Socket.sb.Length > 1)
				{
					string
						tmpString = Socket.sb.ToString();

					if (ListBoxLog.InvokeRequired)
						ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(string.Format("{0} (Received {1} bytes Data {2})", Socket.Name, tmpString.Length, tmpString)); }));
					else
						ListBoxLog.Items.Add(string.Format("{0} (Received {1} bytes Data {2})", Socket.Name, tmpString.Length, tmpString));
				}
			}
		}

		private void ButtonSend_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if ((tmpButton = sender as Button) == null)
				return;

			ClientSocket
				Socket = null;

			RichTextBox
				tmpRichTextBox=null;

			switch (tmpButton.Name)
			{
				case "ButtonSendServer":
				{
					Socket = ServerSocket;
					tmpRichTextBox = richTextBoxServer;

					break;
				}
				case "ButtonSendClient1":
				{
					Socket = ClientSocket1;
					tmpRichTextBox=richTextBoxClient1;

					break;
				}
			}

			if (Socket != null)
			{
				byte[]
					data=Encoding.ASCII.GetBytes(tmpRichTextBox.Text);

				Socket
					s;

				if ((s = Socket.Sockets == null ? Socket.socket : (listBoxClients.SelectedIndex >= 0 && listBoxClients.SelectedIndex < Socket.Sockets.Count ? Socket.Sockets[listBoxClients.SelectedIndex] : null)) == null)
					return;

				ListBoxLog.Items.Add(string.Format("{0}.BeginSend()", Socket.Name));
				s.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), Socket);
			}
		}

		void SendCallback(IAsyncResult ar)
		{
			ClientSocket
				Socket = (ClientSocket)ar.AsyncState;

			int
				SelectedIndex = -1;

			if (listBoxClients.InvokeRequired)
				listBoxClients.Invoke(new MethodInvoker(delegate { SelectedIndex = listBoxClients.SelectedIndex; }));
			else
				SelectedIndex = listBoxClients.SelectedIndex;

			Socket
				s;

			if ((s = Socket.Sockets == null ? Socket.socket : (SelectedIndex >= 0 && SelectedIndex < Socket.Sockets.Count ? Socket.Sockets[SelectedIndex] : null)) == null)
				return;

			int
				bytesSent = s.EndSend(ar);

			if (ListBoxLog.InvokeRequired)
				ListBoxLog.Invoke(new MethodInvoker(delegate { ListBoxLog.Items.Add(string.Format("{0}.EndSend() (Sent {1} bytes)", Socket.Name, bytesSent)); }));
			else
				ListBoxLog.Items.Add(string.Format("{0}.EndSend() (Sent {1} bytes)", Socket.Name, bytesSent));
		}
		
		private void MainForm_FormClosed(object sender, System.EventArgs e)
		{
			if (ClientSocket1 != null && ClientSocket1.socket!=null && ClientSocket1.socket.Connected)
			{
				ClientSocket1.socket.Shutdown(SocketShutdown.Both);
				ClientSocket1.socket.Close();
			}

			if (ServerSocket != null && ServerSocket.socket!=null && ServerSocket.socket.Connected)
			{
				ServerSocket.socket.Shutdown(SocketShutdown.Both);
				ServerSocket.socket.Close();
			}
		}
	}

	class ClientSocket
	{
		public Socket
			socket;

		public byte[]
			buffer;

		public string
			Name;

		public StringBuilder
			sb;

		public List<Socket>
			Sockets;

		public ClientSocket(string Name, int BufferLength)
		{
			this.Name = Name;
			this.buffer = new byte[BufferLength];
			this.sb = new StringBuilder();
			this.Sockets = null;
		}
	}
}
