<%@ Page language="c#" Codebehind="SimpleValidatorForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.SimpleValidatorForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<title>Simple Validator Form</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
	</HEAD>
	<body>
		<form id="SimpleValidatorForm" method="post" runat="server">
			<asp:TextBox ID="TextBox1" Runat="server" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" Display="Static" ErrorMessage="Required Field" EnableClientScript="True" Enabled="True" Runat="server" />
			<asp:Button ID="Button1" Text="Submit" Runat="server" />
			<asp:Label ID="Label1" Runat="server" />
		</form>
	</body>
</HTML>
