<%@ Page language="c#" Codebehind="TestRelatedIFrameMainForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestRelatedIFrameMainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Related IFrame (MainForm)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="TestRelatedIFrameMainForm" method="post" runat="server">
			<iframe id="iframe1" src="TestRelatedIFrame1Form.aspx"></iframe>
			<iframe id="iframe2" src="TestRelatedIFrame2Form.aspx"></iframe>
		</form>
	</body>
</HTML>
