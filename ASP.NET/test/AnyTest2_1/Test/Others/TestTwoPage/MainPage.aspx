<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="AnyTest2_1.TestTwoPageMainPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
		<title>Test Two Page (Main Page)</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    </head>
    <body>
        <form id="TestTwoPageMainPageForm" method="post" runat="server">
			<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxOnMainPage" Runat="server" /></td>
					<td><input type="button" id="ButtonOpen" value="Open" onclick="window.open('ChildPage.aspx','Child');" /></td>
					<td><asp:Button ID="ButtonGetSessionValue" Text="Get Session Value" Runat="server" OnClick="ButtonGetSessionValue_Click" /></td>
					<td><asp:Label ID="LabelSessionValue" Runat="server" /></td>
				</tr>
			</table>
		</form>
    </body>
</html>