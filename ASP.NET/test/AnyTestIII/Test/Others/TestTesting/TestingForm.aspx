<%@ Page language="c#" Codebehind="TestingForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestingForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Testing</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link type="text/css" href="testingform.css" rel="stylesheet">
		<script type="text/javascript">
<!--
var
	DelaySleepNextPage=<%=DelaySleepNextPage%>;
// -->
		</script>
		<script type="text/javascript" src="TestingForm.js"></script>
	</HEAD>
	<body onload="OnLoad()">
		<form id="TestingForm" onsubmit="clInterval(); return(true);" method="post" runat="server">
			<table style="width: 100%; " cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>
						<asp:Label ID="LabelQuestionText" Runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						<asp:Panel ID="PanelRadio" Runat="server">
							<asp:RadioButtonList ID="RadioButtonListAnswers" Runat="server" />
						</asp:Panel>
					</td>
				</tr>
				<tr>
					<td>
						<div id="DivRemainingTimeTimer" runat="server">
							<table style="width: 100%; " cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td>
										<p class="RemainingTimeTitle">Залишилося</p>
									</td>
									<td>
										<p class="RemainingTimeTimer"><span id="SpanRemainingTimeTimer"></span>&nbsp;сек</p>
									</td>
									<td>
										<p class="RemainingTimeHelicopter">[<span id="SpanRemainingTimePropeller"></span>]</p>
									</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:Button ID="btnNext" Text="Next >" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
