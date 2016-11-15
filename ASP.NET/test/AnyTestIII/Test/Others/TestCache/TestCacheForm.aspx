<%@ Page language="c#" Codebehind="TestCacheForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestCacheForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Cache</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="TestCacheForm" method="post" runat="server">
			<h1 align="center">Common</h1>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxCCacheSet" Runat="server" /></td>
					<td><asp:Button ID="ButtonCCacheSet" Text="Set" Runat="server" /></td>
					<td><asp:TextBox ID="TextBoxCCacheGet" ReadOnly="True" Runat="server" /></td>
					<td><asp:Button ID="ButtonCCacheGet" Text="Get" Runat="server" /></td>
				</tr>
			</table>
			<h1 align="center">Session</h1>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxSCacheSet" Runat="server" /></td>
					<td><asp:Button ID="ButtonSCacheSet" Text="Set" Runat="server" /></td>
					<td><asp:TextBox ID="TextBoxSCacheGet" ReadOnly="True" Runat="server" /></td>
					<td><asp:Button ID="ButtonSCacheGet" Text="Get" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
