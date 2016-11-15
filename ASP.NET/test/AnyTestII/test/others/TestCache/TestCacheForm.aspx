<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCacheForm.aspx.cs" Inherits="AnyTestII.TestCacheForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Test Cache</title>
</head>
<body>
    <form id="TestCacheForm" runat="server">
		<h1 align="center">Common</h1>
		<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td><asp:TextBox ID="TextBoxCCacheSet" Runat="server" /></td>
				<td><asp:Button ID="ButtonCCacheSet" Text="Set" OnClick="ButtonCacheSet_Click" Runat="server" /></td>
				<td><asp:TextBox ID="TextBoxCCacheGet" ReadOnly="True" Runat="server" /></td>
				<td><asp:Button ID="ButtonCCacheGet" Text="Get" OnClick="ButtonCacheGet_Click" Runat="server" /></td>
			</tr>
		</table>
		<h1 align="center">Session</h1>
		<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td><asp:TextBox ID="TextBoxSCacheSet" Runat="server" /></td>
				<td><asp:Button ID="ButtonSCacheSet" Text="Set" OnClick="ButtonCacheSet_Click" Runat="server" /></td>
				<td><asp:TextBox ID="TextBoxSCacheGet" ReadOnly="True" Runat="server" /></td>
				<td><asp:Button ID="ButtonSCacheGet" Text="Get" OnClick="ButtonCacheGet_Click" Runat="server" /></td>
			</tr>
		</table>
    </form>
</body>
</html>
