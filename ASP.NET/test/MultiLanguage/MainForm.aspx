<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="MultiLanguage.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainForm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="MainForm" method="post" runat="server">
			<asp:Label id="LabelHeader" Runat="server">Label</asp:Label><br>
			<asp:HyperLink ID="HyperLinkEnglis" NavigateUrl="?Culture=en-US" Runat="server">English</asp:HyperLink>&nbsp;
			<asp:HyperLink ID="HyperLinkRusshian" NavigateUrl="?Culture=ru-RU" Runat="server">Russian</asp:HyperLink>
		</form>
	</body>
</HTML>
