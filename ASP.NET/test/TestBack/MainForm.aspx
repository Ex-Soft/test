<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="TestBack.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<script type="text/javascript">
<!--
function Add(obj)
{
	var
		CtrlText,
		CtrlValue,
		CtrlListBox,
		_Option_;

	switch(obj.id)
	{
		case "HtmlInputButton1" :
		{
			CtrlText=document.getElementById("HtmlInputTextText1");
			CtrlValue=document.getElementById("HtmlInputTextValue1");
			CtrlListBox=document.getElementById("ListBox1");
			break;
		}
		case "HtmlInputButton2" :
		{
			CtrlText=document.getElementById("HtmlInputTextText2");
			CtrlValue=document.getElementById("HtmlInputTextValue2");
			CtrlListBox=document.getElementById("ListBox2");
			break;
		}
		case "HtmlInputButton3" :
		{
			CtrlText=document.getElementById("HtmlInputTextText3");
			CtrlValue=document.getElementById("HtmlInputTextValue3");
			CtrlListBox=document.getElementById("ListBox3");
			break;
		}
	}

	switch(obj.id)
	{
		case "HtmlInputButton1" :
		{
			_Option_=new Option(CtrlText.value,CtrlValue.value,false,true);
			CtrlListBox.options.add(_Option_);
			break;
		}
		case "HtmlInputButton2" :
		{
			_Option_=document.createElement("option");
			CtrlListBox.options.add(_Option_);
			_Option_.value=CtrlValue.value;
			_Option_.text=CtrlText.value;
			break;
		}
		case "HtmlInputButton3" :
		{
			_Option_=document.createElement("option");
			CtrlListBox.options.add(_Option_);
			_Option_.innerHTML=CtrlText.value;
			break;
		}
	}
}
// -->
		</script>
	</HEAD>
	<body>
		<h1>Main Form</h1>
		<form id="MainForm" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:ListBox ID="ListBox1" Runat="server" /></td>
								<td>text</td>
								<td><input type="text" id="HtmlInputTextText1"></td>
								<td>value</td>
								<td><input type="text" id="HtmlInputTextValue1"></td>
								<td><input type="button" id="HtmlInputButton1" value="Add" onclick="Add(this)"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:ListBox ID="ListBox2" Runat="server" /></td>
								<td>text</td>
								<td><input type="text" id="HtmlInputTextText2"></td>
								<td>value</td>
								<td><input type="text" id="HtmlInputTextValue2"></td>
								<td><input type="button" id="HtmlInputButton2" value="Add" onclick="Add(this)"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td><asp:ListBox ID="ListBox3" Runat="server" /></td>
								<td>text</td>
								<td><input type="text" id="HtmlInputTextText3"></td>
								<td>value</td>
								<td><input type="text" id="HtmlInputTextValue3"></td>
								<td><input type="button" id="HtmlInputButton3" value="Add" onclick="Add(this)"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:Button ID="ButtonSubmit" Text="Submit" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
