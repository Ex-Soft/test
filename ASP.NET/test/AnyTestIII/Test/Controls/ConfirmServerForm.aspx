<%@ Page language="c#" Codebehind="ConfirmServerForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.ConfirmServerForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Confirm Server Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body onload="OnLoad()">
		<form id="ConfirmServerForm" method="post" runat="server">
			<asp:Literal ID="LiteralConfirm" Runat="server" />
			<script type="text/javascript">
<!--
function OnLoad()
{
	var
		Ctrl;
	
	if(!(Ctrl=document.getElementById("HiddenConfirmResult")))
		return;
		
	Ctrl.value=false;
		
	if(ConfirmStr
		&& (Ctrl.value=confirm(ConfirmStr))
		&& (Ctrl=document.getElementById("ButtonSubmit")))
		Ctrl.click();
}
// -->
			</script>
			<asp:Button ID="ButtonSubmit" Text="Submit" Runat="server" />
			<input type="hidden" id="HiddenConfirmResult" runat="server">
		</form>
	</body>
</HTML>
