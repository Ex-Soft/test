<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestActionMainForm.aspx.cs" Inherits="AnyTest2_1.TestActionMainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>Test Action (MainForm)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<meta name="vs_snapToGrid" content="False" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<script type="text/javascript">
<!--
function OnLoad()
{
	var
		Ctrl;
		
	if(!(Ctrl=document.getElementById("TestActionMainForm")))
		return;
		
	Ctrl.action="TestActionDestForm.aspx";
}
// -->
		</script>
</head>
<body onload="OnLoad()">
	<h1>Main Form</h1>
	<hr />
    <form id="TestActionMainForm" method="post" action="TestActionDestForm.aspx" runat="server">
		<asp:TextBox ID="TextBox1" Runat="server" />
		<asp:Button ID="Button1" Text="Submit" Runat="server" />
    </form>
</body>
</html>
