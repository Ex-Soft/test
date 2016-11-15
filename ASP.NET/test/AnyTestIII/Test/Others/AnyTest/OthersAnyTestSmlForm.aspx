<%@ Page language="c#" Codebehind="OthersAnyTestSmlForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.OthersAnyTestSmlForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Others Any Test Small Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<script type="text/javascript">
<!--
function SwitchInputMode(sw)
{
	var
		Ctrl;

	switch(sw.value)
	{
		case "text" :
		{
			if(Ctrl=document.getElementById("DivInputText"))
				Ctrl.style.display="block";
			if(Ctrl=document.getElementById("DivInputDate"))
				Ctrl.style.display="none";
			if(Ctrl=document.getElementById("TextBoxInputDate"))
				Ctrl.value="";
			if(Ctrl=document.getElementById("TextBoxInputText"))
				Ctrl.focus();
		
			break;
		}
		case "date" :
		{
			if(Ctrl=document.getElementById("DivInputText"))
				Ctrl.style.display="none";
			if(Ctrl=document.getElementById("DivInputDate"))
				Ctrl.style.display="block";
			if(Ctrl=document.getElementById("TextBoxInputText"))
				Ctrl.value="";
			if(Ctrl=document.getElementById("TextBoxInputDate"))
				Ctrl.focus();
		
			break;
		}
	}
}

function IsSubmit()
{
	var
		Result=false,
		Ctrl;

	if(Ctrl=document.getElementById("HtmlInputCheckBoxIsSubmit"))
		Result=Ctrl.checked;
		
	return(Result);
}

function Birth(obj,ChildBody)
{
	var
		Ctrl;

	if(Ctrl=document.getElementById(obj))
		Ctrl.innerHTML=ChildBody;
}

function AddControlByInnerHTML(obj)
{
	obj.innerHTML="<input type=\"text\" id=\"HtmlInputTextWithIdAndName\" name=\"HtmlInputTextWithIdAndName\" value=\"Ётот control от'submit'ицо, патамушта у нево ЁстЏ name\"><input type=\"text\" id=\"HtmlInputTextWithIdOnly\" value=\"Ётот control не от'submit'ицо, патамушта у нево наблюдаецо наличие отсутстви€ name\">";
}
// -->
		</script>
	</HEAD>
	<body onload="OnLoad()">
		<form id="OthersAnyTestSmlForm" onsubmit="alert('onsubmit');return(true);" method="post" runat="server">
			<div id="DIVTest" runat="server" />
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="1">
				<tr>
					<td>
						<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td>GetProcessesByName()</td>
								<td><asp:Button ID="btnGetProcessesByName" Text="GetProcessesByName" Runat="server" /></td>
								<td><asp:Label ID="LabelGetProcessesByName" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td><asp:Button ID="btnSetSessionSmthValue" Text="Set Session[&#34;SmthValue&quot;]" style="width: 100%; " Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td><asp:Label ID="LabelServerMapPath" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td align="center" colspan="2">appSettingsTestVariable</td>
							</tr>
							<tr>
								<td><asp:Button ID="ButtonAppSettingsTestVariableGet" Text="Get" Runat="server" /></td>
								<td><asp:TextBox ID="TextBoxAppSettingsTestVariableGet" Runat="server" /></td>
							</tr>
							<tr>
								<td><asp:Button ID="ButtonAppSettingsTestVariableSet" Text="Set" Runat="server" /></td>
								<td><asp:TextBox ID="TextBoxAppSettingsTestVariableSet" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:TextBox ID="TextBoxWCS" onkeyup="alert('onkeyup')" Runat="server" /></td>
								<td><asp:Button ID="ButtonDisabled" Text="Disabled" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:TextBox ID="TextBoxByClientID" Runat="server" /></td>
								<td><input type="button" id="ButtonTextBoxByClientID" value="Show" onclick='alert(document.getElementById("<%=TextBoxByClientID.ClientID%>").id)'></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td width="20%">
									<input type="radio" id="RadioButtonInputModeText" name="RadioButtonListInputModeSwitch" checked value="text" onclick="SwitchInputMode(this)">Text
									<input type="radio" id="RadioButtonInputModeDate" name="RadioButtonListInputModeSwitch" value="date" onclick="SwitchInputMode(this)">Date
								</td>
								<td width="60%">
									<div id="DivInputText" style="width: 100%; ">
										Text&nbsp;<asp:TextBox ID="TextBoxInputText" style="width: 100%; " onblur="this.value='onblur'" Runat="server" />
									</div>
									<div id="DivInputDate" style="display: none; width: 100%; ">
										Date&nbsp;<asp:TextBox ID="TextBoxInputDate" style="width: 100%; " onblur="this.value='onblur'" Runat="server" />
									</div>
								</td>
								<td width="20%"><asp:Button ID="ButtonInputTextDateSubmit" Text="Submit" style="width: 100%; " Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><input type="checkbox" id="HtmlInputCheckBoxIsSubmit">&nbsp;Submit</td>
								<td><input type="button" id="HtmlInputButtonWithCheckSubmit" value="Submit" onclick="if(!IsSubmit()) return;" runat="server"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td>App</td>
								<td><asp:TextBox ID="TextBoxApp" Runat="server" /></td>
								<td>Parameters</td>
								<td><asp:TextBox ID="TextBoxParameters" Runat="server" /></td>
								<td><asp:Button ID="ButtonRunProcess" Text="Run" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><input type="button" id="ButtonParent" value="Birth" Runat="server" /></td>
								<td><div id="DivParent"></div></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><div id="Div4ControlWillBeAddedByInnerHTML"></div></td>
								<td><input type="button" value="Add Control By innerHTML" onclick="AddControlByInnerHTML(document.getElementById('Div4ControlWillBeAddedByInnerHTML'))"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
