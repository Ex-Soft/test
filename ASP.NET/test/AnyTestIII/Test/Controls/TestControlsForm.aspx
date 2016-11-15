<%@ Page language="c#" Codebehind="TestControlsForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestControlsForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Controls Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Test_Controls_Form" method="post" runat="server">
			<asp:Button ID="Button1" Text="Button1" Runat="server" />
			<input type="button" ID="HtmlInputButton1" value="HtmlInputButton1" Runat="server">
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="1">
				<tr>
					<td><asp:Button ID="Button2" Text="Button2" Runat="server" /></td>
					<td><input type="button" ID="HtmlInputButton2" value="HtmlInputButton2" Runat="server"></td>
				</tr>
				<tr>
					<td colspan="2">
						<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="1">
							<tr>
								<td><asp:Button ID="Button3" Text="Button3" Runat="server" /></td>
								<td><input type="button" ID="HtmlInputButton3" value="HtmlInputButton3" Runat="server"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:Button ID="ButtonDisable" Text="Disable" Runat="server" /></td>
					<td><input type="button" ID="HtmlButtonDisable" value="Disable" Runat="server"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
