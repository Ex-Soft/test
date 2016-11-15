<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="TestApplicationError.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main Form</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
	</HEAD>
	<body>
		<form id="MainForm" method="post" runat="server">
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td align="center" colspan="2">
						<asp:RadioButtonList ID="RadioTypeOperation" RepeatDirection="Horizontal" Runat="server">
							<asp:ListItem Value="insert" Text="insert into" Selected="True" />
							<asp:ListItem Value="update" Text="update where" />
						</asp:RadioButtonList>
					</td>
				</tr>
				<tr>
					<td>IdMaster</td>
					<td><asp:TextBox ID="TextBoxIdMaster" Runat="server" /></td>
				</tr>
				<tr>
					<td>Id</td>
					<td><asp:TextBox ID="TextBoxId" Runat="server" /></td>
				</tr>
				<tr>
					<td>Value</td>
					<td><asp:TextBox ID="TextBoxValue" Runat="server" /></td>
				</tr>
				<tr>
					<td colspan="2"><asp:Button ID="ButtonSave" Text="Save" Width="100%" Runat="server" /></td>
				</tr>
				<tr>
					<td align="center" colspan="2"><asp:Label ID="LabelInfo" Runat="server" /></td>
				</tr>
				<tr>
					<td align="center" colspan="2">
						<asp:DataGrid ID="DataGridDetailsTable" CellPadding="2" BorderWidth="1" BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" GridLines="vertical" Runat="server">
							<HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
							<ItemStyle BackColor="white" ForeColor="darkblue" />
							<AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
