<%@ Page language="c#" Codebehind="TestHtcWValidatorForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestHtcWValidatorForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Htc With Validator</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<link rel='stylesheet' href="grids.css">
		<script type="text/javascript" src="misc.js"></script>
		<script type="text/javascript" src="date.js"></script>
		<script type="text/javascript" src="CustomValidF.js"></script>
	</HEAD>
	<body>
		<form id="TestHtcWValidatorForm" method="post" runat="server">
			<table style="WIDTH: 100%" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td valign="baseline">Date# 1</td>
					<td valign="baseline"><asp:TextBox ID="TextBoxDate1" CssClass="textfield" preset="shortdate" Runat="server" /></td>
				</tr>
				<tr>
					<td valign="baseline">Date# 2</td>
					<td valign="baseline"><asp:TextBox ID="TextBoxDate2" CssClass="textfield" preset="shortdate" Runat="server" /></td>
				</tr>
				<tr>
					<td valign="baseline">Date# 3</td>
					<td valign="baseline"><asp:TextBox ID="TextBoxDate3" CssClass="textfield" preset="shortdate" Runat="server" /></td>
				</tr>
				<tr>
					<td valign="baseline">Date# 4</td>
					<td valign="baseline">
						<asp:TextBox ID="TextBoxDate4" CssClass="textfield" preset="shortdate" Runat="server" />
						<asp:CustomValidator ID="CustomValidatorDate4" ControlToValidate="TextBoxDate4" Display="None" ErrorMessage="Invalid date!!!" ClientValidationFunction="CheckTextBoxWithDate" EnableClientScript="true" Runat="server" />
						<asp:ValidationSummary ID="ValidationSummaryObj" DisplayMode="List" EnableClientScript="True" ShowMessageBox="True" ShowSummary="False" Runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center" valign="baseline"><asp:Button ID="ButtonSave" Text="Save" Width="100%" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
