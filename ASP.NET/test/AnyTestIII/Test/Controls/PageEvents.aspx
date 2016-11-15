<%@ Page language="c#" Codebehind="PageEvents.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.PageEvents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Page Events</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function AddCtrl()
{
	var
		c,
		i;
		
	if(!(c=document.getElementById("Container")))
		return;
		
	if(!(i=document.createElement("INPUT")))
		return;

	i.type="text";		
	i.id="<%=DynamicInput1Id%>";
	i.name="<%=DynamicInput1Id%>";
	c.appendChild(i);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="PageEventsForm" method="post" runat="server">
			<span id="Container" runat="server"></span>&nbsp;<span id="ContainerServer" runat="server"></span>
			<br>
			<input type="button" id="btnAddCtrl" name="btnAddCtrl" value="Add Control" onclick="AddCtrl()"><br>
			<input type="submit" id="btnSubmit" name="btnSubmit" value="Submit"><br>
			<asp:Label id="ParagraphRequest" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
