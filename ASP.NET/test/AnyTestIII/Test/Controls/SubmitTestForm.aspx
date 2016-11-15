<%@ Page language="c#" Codebehind="SubmitTestForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.SubmitTestForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Submit Test Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function IsSubmitEnable()
{
	var
		Ctrl;

	if(!(Ctrl=document.getElementById("<%=CheckBoxSubmitEnabled.ID%>")))
		return(false);

	return(Ctrl.checked);
}

function AddControl()
{
	var
		Container=document.getElementById("SpanForInputDynamic"),
		Ctrl=document.createElement("INPUT");

	Ctrl.setAttribute("type","text");
	Ctrl.setAttribute("id","<%=InputDynamicId%>");
	Ctrl.setAttribute("name","<%=InputDynamicId%>");
	Ctrl.setAttribute("value","InputDynamicValue");
	SpanForInputDynamic.appendChild(Ctrl);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="SubmitTestForm" onsubmit="return(IsSubmitEnable())" method="post" runat="server">
			<table style="border: aqua thin solid; ">
				<tr style="border: lime thin solid; ">
					<td style="border: teal thin solid; ">Init:</td>
					<td style="border: teal thin solid; "><asp:Label ID="LabelInit" Runat="server" /></td>
				</tr>
				<tr style="border: lime thin solid; ">
					<td style="border: teal thin solid; ">Load:</td>
					<td style="border: teal thin solid; "><asp:Label ID="LabelLoad" Runat="server" /></td>
				</tr>
			</table>
			<br>
			<asp:CheckBox ID="CheckBoxSubmitEnabled" Text="Submit&nbsp;enabled" Runat="server" />
			<br>
			<asp:TextBox ID="TextBoxSrc1" Runat="server" />
			<asp:Button ID="ButtonCopy" Text="Copy" Runat="server" />
			<asp:TextBox ID="TextBoxDest1" Runat="server" />
			<br>
			<input type="text" id="TextBoxSrc2" runat="server">&nbsp;
			<input type="submit" id="HTMLButtonSubmit" name="HTMLButtonSubmit" value="Copy">&nbsp;
			<input type="text" id="TextBoxDest2" runat="server"><br>
			<hr>
			<input type="image" id="btnTestImage" name="btnTestImage" src="./images/wall.gif" border="0" alt="Test" onclick="alert(this.id)">&nbsp;
			<a href="#" id="hrefTest" name=id="hrefTest" onclick="alert(this.id)"><img id="imgTest" name="imgTest" src="./images/wall.gif" alt="alt" border="0" title="title"></a>
			<input type="button" id="btnTestButton" name="btnTestButton" value="Test" onclick="alert(this.id)">
			<hr>
			<input type="button" id="btnAddControl" name="btnAddControl" value="AddControl" onclick="AddControl()">&nbsp;<span ID="SpanForInputDynamic" Runat="server"></span>
			<hr>
			<asp:DropDownList ID="DropDownList1" Runat="server" />
			<hr>
			<input type="button" id="HtmlInputButton" value="HtmlInputButton">
			<button type="button" id="HtmlButton" value="HtmlButton">HtmlButton</button>
			<a href="#" onclick="document.getElementById('SubmitTestForm').submit()">Submit</a>
		</form>
	</body>
</HTML>
