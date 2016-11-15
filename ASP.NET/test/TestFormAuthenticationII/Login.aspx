<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="TestFormAuthentication.LoginForm" %>
<%@ Register TagPrefix="user" TagName="SignInII" src="SignInII.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="False" name="vs_snapToGrid">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="LoginForm" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td align="center">Login</td>
				</tr>
				<tr>
					<td><user:SignInII id="objSignInII" AppSettingsKeyLogin="Login" AppSettingsKeyPassword="Password" DataSource="WebConfig" runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
