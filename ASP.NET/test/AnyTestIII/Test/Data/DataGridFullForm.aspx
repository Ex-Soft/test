<%@ Page language="c#" Codebehind="DataGridFullForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DataGridFullForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataGridFullForm</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta content="False" name="vs_snapToGrid">
		<link type="text/css" href="datagridfullform.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="DataGridFullForm" method="post" runat="server">
			<asp:DataGrid ID="DataGridFull" AutoGenerateColumns="False" DataKeyField="ID" AllowSorting="true" AllowPaging="True" PageSize="2" BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" GridLines="vertical" BorderStyle="None" BorderWidth="1" CellPadding="2" Width="100%" BackColor="White" Runat="server">
				<HeaderStyle ForeColor="white" BackColor="teal" Font-Bold="true" />
				<ItemStyle ForeColor="darkblue" BackColor="white" />
				<AlternatingItemStyle ForeColor="darkblue" BackColor="beige" />
				<PagerStyle HorizontalAlign="Left" Mode="NumericPages" />
				<Columns>
					<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="N п/п" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:BoundColumn DataField="Dep" SortExpression="Dep" HeaderText="Отдел" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
					<asp:TemplateColumn SortExpression="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left">
						<ItemTemplate>
							<span name="Name" class="Name"><%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("Name") ? Convert.ToString(((System.Data.DataRowView)Container.DataItem)["Name"]) : "" %></span>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
					<asp:TemplateColumn HeaderText="ДР" SortExpression="BirthDate" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("BirthDate") ? Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["BirthDate"]).ToString("dd.MM.yyyy") : "" %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="CheckBox" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<asp:CheckBox ID="tmpCheckBox" Runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:ButtonColumn ButtonType="LinkButton" CommandName="aaa" Text="LinkButton" />
					<asp:ButtonColumn ButtonType="PushButton" CommandName="bbb" Text="PushButton" />
		            <asp:TemplateColumn>
						<ItemTemplate>
							<asp:LinkButton id="LinkButtonDelete" CommandName="Delete" CausesValidation="false" runat="server">
								<img src="../controls/images/wall.gif" alt="Видалити" style="cursor:hand;" border="0">
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
