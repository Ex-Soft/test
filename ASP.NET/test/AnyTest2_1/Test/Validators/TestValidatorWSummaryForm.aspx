<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestValidatorWSummaryForm.aspx.cs" Inherits="AnyTest2_1.TestValidatorWSummaryForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>Test Validator with Summary Form</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestValidatorWSummaryForm" runat="server">
		<table style="WIDTH: 100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td><asp:Label ID="LabelInfo" Runat="server" /></td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="TextBox1" Runat="server" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox1" ControlToValidate="TextBox1" Display="None" EnableClientScript="True" Enabled="True" ErrorMessage="TextBox1" Runat="server">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="TextBox2" Runat="server" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox2" ControlToValidate="TextBox2" Display="Dynamic" EnableClientScript="True" Enabled="True" ErrorMessage="TextBox2" InitialValue="1" Runat="server">*</asp:RequiredFieldValidator>
					<asp:Label ID="LabelTextBox2" Runat="server" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="TextBox3" Runat="server" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox3" ControlToValidate="TextBox3" Display="Static" EnableClientScript="True" Enabled="True" ErrorMessage="TextBox3" Runat="server">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="TextBox4" Runat="server" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox4" ControlToValidate="TextBox4" Display="Dynamic" EnableClientScript="False" Enabled="True" ErrorMessage="TextBox4" Runat="server">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:TextBox ID="TextBox5" Runat="server" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox5" ControlToValidate="TextBox5" Display="Dynamic" EnableClientScript="True" Enabled="False" ErrorMessage="TextBox5" Runat="server">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td><asp:CheckBox ID="CheckBox1" Text="CheckBox1" TextAlign="Left" AutoPostBack="True" CausesValidation="false" Runat="server" /></td>
			</tr>
			<tr>
				<td><asp:CheckBox ID="CheckBox2" Text="CheckBox2" TextAlign="Left" AutoPostBack="True" CausesValidation="true" Runat="server" /></td>
			</tr>
			<tr>
				<td><asp:CheckBox ID="CheckBoxIsValidateTextBox3" Text="Validate TextBox3" TextAlign="Left" Checked="true" onclick="document.getElementById('RequiredFieldValidatorTextBox3').enabled=this.checked" Runat="server" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="ASPButtonSubmit" Text="Submit" Runat="server" /></td>
			</tr>
			<tr>
				<td><input type="button" id="HTMLButtonSubmit" value="form.submit()" onclick="document.getElementById('TestValidatorWSummaryForm').submit()" /></td>
			</tr>
		</table>
		<asp:ValidationSummary ID="ValidationSummary1" DisplayMode="List" EnableClientScript="True" Enabled="True" HeaderText="HeaderText of ValidationSummary" ShowMessageBox="True" ShowSummary="False" Runat="server" />
    </form>
</body>
</html>
