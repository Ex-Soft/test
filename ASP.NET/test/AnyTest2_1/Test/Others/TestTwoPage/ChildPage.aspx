<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChildPage.aspx.cs" Inherits="AnyTest2_1.TestTwoPageChildPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
		<title>Test Two Page (Child Page)</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
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
    </head>
    <body>
		<form id="TestTwoPageChildPageForm" onsubmit="return(OnSubmit());" method="post" runat="server">
			<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:TextBox ID="TextBoxOnChildPage" Runat="server" /></td>
					<td><asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" Runat="server" /></td>
					<td><asp:Label ID="LabelSubmit" Runat="server" /></td>
				</tr>
			</table>
		</form>
    </body>
</html>
<!-- OnClick="ButtonSubmit_Click" -->
<!-- OnClientClick="OnSubmit()" -->