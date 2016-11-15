<%@ Page language="c#" Codebehind="TestSendDataByAJAXMainForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSendDataByAJAXMainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Send Data By AJAX (Main Form)</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" charset="windows-1251" src="../../../ajax.js"></script>
		<script type="text/javascript">
<!--
function Save()
{
	var
		req;

	if(!(req=initXMLHTTPRequest()))
		return;

	var
		FileName=document.location.href,
		pos=FileName.lastIndexOf("/");

	if(pos!=-1)
		FileName=FileName.substr(0,pos+1)+"TestSendDataByAJAXSaveForm.aspx";
	
	req.open("POST",FileName,false);
	req.setRequestHeader("Content-Type","application/x-www-form-urlencoded"); // ; charset=windows-1251
	pos=document.getElementById("HtmlInputText1").value;
	document.getElementById("HtmlInputText1escape").value=escape(pos);
	document.getElementById("HtmlInputText1encodeURI").value=encodeURI(pos);
	document.getElementById("HtmlInputText1encodeURIComponent").value=encodeURIComponent(pos);
	req.send("HtmlInputText1="+pos+"&HtmlInputText1escape="+escape(pos)+"&HtmlInputText1encodeURI="+encodeURI(pos)+"&HtmlInputText1encodeURIComponent="+encodeURIComponent(pos));
	if(req.readyState==4)
	{
		alert(req.status);
	}
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestSendDataByAJAXMainForm" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="1">
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td>&lt;input&gt; type=&quot;text&quot;</td>
								<td><input type="text" id="HtmlInputText1" name="HtmlInputText1"></td>
							</tr>
							<tr>
								<td>&lt;input&gt; type=&quot;text&quot; (escape)</td>
								<td><input type="text" id="HtmlInputText1escape" name="HtmlInputText1escape"></td>
							</tr>
							<tr>
								<td>&lt;input&gt; type=&quot;text&quot; (encodeURI)</td>
								<td><input type="text" id="HtmlInputText1encodeURI" name="HtmlInputText1encodeURI"></td>
							</tr>
							<tr>
								<td>&lt;input&gt; type=&quot;text&quot; (encodeURIComponent)</td>
								<td><input type="text" id="HtmlInputText1encodeURIComponent" name="HtmlInputText1encodeURIComponent"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:DropDownList ID="DropDownList1" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:CheckBox ID="CheckBox1" Checked="True" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><input type="radio" id="HtmlInputRadio1" name="HtmlInputRadio" value="1">1st</td>
								<td><input type="radio" id="HtmlInputRadio2" name="HtmlInputRadio" value="2">2nd</td>
								<td><input type="radio" id="HtmlInputRadio3" name="HtmlInputRadio" value="3">3rd</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><input type="button" id="HtmlInputButtonSave" name="HtmlInputButtonSave" value="Save" onclick="Save();"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:Button ID="ButtomSubmit" Text="Submit" Runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
