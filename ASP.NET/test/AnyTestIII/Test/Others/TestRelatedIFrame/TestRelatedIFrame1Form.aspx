<%@ Page language="c#" Codebehind="TestRelatedIFrame1Form.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestRelatedIFrame1Form" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Related IFrame (IFrame I)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<asp:Literal ID="JS" Runat="server" />
		<form id="TestRelatedIFrame1Form" method="post" runat="server">
			<input type="text" id="HtmlInputText1">
			<input type="button" id="HtmlInputButton1" value="WO Submit" onclick="parent.document.getElementById('iframe2').src='TestRelatedIFrame2Form.aspx?data='+document.getElementById('HtmlInputText1').value">
			<asp:Button ID="ButtonSubmit" Text="Submit" Runat="server" />
			<asp:Label ID="LabelInfo" Runat="server" />
		</form>
	</body>
</HTML>
