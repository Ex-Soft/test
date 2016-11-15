<%@ Page language="c#" Codebehind="SelfRedirectForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.SelfRedirectForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Self-Redirect Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body>
		<form id="SelfRedirectForm" method="post" runat="server">
			Id:&nbsp;<asp:TextBox ID="TextBoxId" Runat="server" />
			<hr>
			<asp:DropDownList ID="DropDownListParam" Runat="server" />
			<asp:CheckBox ID="CheckBoxendResponse" Checked="True" Text="endResponse" TextAlign="Right" Runat="server" />
			<hr>
			<asp:Panel ID="PanelParam" Visible="False" Runat="server">
				SelfRedirectForm.aspx?ID=<asp:Label id="LabelParam" Runat="server" />
			</asp:Panel>
			<hr>
			Id:&nbsp;<asp:Label ID="LabelId" Runat="server" />&nbsp;
			Name:&nbsp;<asp:Label ID="LabelName" Runat="server" />
			<hr>
			<asp:Label ID="LabelEndResponse" Runat="server" />
			<hr>
			<input type="submit" id="btnSubmit" value="Submit">
		</form>
	</body>
</HTML>
