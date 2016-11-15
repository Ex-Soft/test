<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="TestStateServer.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test StateServer</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<link type="text/css" href="mainform.css" rel="stylesheet">
		<script type="text/javascript" src="MainForm.js"></script>
	</HEAD>
	<body onload="OnLoad()">
		<form id="MainForm" onsubmit="clInterval(); return(true);" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td valign="middle">Now:</td>
					<td valign="middle"><span id="SpanTime" class="TimeTimer"></span>&nbsp;<span id="SpanHelicopter" class="TimeHelicopter"></span></td>
					<td valign="middle">Start:</td>
					<td valign="middle"><asp:TextBox ID="TextBoxTime" ReadOnly="True" Runat="server" /></td>
					<td valign="middle">Count:</td>
					<td valign="middle"><asp:TextBox ID="TextBoxSubmit" ReadOnly="True" Runat="server" /></td>
					<td valign="middle"><asp:Button ID="ButtonSubmit" Text="Submit" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
