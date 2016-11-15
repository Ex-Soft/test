<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.MainIFrameForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainIFrameForm</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript">
<!--
var
	S=true;
	
function SubmitIFrame()
{
	for(var iFrame=0; iFrame<window.frames.length; ++iFrame)
	   for(var iForm=0; iForm<window.frames[iFrame].document.forms.length; ++iForm)
			window.frames[iFrame].document.forms[iForm].submit();
}

function SetIFrameCheckBox()
{
	var
		Ctrl,
		CheckBoxName="CheckBoxWithSleep",
		v;
	
	if(!(Ctrl=document.getElementById(CheckBoxName)))
		return;

	v=Ctrl.checked;
			
	if(Ctrl=document.getElementById("IFrame1"))
	{
		if(Ctrl=Ctrl.contentWindow.document.getElementById(CheckBoxName))
			Ctrl.checked=v;
	}
	if(Ctrl=document.getElementById("IFrame2"))
	{
		if(Ctrl=Ctrl.contentWindow.document.getElementById(CheckBoxName))
			Ctrl.checked=v;
	}
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="MainForm" onsubmit="SubmitIFrame(); return(S)" method="post" runat="server">
			<input id="CheckBoxSubmitMainForm" onclick="S=this.checked" type="checkbox" name="CheckBoxSubmitMainForm"
				checked>&nbsp;Submit MainForm&nbsp; (<input id="CheckBoxWithSleep" onclick="SetIFrameCheckBox()" type="checkbox" name="CheckBoxWithSleep">&nbsp;with 
			Sleep)<br>
			<input id="btnSubmit" type="submit" value="Submit" name="btnSubmit"><br>
			<asp:textbox id="MainFormTextBoxInput1" Runat="server"></asp:textbox><br>
			<asp:textbox id="MainFormTextBoxInput2" Runat="server"></asp:textbox><br>
			MainFormTextBoxInput1="<asp:Label ID="LabelMainFormTextBoxInput1" runat="server" />"<br>
			MainFormTextBoxInput2="<asp:Label ID="LabelMainFormTextBoxInput2" runat="server" />"<br>
			FrameForm1TextBoxInput1="<asp:Label ID="LabelFrameForm1TextBoxInput1" runat="server" />"<br>
			FrameForm1TextBoxInput2="<asp:Label ID="LabelFrameForm1TextBoxInput2" runat="server" />"<br>
			FrameForm2TextBoxInput1="<asp:Label ID="LabelFrameForm2TextBoxInput1" runat="server" />"<br>
			FrameForm2TextBoxInput2="<asp:Label ID="LabelFrameForm2TextBoxInput2" runat="server" />"<br>
			<table cellpadding="0" cellspacing="0" border="1">
				<tr height="32%">
					<td><iframe id="IFrame1" name="IFrame1" frameBorder="0" border="0" framespacing="0" marginwidth="0" marginheight="0" hspace="0" vspace="0" style="WIDTH: 100%; HEIGHT: 100%; " runat="server"></iframe></td>
				</tr>
				<tr>
					<td><iframe id="IFrame2" name="IFrame2" style="BORDER-RIGHT: 0px solid; BORDER-TOP: 0px solid; BORDER-LEFT: 0px solid; BORDER-BOTTOM: 0px solid" runat="server"></iframe></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
