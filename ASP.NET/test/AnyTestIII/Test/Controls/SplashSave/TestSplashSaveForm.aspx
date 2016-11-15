<%@ Page language="c#" Codebehind="TestSplashSaveForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSplashSaveForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Splash Save</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<script type="text/javascript" src="TestSplashSaveForm.js"></script>
	</HEAD>
	<body>
		<div id="DivSplashSave" style="display: none; ">
			<iframe id="IFrameSplashSave" name="IFrameSplashSave" src="SplashSave.html" frameborder="0" scrolling="no" style="width: 100%; height: 100%; border-style: none; "></iframe>
		</div>
		<div id="DivMainForm" style="display: block; ">
			<form id="TestSplashSaveForm" method="post" onsubmit="return OnSubmit();" runat="server">
				<asp:TextBox ID="TextBoxSmth" Runat="server" />
				<br>
				<asp:CheckBox ID="CheckBoxWithRedirect" Checked="False" Text="With Redirect" TextAlign="Right" Runat="server" />
				<br>
				<asp:Button ID="SaveButton" Text="Save" Runat="server" />
			</form>
		</div>
	</body>
</HTML>
