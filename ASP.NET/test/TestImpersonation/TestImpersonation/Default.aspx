<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestImpersonation.MainForm" %>
<!doctype html>
<html>
	<head>
		<meta charset="utf-8"/>
		<title>Test Forms Authentication</title>
	</head>
	<body>
	    <form id="MainForm" runat="server">
            <h1>MainForm</h1>
            <hr/>
	        <asp:Label id="LabelIsAuthenticated" runat="server" />
        </form>
	</body>
</html>