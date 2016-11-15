<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthersAnyTestSmlForm.aspx.cs" Inherits="AnyTest2_1.OthersAnyTestSmlForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Others Any Test Small Form</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body onload="OnLoad()">
    <form id="OthersAnyTestSmlForm" onsubmit="alert('onsubmit');return(true);" runat="server">
        <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
        	<tr>
				<td>
					<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td><asp:TextBox ID="TextBoxWCS" onkeyup="alert('onkeyup')" Runat="server" /></td>
						</tr>
						<tr>
							<td><asp:Button ID="ButtonDisabled" Text="Disabled" Runat="server" OnClick="ButtonDisabled_Click" /></td>
						</tr>
						<tr>
						    <td><input type="checkbox" id="HtmlInputCheckBox1" onclick="alert('onclick');document.getElementById('OthersAnyTestSmlForm').submit()" onserverchange="HtmlInputCheckBox_ServerChange" runat="server" /></td>
						</tr>
						<tr>
						    <td><input type="submit" id="ButtonSubmit" value="Submit" /></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
			    <td>
			        <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
			            <tr>
			                <td>Web.config -&gt; &lt;appSettings&gt; -&gt; AppSettingsSmthValue = </td>
			                <td><asp:Literal ID="Literal1" Text="<%$appSettings:AppSettingsSmthValue%>" runat="server" /></td>
			                <td><asp:Literal ID="Literal2" Text="<%$AppSettings:AppSettingsSmthValue%>" runat="server" /></td>
			            </tr>
			        </table>
			    </td>
			</tr>
        </table>
    </form>
</body>
</html>
