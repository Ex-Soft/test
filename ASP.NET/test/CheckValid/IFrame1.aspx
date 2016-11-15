<%@ Page language="c#" Codebehind="IFrame1.aspx.cs" AutoEventWireup="false" Inherits="CheckValid.IFrame1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IFrame1</title>
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
     str="IFrame1Form.onsubmit";

   alert(str);
   result=top.CheckForm(top,InvalidColor,'IFrame1Form');
   alert(str+"="+result);
   return(result);
}
// -->
		</script>
	</HEAD>
	<body onload="PrepareForm()">
		<form id="IFrame1Form" method="post" runat="server" onsubmit="return(TestSubmit())">
			<asp:Literal id="VarDef" runat="server" />
			IFrame1TextBox1&nbsp;<asp:TextBox id="IFrame1TextBox1" runat="server" />&nbsp;<asp:label id="IFrame1TextBox1Value" runat="server" /><br>
			IFrame1TextBox2&nbsp;<asp:TextBox id="IFrame1TextBox2" runat="server" />&nbsp;<asp:label id="IFrame1TextBox2Value" runat="server" /><br>
			IFrame1TextBox3&nbsp;<asp:TextBox id="IFrame1TextBox3" runat="server" />&nbsp;<asp:label id="IFrame1TextBox3Value" runat="server" /><br>
			<input type="submit" style="WIDTH: 0px; HEIGHT: 0px" onclick="alert('IFrame1BtnSubmit.onclick')" value=""><br>
			<asp:Label id="LabelInfo" runat="server" />
		</form>
	</body>
</HTML>
