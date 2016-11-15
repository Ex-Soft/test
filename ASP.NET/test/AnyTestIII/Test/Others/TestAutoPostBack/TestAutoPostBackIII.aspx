<%@ Page language="c#" Codebehind="TestAutoPostBackIII.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestAutoPostBackIIIForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test AutoPostBack III</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function DoOnSubmit()
{
	alert("DoOnSubmit()");
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestAutoPostBackIIIForm" method="post" runat="server">
			<asp:CheckBox ID="CheckBoxAutoPostBack" Text="CheckBoxAutoPostBack" TextAlign="Right" AutoPostBack="True" Runat="server" />
			<br>
			<asp:Label ID="LabelInfo" Runat="server" />
		</form>
	</body>
</HTML>
