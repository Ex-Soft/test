<%@ Page language="c#" Codebehind="TestEnableEventValidationForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestEnableEventValidationForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test EnableEventValidationForm</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function ChangeDropDownListVictim()
{
    var
        Ctrl;
        
    if(!(Ctrl=document.getElementById("DropDownListVictim")))
        return;
        
    Ctrl.options.length=0;
    for(var i=10; i<15; ++i)
        Ctrl.options.add(new Option(i,i,false,false));
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestEnableEventValidationForm" method="post" runat="server">
			<asp:DropDownList ID="DropDownListVictim" runat="server" /><br>
			<input type="button" id="ButtonChangeDropDownListVictim" value="ChangeDropDownListVictim" onclick="ChangeDropDownListVictim()"><br>
			<asp:Button ID="ButtonSubmit" Text="Submit" runat="server" /><br>
			<asp:Label ID="LabelInfo" runat="server" />
		</form>
	</body>
</HTML>
