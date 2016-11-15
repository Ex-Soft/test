<%@ Page language="c#" Codebehind="error.aspx.cs" AutoEventWireup="false" Inherits="TestApplicationError.error" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Error</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
	</HEAD>
	<body>
		<form id="ErrorForm" method="post" runat="server">
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>Message</td>
					<td><asp:Label ID="LabelMessage" Runat="server" /></td>
				</tr>
				<tr>
					<td>Source</td>
					<td><asp:Label ID="LabelSource" Runat="server" /></td>
				</tr>
				<tr>
					<td>StackTrace</td>
					<td><asp:Label ID="LabelStackTrace" Runat="server" /></td>
				</tr>
				<tr>
					<td>TargetSite</td>
					<td><asp:Label ID="LabelTargetSite" Runat="server" /></td>
				</tr>
				<tr>
					<td>InnerException.Message</td>
					<td><asp:Label ID="LabelInnerExceptionMessage" Runat="server" /></td>
				</tr>
				<tr>
					<td>InnerException.Source</td>
					<td><asp:Label ID="LabelInnerExceptionSource" Runat="server" /></td>
				</tr>
				<tr>
					<td>InnerException.StackTrace</td>
					<td><asp:Label ID="LabelInnerExceptionStackTrace" Runat="server" /></td>
				</tr>
				<tr>
					<td>InnerException.TargetSite</td>
					<td><asp:Label ID="LabelInnerExceptionTargetSite" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
