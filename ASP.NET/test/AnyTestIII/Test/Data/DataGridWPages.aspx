<%@ Page language="c#" CodeBehind="DataGridWPages.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DataGridWPagesForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
  <title>My Comics (DataGrid with pages)</title>
  <meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
  <meta name="vs_snapToGrid" content="False">
  <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <h1>My Comics (DataGrid with pages)</h1>
    <hr>
    <form id="DataGridWPagesForm" method="post" runat="server">
      <center>
        OnInit (Static)<br>
        <asp:DataGrid ID="MyDataGridInit"
          AutoGenerateColumns="false" CellPadding="2"
          BorderWidth="1" BorderColor="lightgray" 
          Font-Name="Verdana" Font-Size="8pt"
          GridLines="vertical" Width="90%" RunAt="server"
          AllowPaging="true" PageSize=2
          PagerStyle-PrevPageText="Previous Page"
          PagerStyle-NextPageText="Next Page"
          PagerStyle-Mode="NumericPages">
          <Columns>
            <asp:BoundColumn HeaderText="Number"
              DataField="Number"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Title"
              DataField="Title"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating"
              DataField="Rating"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="right"
              DataFormatString="{0}" />
            <asp:BoundColumn HeaderText="Year"
              DataField="Year"
              HeaderStyle-HorizontalAlign="center" />
          </Columns>
          <HeaderStyle BackColor="teal" ForeColor="white"
            Font-Bold="true" />
          <ItemStyle BackColor="white" ForeColor="darkblue" />
          <AlternatingItemStyle BackColor="beige"
            ForeColor="darkblue" />
        </asp:DataGrid>
      </center>
      <br>
      <center>
        OnLoad (Static)
        <asp:DataGrid ID="MyDataGridLoad"
          AutoGenerateColumns="false" CellPadding="2"
          BorderWidth="1" BorderColor="lightgray" 
          Font-Name="Verdana" Font-Size="8pt"
          GridLines="vertical" Width="90%" RunAt="server"
          AllowPaging="true" PageSize=2
          PagerStyle-PrevPageText="Previous Page"
          PagerStyle-NextPageText="Next Page"
          PagerStyle-Mode="NumericPages">
          <Columns>
            <asp:BoundColumn HeaderText="Number"
              DataField="Number"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Title"
              DataField="Title"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating"
              DataField="Rating"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="right"
              DataFormatString="{0}" />
            <asp:BoundColumn HeaderText="Year"
              DataField="Year"
              HeaderStyle-HorizontalAlign="center" />
          </Columns>
          <HeaderStyle BackColor="teal" ForeColor="white"
            Font-Bold="true" />
          <ItemStyle BackColor="white" ForeColor="darkblue" />
          <AlternatingItemStyle BackColor="beige"
            ForeColor="darkblue" />
        </asp:DataGrid>
      </center>
      <br>
      <center>
        OnInit (Dynamic)<br>
        <asp:DataGrid ID="MyDataGridDynamic" DataKeyField="Id"
          AutoGenerateColumns="false" CellPadding="2"
          BorderWidth="1" BorderColor="lightgray" 
          Font-Name="Verdana" Font-Size="8pt"
          GridLines="vertical" Width="90%" RunAt="server"
          AllowPaging="true" PageSize=2
          PagerStyle-PrevPageText="Previous Page"
          PagerStyle-NextPageText="Next Page"
          PagerStyle-Mode="NumericPages">
          <PagerStyle Position="Bottom" />
          <Columns>
            <asp:BoundColumn HeaderText="Number"
              DataField="Number"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Title"
              DataField="Title"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating"
              DataField="Rating"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="right"
              DataFormatString="{0}" />
            <asp:BoundColumn HeaderText="Year"
              DataField="Year"
              HeaderStyle-HorizontalAlign="center" />
			<asp:TemplateColumn HeaderText="CheckBox" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
				<ItemTemplate>
					<asp:CheckBox ID="tmpCheckBox" Runat="server" />
				</ItemTemplate>
			</asp:TemplateColumn>
          </Columns>
          <HeaderStyle BackColor="teal" ForeColor="white"
            Font-Bold="true" />
          <ItemStyle BackColor="white" ForeColor="darkblue" />
          <AlternatingItemStyle BackColor="beige"
            ForeColor="darkblue" />
        </asp:DataGrid>
      </center>
      <br>
      <center>
        OnLoad (Dynamic)<br>
        <asp:DataGrid ID="MyDataGridDynamic2" DataKeyField="Id"
          AutoGenerateColumns="false" CellPadding="2"
          BorderWidth="1" BorderColor="lightgray" 
          Font-Name="Verdana" Font-Size="8pt"
          GridLines="vertical" Width="90%" RunAt="server"
          AllowPaging="true" PageSize=2
          PagerStyle-PrevPageText="Previous Page"
          PagerStyle-NextPageText="Next Page"
          PagerStyle-Mode="NumericPages">
          <PagerStyle Position="TopAndBottom" />
          <Columns>
            <asp:BoundColumn HeaderText="Number"
              DataField="Number"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Title"
              DataField="Title"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating"
              DataField="Rating"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="right"
              DataFormatString="{0}" />
            <asp:BoundColumn HeaderText="Year"
              DataField="Year"
              HeaderStyle-HorizontalAlign="center" />
			<asp:TemplateColumn HeaderText="CheckBox" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
				<ItemTemplate>
					<asp:CheckBox ID="tmpCheckBox" Runat="server" />
				</ItemTemplate>
			</asp:TemplateColumn>
          </Columns>
          <HeaderStyle BackColor="teal" ForeColor="white"
            Font-Bold="true" />
          <ItemStyle BackColor="white" ForeColor="darkblue" />
          <AlternatingItemStyle BackColor="beige"
            ForeColor="darkblue" />
        </asp:DataGrid>
      </center>
    </form>
  </body>
</html>