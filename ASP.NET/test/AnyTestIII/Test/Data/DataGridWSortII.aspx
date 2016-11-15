<%@ Page language="c#" Codebehind="DataGridWSortII.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DataGridWSortII" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataGrid with sort II</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="DataGridWSortIIForm" method="post" runat="server">
			<asp:DataGrid ID="DataGrid1" AutoGenerateColumns="False" DataKeyField="ID" AllowPaging="True" PageSize="2" AllowSorting="True" BorderWidth="1px" BorderColor="LightGray" CellPadding="2" Font-Names="Verdana" Font-Name="Verdana" Font-Size="8pt" GridLines="Vertical" Width="90%" Runat="server">
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal" />
				<ItemStyle ForeColor="DarkBlue" BackColor="White" />
				<AlternatingItemStyle ForeColor="DarkBlue" BackColor="Beige" />
				<PagerStyle HorizontalAlign="Left" Position="Bottom" Mode="NumericPages" />
				<Columns>
					<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="N �/�" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:BoundColumn DataField="Dep" SortExpression="Dep" HeaderText="�����" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="�. �. �." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
					<asp:BoundColumn DataField="Salary" SortExpression="Salary" HeaderText="��������" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
					<asp:TemplateColumn HeaderText="��" SortExpression="BirthDate" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("BirthDate") ? Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["BirthDate"]).ToString("dd.MM.yyyy") : "" %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="BirthDate" DataFormatString="{0:dd.MM.yyyy}" HeaderText="��" SortExpression="BirthDate" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
