<%@ Page language="c#" Codebehind="TestAutoPostBackI.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestAutoPostBackIForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Test AutoPostBack I</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function OnLoad()
{
	var
		Ctrl;
		
	if(Ctrl=document.getElementById("TestAutoPostBackIForm"))
	{
		Ctrl.oldsubmit=Ctrl.submit;
		Ctrl.submit=function(){this.onsubmit();this.oldsubmit()};
	}
}
// -->
		</script>
	</head>
	<body onload="OnLoad()">
		<form id="TestAutoPostBackIForm" onsubmit="alert('<form ... onsubmit... >')" method="post" runat="server">
			<asp:CheckBox ID="CheckBoxAutoPostBack" Text="CheckBoxAutoPostBack" TextAlign="Right" AutoPostBack="True" Runat="server" />
			<br>
			<asp:Label ID="LabelInfo" Runat="server" />
		</form>
	</body>
</html>
