<%@ Page language="c#" Codebehind="TestSubmit.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSubmit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Submit II</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body>
		<form id="TestSubmitIIForm" method="post" runat="server">
			<input type="submit" name="ddd" value="b1">
			<input type="submit" name="ddd" value="b2">
			<input type="submit" name="ddd" value="b3">
			<input type="text" name="i1" value="1">
			<input type="text" name="i2" value="1">
			<input type="text" name="i3" value="1">
			<hr>
			<asp:Label ID="Label1" EnableViewState="False" Runat="server" />
		</form>
		<input type="button" onclick="document.getElementById('TestSubmitIIForm').submit()" value="test 'submit'">
	</body>
</HTML>
