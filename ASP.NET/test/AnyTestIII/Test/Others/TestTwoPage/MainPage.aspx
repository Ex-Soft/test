<%@ Page language="c#" Codebehind="MainPage.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestTwoPageMainPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Two Page (Main Page)</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="TestTwoPageMainPageForm" method="post" runat="server">
			<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxOnMainPage" Runat="server" /></td>
					<td><input type="button" id="ButtonOpen" value="Open" onclick="window.open('ChildPage.aspx','Child');"></td>
					<td><asp:Button ID="ButtonGetSessionValue" Text="Get Session Value" Runat="server" /></td>
					<td><asp:Label ID="LabelSessionValue" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
