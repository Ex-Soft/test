<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="DataTableEvents.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test DataTable Events</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta content="False" name="vs_snapToGrid">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<asp:Literal id="LiteralBeginJS" Runat="server" />
		<asp:Literal id="LiteralJS" Runat="server" />
		<asp:Literal id="LiteralEndJS" Runat="server" />
		<form id="MainForm" method="post" runat="server">
			<fieldset><legend>DataGrid with pages</legend>
				<asp:DataGrid ID="DataGridWithPages" AutoGenerateColumns="false" CellPadding="2" BorderWidth="1"
					BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" GridLines="vertical" Width="90%"
					AllowPaging="true" PageSize="2" PagerStyle-PrevPageText="Previous Page" PagerStyle-NextPageText="Next Page"
					PagerStyle-Mode="NumericPages" Runat="server">
					<Columns>
						<asp:BoundColumn HeaderText="Id" DataField="Id" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
						<asp:BoundColumn HeaderText="Name" DataField="Name" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
						<asp:TemplateColumn HeaderText="Choice" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
							<ItemTemplate>
								<input type="radio" id="<%=RadioButtonChoiceIdSignature%><%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Id")) %>" value="<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Id")) %>" name="<%=RadioButtonChoiceNameSignature%>">
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Choice# 2" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
							<ItemTemplate>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</fieldset>
			<fieldset><legend>MainDataSet</legend>
				<fieldset><legend>MasterTable</legend>
					<fieldset><legend>Input</legend>Value:&nbsp;<asp:textbox id="TextBoxMasterTableValue" runat="server"></asp:textbox>&nbsp;
						<asp:button id="btnMasterTableValueSave" runat="server" text="Save"></asp:button></fieldset>
					<fieldset><legend>Data</legend>
						<asp:DataGrid id="DataGridMasterTable" runat="server" AutoGenerateColumns="false" BorderWidth="1"
							CellPadding="2" BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" GridLines="vertical"
							Width="90%">
							<Columns>
								<asp:BoundColumn HeaderText="Id" DataField="Id" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
								<asp:BoundColumn HeaderText="Value" DataField="Value" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
								<asp:TemplateColumn HeaderText="NewId" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
									<ItemTemplate>
										<asp:TextBox runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn ButtonType="PushButton" HeaderText="Change" Text="Change" CommandName="ChangeId"
									HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center"></asp:ButtonColumn>
							</Columns>
							<HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
							<ItemStyle BackColor="white" ForeColor="darkblue" />
							<AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
						</asp:DataGrid>
						<hr>
						<asp:button id="btnMasterTableRefresh" runat="server" text="Refresh" />
						<hr>
						Id:&nbsp;<asp:textbox id="TextBoxMasterTableOldId" runat="server" />&nbsp;-&gt;
						<asp:textbox id="TextBoxMasterTableNewId" runat="server" />&nbsp;
						<asp:button id="btnMasterTableIdChanged" runat="server" text="Change"></asp:button>&nbsp; 
						CustomMasterTable.Rows.Count:&nbsp;<asp:label id="LabelRowCount" runat="server" />
					</fieldset>
				</fieldset>
				<fieldset><legend>DetailsTable</legend>
					<fieldset><legend>Input</legend>
						Id:&nbsp;<asp:textbox id="TextBoxDetailTableId" runat="server" /><br>
						SubId:&nbsp;<asp:textbox id="TextBoxDetailTableSubId" runat="server" /><br>
						Value:&nbsp;<asp:textbox id="TextBoxDetailTableValue" runat="server" />&nbsp;
						<asp:button id="btnDetailTableValueSave" runat="server" text="Save" />
					</fieldset>
					<fieldset><legend>Data</legend>
						<asp:DataGrid id="DataGridDetailTable" runat="server" /></fieldset>
					<hr>
					<asp:button id="btnDetailTableRefresh" runat="server" text="Refresh" />
					<hr>
				</fieldset>
			</fieldset>
			<fieldset><legend>CustomDataSet</legend>
				<fieldset><legend>CustomMasterTable</legend>
					<fieldset><legend>Input</legend>
						MasterId:&nbsp;<asp:textbox id="TextBoxCustomMasterTableMasterId" runat="server"></asp:textbox>&nbsp;
						<asp:button id="btnCustomMasterTableMasterIdSave" runat="server" text="Save"></asp:button>
					</fieldset>
					<fieldset><legend>Data</legend>
						<asp:DataGrid id="DataGridCustomMasterTable" runat="server" />
						<hr>
						<asp:button id="btnCustomMasterTableRefresh" runat="server" text="Refresh" />
						<hr>
					</fieldset>
				</fieldset>
			</fieldset>
		</form>
	</body>
</HTML>
