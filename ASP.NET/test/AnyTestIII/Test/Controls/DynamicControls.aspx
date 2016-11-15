<%@ Page language="c#" Codebehind="DynamicControls.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DynamicControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Dynamic Controls</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta http-equiv="cache-control" content="no-cache">
		<meta content="False" name="vs_snapToGrid">
	</HEAD>
	<body>
		<form id="DynamicControlsForm" method="post" runat="server">
			<fieldset><legend>&nbsp;OnPageInit&nbsp;</legend>
				Button with OnClick&nbsp;<asp:PlaceHolder ID="PlaceHolderButtonOnClickOnInit" Runat="server" /><br>
				Button with OnCommand&nbsp;<asp:PlaceHolder ID="PlaceHolderButtonOnCommandOnInit" Runat="server" />
			</fieldset>
			<fieldset><legend>&nbsp;OnPageLoad&nbsp;</legend>
				Button with OnClick&nbsp;<asp:PlaceHolder ID="PlaceHolderButtonOnClickOnLoad" Runat="server" /><br>
				Button with OnCommand&nbsp;<asp:PlaceHolder ID="PlaceHolderButtonOnCommandOnLoad" Runat="server" />
			</fieldset>
			<br>
			<asp:TextBox ID="TextBoxButtonEventSender" Width="100%" Runat="server" />
		</form>
	</body>
</HTML>
