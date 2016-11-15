<%@ Page language="c#" Codebehind="DynamicGridFormII.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DynamicGridFormII" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DynamicGridFormII</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
	</HEAD>
	<body>
		<form id="DynamicGridFormII" method="post" runat="server">
			<asp:DataGrid ID="DynamicDataGrid1" AutoGenerateColumns="False" AllowPaging="true" PageSize="2" Runat="server">
				<PagerStyle HorizontalAlign="Left" Mode="NumericPages" Position="TopAndBottom" />
				<Columns>
					<asp:BoundColumn DataField="ID" HeaderText="ID" />
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
