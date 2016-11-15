<%@ Page language="c#" Codebehind="IFrameThermoForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.IFrameThermoForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IFrame Thermometer Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<script type="text/javascript">
<!--
var
	iFramesCount=3;
// -->
		</script>
	</HEAD>
	<body>
		<form id="IFrameThermoForm" method="post" runat="server">
			<!-- #include virtual="blockwin.inc" -->
			<iframe src="IFrame1.aspx"></iframe>
			<iframe src="IFrame2.aspx"></iframe>
			<iframe src="IFrame3.aspx"></iframe>
		</form>
	</body>
</HTML>
