<%@ Page language="c#" Codebehind="ChildPage.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestTwoPageChildPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Two Page (Child Page)</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function OnSubmit()
{
	var
		Src,
		Dest;
	
	if((Src=document.getElementById("TextBoxOnChildPage"))
		&& (Dest=window.opener.document.getElementById("TextBoxOnMainPage")))
		Dest.value=Src.value;
	window.close();
	return(true);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestTwoPageChildPageForm" onsubmit="return(OnSubmit());" method="post" runat="server">
			<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxOnChildPage" Runat="server" /></td>
					<td><asp:Button ID="ButtonSubmit" Text="Submit" Runat="server" /></td>
					<td><asp:Label ID="LabelSubmit" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
