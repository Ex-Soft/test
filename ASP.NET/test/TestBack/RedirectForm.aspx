<%@ Page language="c#" Codebehind="RedirectForm.aspx.cs" AutoEventWireup="false" Inherits="TestBack.RedirectForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Redirect Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
	</HEAD>
	<body>
		<h1>Redirect Form</h1>
		<form id="RedirectForm" method="post" runat="server">
			<input type="button" id="ButtonGoTo" value="GoTo" onclick="history.go(-1)">
			<input type="button" id="ButtonBack" value="Back" onclick="history.back()">
		</form>
	</body>
</HTML>
