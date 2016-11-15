<%@ Page language="c#" Codebehind="DynamicGridForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DynamicGridForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Dynamic DataGrid</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Refresh" content="300">
		<meta content="False" name="vs_snapToGrid">
  </HEAD>
	<body>
		<form id="DynamicDataGridForm" method="post" runat="server">
			<asp:DataGrid ID="DynamicDataGrid1" AutoGenerateColumns="False" Runat="server">
				<Columns>
					<asp:BoundColumn DataField="Dep" HeaderText="Dep" />
					<asp:BoundColumn DataField="ID" HeaderText="ID" />
					<asp:BoundColumn DataField="Name" HeaderText="Name" />
					<asp:BoundColumn DataField="BirthDate" HeaderText="BirthDate" />
					<asp:BoundColumn DataField="Salary" HeaderText="Salary" />
				</Columns>
			</asp:DataGrid>
			<br>
			<asp:PlaceHolder ID="PlaceHolderButtonOnClickPageInit" Runat="server" />
			<asp:PlaceHolder ID="PlaceHolderButtonOnClickPageLoad" Runat="server" />
		</form>
	</body>
</HTML>