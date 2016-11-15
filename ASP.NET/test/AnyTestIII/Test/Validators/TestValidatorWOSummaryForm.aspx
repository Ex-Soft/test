<%@ Page language="c#" Codebehind="TestValidatorWOSummaryForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestValidatorWOSummaryForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Validator without Summary Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="TestValidatorWOSummaryForm" method="post" runat="server">
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
					<td><asp:CheckBox ID="CheckBox1" Text="CheckBox1" TextAlign="Left" AutoPostBack="True" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:CheckBox ID="CheckBox2" Text="CheckBox2" TextAlign="Left" AutoPostBack="True" Runat="server" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="ASPButtonSubmit" Text="Submit" Runat="server" /></td>
				</tr>
				<tr>
					<td><input type="button" id="HTMLButtonSubmit" value="form.submit()" onclick="document.getElementById('TestValidatorWOSummaryForm').submit()"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
