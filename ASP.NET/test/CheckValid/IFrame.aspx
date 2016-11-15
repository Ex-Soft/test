<%@ Page language="c#" Codebehind="IFrame.aspx.cs" AutoEventWireup="false" Inherits="CheckValid.IFrameStandalone" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IFrameStandalone</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="misc.js"></script>
		<script type="text/javascript">
<!--
function TestSubmit()
{
   var
     result,
     str="IFrameStandaloneForm.onsubmit";

   alert(str);
   result=top.CheckForm(top,InvalidColor,'IFrameStandaloneForm');
   alert(str+"="+result);
   return(result);
}
// -->
		</script>
	</HEAD>
	<body onload="PrepareForm()">
		<form id="IFrameStandaloneForm" method="post" runat="server" onsubmit="return(TestSubmit())">
			<asp:Literal id="VarDef" runat="server" />
			<asp:TextBox id="IFrameStandaloneTextBox1" runat="server" />&nbsp;<asp:label id="IFrameStandaloneTextBox1Value" runat="server" /><br>
			<asp:TextBox id="IFrameStandaloneTextBox2" runat="server" />&nbsp;<asp:label id="IFrameStandaloneTextBox2Value" runat="server" /><br>
			<asp:TextBox id="IFrameStandaloneTextBox3" runat="server" />&nbsp;<asp:label id="IFrameStandaloneTextBox3Value" runat="server" /><br>
			<input type="submit" style="WIDTH: 0px; HEIGHT: 0px" onclick="alert('IFrameStandaloneBtnSubmit.onclick')" value=""><br>
			<asp:Label id="LabelInfo" runat="server" />
		</form>
	</body>
</HTML>
