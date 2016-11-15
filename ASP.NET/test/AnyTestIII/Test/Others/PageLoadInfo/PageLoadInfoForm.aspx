<%@ Page language="c#" Codebehind="PageLoadInfoForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.PageLoadInfoForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Page Load Info Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="PageLoadInfoForm.js" type="text/javascript"></script>
		<link rel="stylesheet" href="PageLoadInfoForm.css" type="text/css">
	</HEAD>
	<body onload="SetPageLoadInfo('PLS','SpanStarted','SpanFinished','SpanDiffTime')">
		<form id="PageLoadInfoForm" method="post" runat="server">
			<div id="DivPageLoadInfo" class="div_upper_hidden" onmouseover="this.className='div_upper_visible'" onmouseout="this.className='div_upper_hidden'">
				Начало:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id="SpanStarted" class="PageLoadInfo"></span><br>Окончание:&nbsp;<span id="SpanFinished" class="PageLoadInfo"></span><br>Время&nbsp;загрузки:&nbsp;<span id="SpanDiffTime" class="PageLoadInfo"></span>&nbsp;секунд
			</div>
		</form>
	</body>
</HTML>
