<%@ Page language="c#" Codebehind="TestActionMainForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestActionMainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Action (MainForm)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function OnLoad()
{
	var
		Ctrl;
		
	if(!(Ctrl=document.getElementById("Test_Action_Main_Form")))
		return;
		
	Ctrl.action="TestActionDestForm.aspx";
}
// -->
		</script>
	</HEAD>
	<body onload="OnLoad()">
		<h1>Main Form</h1>
		<hr>
		<form id="Test_Action_Main_Form" method="post" action="TestActionDestForm.aspx" runat="server">
			<asp:TextBox ID="TextBox1" Runat="server" />
			<asp:Button ID="Button1" Text="Submit" Runat="server" />
		</form>
	</body>
</HTML>
