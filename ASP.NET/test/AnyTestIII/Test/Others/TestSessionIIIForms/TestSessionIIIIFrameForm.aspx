<%@ Page language="c#" Codebehind="TestSessionIIIIFrameForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSessionIIIIFrameForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Session III IFrame Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- <meta http-equiv="Refresh" content="300"> -->
		<script type="text/javascript">
<!--
function OnLoad()
{
	if(!<%=SessionExists.ToString().ToLower()%>)
	{
		alert("<%=Msg%>");
		parent.location.href="../TestSessionIIForm/TestSessionIIForm.aspx";
	}
}
// -->
		</script>
	</HEAD>
	<body onload="OnLoad()" style="background-color: red; ">
		<form id="TestSessionIIIIFrameForm" method="post" runat="server">
		</form>
	</body>
</HTML>
