<%@ Page language="c#" Codebehind="AnyTestSmlForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.AnyTestSmlForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Any Test Small</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
	</HEAD>
	<body>
		<form id="AnyTestSmlForm" method="post" runat="server">
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td align="right"><asp:Label ID="LabelDone" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="ButtonTestTransaction" Text="Transaction" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="ButtonTestExecuteNonQuery" Text="ExecuteNonQuery" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="ButtonDownloadImageFromBLOB" Text="Download Image Fom BLOB" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
