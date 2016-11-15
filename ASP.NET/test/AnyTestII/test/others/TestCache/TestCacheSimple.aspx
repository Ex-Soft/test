<%@ Import Namespace=System.Threading %>
<html>
	<head>
		<title>Chat ;)</title>
	</head>
	<body>
		<form runat="server">
			<h1>Chat ;)</h1>
			<asp:TextBox id="TextBoxSendMessage" runat="server" />
			<asp:Button id="ButtonSendMessage" Text="SendMessage" OnClick="ButtonSendMessageClick" runat="server" />
			<br />
			<asp:TextBox id="TextBoxReceiveMessage" readonly="true" runat="server" />
			<asp:Button id="ButtonReceiveMessage" Text="ReceiveMessage" OnClick="ButtonReceiveMessageClick" runat="server" />
		</form>
	</body>
</html>

<script language="C#" runat="server">
void ButtonSendMessageClick (Object sender, EventArgs e)
{
	ReaderWriterLock
		rwlock = new ReaderWriterLock();

	rwlock.AcquireWriterLock(Timeout.Infinite);
	try
	{
	    Cache["Chat"]=TextBoxSendMessage.Text.Trim();
	}
	finally
	{
		rwlock.ReleaseWriterLock();
	}
}

void ButtonReceiveMessageClick (Object sender, EventArgs e)
{
    ReaderWriterLock
		rwlock = new ReaderWriterLock();

	rwlock.AcquireReaderLock(Timeout.Infinite);
	try
	{
	    TextBoxReceiveMessage.Text = Cache["Chat"]!=null ? (string)Cache["Chat"] : "null";
    }
	finally
	{
		rwlock.ReleaseReaderLock();
	}
}
</script>