<%@ Page language="c#" Codebehind="IFrame2.aspx.cs" AutoEventWireup="false" Inherits="CheckValid.IFrame2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IFrame2</title>
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
     str="IFrame2Form.onsubmit";

   alert(str);
   result=top.CheckForm(top,InvalidColor,'IFrame2Form');
   alert(str+"="+result);
   return(result);
}
// -->
		</script>
	</HEAD>
	<body onload="PrepareForm()">
		<form id="IFrame2Form" method="post" runat="server" onsubmit="return(TestSubmit())">
			<asp:Literal id="VarDef" runat="server" />
			IFrame2TextBox1&nbsp;<asp:TextBox id="IFrame2TextBox1" runat="server" />&nbsp;<asp:label id="IFrame2TextBox1Value" runat="server" /><br>
			IFrame2TextBox2&nbsp;<asp:TextBox id="IFrame2TextBox2" runat="server" />&nbsp;<asp:label id="IFrame2TextBox2Value" runat="server" /><br>
			IFrame2TextBox3&nbsp;<asp:TextBox id="IFrame2TextBox3" runat="server" />&nbsp;<asp:label id="IFrame2TextBox3Value" runat="server" /><br>
			<input type="submit" style="WIDTH: 0px; HEIGHT: 0px" onclick="alert('IFrame2BtnSubmit.onclick')" value=""><br>
			<asp:Label id="LabelInfo" runat="server" />
		</form>
	</body>
</HTML>
