<%@ Page language="c#" Codebehind="HtmlAspxMainForm.aspx.cs" AutoEventWireup="false" Inherits="TestSearch.HtmlAspxMainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Html and Aspx (MainForm)</title>
		<meta content="False" name="vs_snapToGrid">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="HtmlAspxMainForm" method="post" runat="server">
			<table style="width: 100%; height: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td>
						<iframe id="IFrameSearchParameters" name="IFrameSearchParameters" style="width: 100% ; height: 100%; " runat="server"></iframe>
					</td>
				</tr>
				<tr>
					<td>
						<iframe id="IFrameSearchResult" name="IFrameSearchResult" src="HtmlAspxSearchResult.aspx" style="width: 100% ; height: 100%; "></iframe>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
