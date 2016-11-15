<%@ Page language="c#" Codebehind="TestRadioDivForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestRadioDivForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<title>Test Radio plus Div Form</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<script type="text/javascript">
<!--
function OnOff(obj)
{
	var
		DivOn,
		DivOff,
		Ctrl;
		
	switch(obj.id)
	{
		case "HtmlInputRadioVisibleUp" :
		{
			DivOn="DivUp";
			DivOff="DivDown";
			
			break;
		}
		case "HtmlInputRadioVisibleDown" :
		{
			DivOn="DivDown";
			DivOff="DivUp";
			
			break;
		}
	}
	
	if(Ctrl=document.getElementById(DivOn))
		Ctrl.style.display="block";
	if(Ctrl=document.getElementById(DivOff))
		Ctrl.style.display="none";
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestRadioDivForm" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td>
						<fieldset><legend>&nbsp;<input type="radio" id="HtmlInputRadioVisibleUp" name="HtmlInputRadioVisible" value="up" checked="true" onclick="OnOff(this);" runat="server" />&nbsp;Up&nbsp;</legend> <!-- checked="checked" http://www.w3schools.com/Xhtml/xhtml_syntax.asp -->
							<div id="DivUp" runat="server">
								<h1>Up</h1>
							</div>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td>
						<fieldset><legend>&nbsp;<input type="radio" id="HtmlInputRadioVisibleDown" name="HtmlInputRadioVisible" value="down" onclick="OnOff(this);" runat="server" />&nbsp;Down&nbsp;</legend>
							<div id="DivDown" runat="server">
								<h1>Down</h1>
							</div>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td>
						<fieldset><legend>&nbsp;<asp:CheckBox ID="CheckBoxOnOff" onclick="document.getElementById('DivCheckBox').style.display=this.checked?'block':'none'" Runat="server" />&nbsp;On/Off&nbsp;</legend>
							<div id="DivCheckBox" runat="server">
								<h1>CheckBox</h1>
							</div>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td>
						<input type="submit" id="ButtonSubmit" value="submit" runat="server" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
