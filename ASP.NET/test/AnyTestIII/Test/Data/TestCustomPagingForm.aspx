<%@ Page language="c#" Codebehind="TestCustomPagingForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestCustomPagingForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test CustomPaging Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="TestCustomPagingForm" method="post" runat="server">
			<h1>Test CustomPaging</h1>
			<hr>
			<asp:DataGrid ID="DataGridWCuctomPaging" AutoGenerateColumns="False" DataKeyField="ID" AllowCustomPaging="True" AllowPaging="True" PageSize="2" BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" GridLines="vertical" BorderStyle="None" BorderWidth="1" CellPadding="2" Width="100%" BackColor="White" Runat="server">
				<HeaderStyle ForeColor="white" BackColor="teal" Font-Bold="true" />
				<ItemStyle ForeColor="darkblue" BackColor="white" />
				<AlternatingItemStyle ForeColor="darkblue" BackColor="beige" />
				<PagerStyle HorizontalAlign="Left" Mode="NumericPages" />
				<Columns>
					<asp:BoundColumn DataField="ID" HeaderText="N п/п" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:BoundColumn DataField="Dep" HeaderText="Отдел" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:BoundColumn DataField="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
					<asp:BoundColumn DataField="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
					<asp:TemplateColumn HeaderText="ДР" SortExpression="BirthDate" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("BirthDate") ? Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["BirthDate"]).ToString("dd.MM.yyyy") : "" %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
