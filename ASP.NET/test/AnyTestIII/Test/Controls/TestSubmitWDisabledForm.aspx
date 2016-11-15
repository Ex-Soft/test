<%@ Page language="c#" Codebehind="TestSubmitWDisabledForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSubmitWDisabledForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Submit with Disabled Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<script type="text/javascript">
<!--
function OnSubmit()
{
	var
		Ctrl;

	if(Ctrl=document.getElementById("btnHTMLSubmit"))
		Ctrl.disabled=true;
		
	if((Ctrl=document.getElementById("CheckBoxASPButtonSubmitWithDisabled"))
		&& Ctrl.checked
		&& (Ctrl=document.getElementById("btnASPSubmit")))
	Ctrl.disabled=true;

	return(true);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="SubmitWDisabledForm" method="post" onsubmit="return(OnSubmit());" runat="server">
			<table style="width: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>Sleep:</td>
					<td><asp:TextBox ID="TextBoxSleep" Text="5" Runat="server" /></td>
					<td>(sec)</td>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBoxHTMLSubmit" Runat="server" /></td>
					<td><input type="submit" id="btnHTMLSubmit" value="Submit"></td>
					<td><asp:Label ID="LabelHTMLSubmit" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBoxASPSubmit" Runat="server" /></td>
					<td>
						<table style="width: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td><asp:Button ID="btnASPSubmit" Text="Submit" Runat="server" /></td>
								<td>With Disabled</td>
								<td><input type="checkbox" id="CheckBoxASPButtonSubmitWithDisabled"></td>
							</tr>
						</table>
					</td>
					<td><asp:Label ID="LabelASPSubmit" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
