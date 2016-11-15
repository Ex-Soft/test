<%@ Page language="c#" Codebehind="TestSessionIIForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSessionIIForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Session II Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- <meta http-equiv="Refresh" content="300"> -->
		<script type="text/javascript">
<!--
var
	h=null;
	
function btnSubmitClick()
{
	var
		Ctrl;
		
	if(!(Ctrl=document.getElementById("btnSubmit")))
		return;
		
	Ctrl.click();
}

function TimerOnOff()
{
	var
		Ctrl,
		Str=null;
		
	if(!(Ctrl=document.getElementById("CheckBoxTimerOn")))
		return;
		
	if(Ctrl.checked)
	{
		Str="On";
		if(!h)
		{
			if((Ctrl=document.getElementById("TextBoxTimerInterval"))
				&& !isNaN(parseInt(Ctrl.value,10)))
				h=setInterval("btnSubmitClick()",parseInt(Ctrl.value,10)*1000);
		}
		else
			Str+=" (already)";
	}
	else
	{
		Str="Off";
		if(h)
		{
			clearInterval(h);
			h=null;
		}
		else
			Str+=" (already)";
	}
	
	if(Str
		&& (Ctrl=document.getElementById("SpanTimerOnOff")))
		Ctrl.innerHTML=Str;
}
// -->
		</script>
	</HEAD>
	<body onload="TimerOnOff()">
		<form id="TestSessionIIForm" method="post" runat="server">
			<table style="BORDER-RIGHT: aqua thin solid; BORDER-TOP: aqua thin solid; BORDER-LEFT: aqua thin solid; BORDER-BOTTOM: aqua thin solid">
				<tr style="BORDER-RIGHT: lime thin solid; BORDER-TOP: lime thin solid; BORDER-LEFT: lime thin solid; BORDER-BOTTOM: lime thin solid">
					<td style="BORDER-RIGHT: teal thin solid; BORDER-TOP: teal thin solid; BORDER-LEFT: teal thin solid; BORDER-BOTTOM: teal thin solid">Init:</td>
					<td style="BORDER-RIGHT: teal thin solid; BORDER-TOP: teal thin solid; BORDER-LEFT: teal thin solid; BORDER-BOTTOM: teal thin solid"><asp:Label ID="LabelInit" Runat="server"></asp:Label></td>
				</tr>
				<tr style="BORDER-RIGHT: lime thin solid; BORDER-TOP: lime thin solid; BORDER-LEFT: lime thin solid; BORDER-BOTTOM: lime thin solid">
					<td style="BORDER-RIGHT: teal thin solid; BORDER-TOP: teal thin solid; BORDER-LEFT: teal thin solid; BORDER-BOTTOM: teal thin solid">Load:</td>
					<td style="BORDER-RIGHT: teal thin solid; BORDER-TOP: teal thin solid; BORDER-LEFT: teal thin solid; BORDER-BOTTOM: teal thin solid"><asp:Label ID="LabelLoad" Runat="server"></asp:Label></td>
				</tr>
			</table>
			<br>
			Timer&nbsp;interval:&nbsp;<asp:TextBox ID="TextBoxTimerInterval" Text="50" Runat="server" />&nbsp;(sec)<br>
			<asp:CheckBox ID="CheckBoxTimerOn" Text="Timer On" TextAlign="Left" onclick="TimerOnOff()" Runat="server" />&nbsp;Timer&nbsp;is&nbsp;<span id="SpanTimerOnOff" style="font-weight: bold; color: red; "></span> 
			<br>
			<asp:Button ID="btnSubmit" Text="Submit" Runat="server" />
			<br>
		</form>
	</body>
</HTML>
