<%@ Page language="c#" Codebehind="TestTables.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestTables" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Tables</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<script type="text/javascript">
<!--
function ShowTBody(id)
{
	var
		Ctrl;

	if(!(Ctrl=document.getElementById(id)))
		return;

	Ctrl=Ctrl.getElementsByTagName("TBODY");
	alert("\""+id+"\": TBODY="+Ctrl.length);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestTablesForm" method="post" runat="server">
			<h1>asp:Table</h1>
			<asp:Table ID="ASPTable1" Runat="server" />
			<hr>
			<input type="button" value="GetTBody" onclick="ShowTBody('ASPTable1')">
			<br>
			<h1>table</h1>
			<table id="HtmlTable1" />
			<hr>
			<input type="button" value="GetTBody" onclick="ShowTBody('HtmlTable1')">
			<br>
			<h1>table</h1>
			<table id="HtmlTable2"></table>
			<hr>
			<input type="button" value="GetTBody" onclick="ShowTBody('HtmlTable2')">
			<br>
			<h1>table</h1>
			<table id="HtmlTable3">
				<tbody />
			</table>
			<hr>
			<input type="button" value="GetTBody" onclick="ShowTBody('HtmlTable3')">
			<br>
		</form>
	</body>
</HTML>
