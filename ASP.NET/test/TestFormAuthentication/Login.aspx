<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestFormAuthentication.LoginForm" %>
<%@ Register TagPrefix="user" TagName="SignIn" src="SignIn.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>&laquo;Login&raquo;</title>
</head>
<body>
    <form id="LoginForm" runat="server">
		<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td><user:SignIn id="objSignIn" OnLogin="objSignIn_Login" runat="server" /></td>
			</tr>
		</table>
    </form>
</body>
</html>
