<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="TestStateServer2.MainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test StateServer</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
	<link type="text/css" href="mainform.css" rel="stylesheet" />
	<script type="text/javascript" src="MainForm.js"></script>
</head>
<body onload="OnLoad()">
    <form id="MainForm" onsubmit="clInterval(); return(true);" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td valign="middle">Now:</td>
					<td valign="middle"><span id="SpanTime" class="TimeTimer"></span>&nbsp;<span id="SpanHelicopter" class="TimeHelicopter"></span></td>
					<td valign="middle">Start:</td>
					<td valign="middle"><asp:TextBox ID="TextBoxTime" ReadOnly="True" Runat="server" /></td>
					<td valign="middle">Count:</td>
					<td valign="middle"><asp:TextBox ID="TextBoxSubmit" ReadOnly="True" Runat="server" /></td>
					<td valign="middle"><asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" Runat="server" /></td>
				</tr>
			</table>
    </form>
</body>
</html>
