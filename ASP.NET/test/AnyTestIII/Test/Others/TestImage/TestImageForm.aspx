<%@ Page language="c#" Codebehind="TestImageForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestImageForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Image</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body>
		<form id="TestImageForm" method="post" runat="server">
			<asp:Image ID="Image1" ImageUrl="CreateImageForm.aspx" Runat="server" />
		</form>
	</body>
</HTML>
