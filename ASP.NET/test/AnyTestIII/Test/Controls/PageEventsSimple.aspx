<%@ Page language="c#" Codebehind="PageEventsSimple.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.PageEventsSimple" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Page Events (simple)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body>
		<form id="PageEventsSimpleForm" method="post" runat="server">
			<asp:DropDownList ID="DropDownList1" Runat="server">
				<asp:ListItem Value="1">1st</asp:ListItem>
				<asp:ListItem Value="2" Selected="True">2nd</asp:ListItem>
				<asp:ListItem Value="3">3rd</asp:ListItem>
			</asp:DropDownList><br />
			<asp:TextBox ID="TextBox1" Runat="server" /><br />
			<input type="submit" value="submit"><br />
			<asp:Label ID="Label1" EnableViewState="False" Runat="server" />
		</form>
	</body>
</HTML>
