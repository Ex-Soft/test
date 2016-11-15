<%@ Page language="c#" Codebehind="ParamForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.ParamForm" validateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ParamForm</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ParamForm" method="post" runat="server">
			<%= testStr1 %>
			<br>
			<%= testStr2 %>
			<br>
			<br>
			<asp:label id="ParagraphRequest" runat="server" />
		</form>
	</body>
</HTML>
