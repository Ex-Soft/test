<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
  <head>
  <title>My Comics (DataGrid with sort)</title>
  </head>
  <body>
    <h1>My Comics (DataGrid with sort)</h1>
    <hr>
    <form runat="server">
      <center>
        <asp:DataGrid ID="MyDataGrid" AutoGenerateColumns="false"
          BorderWidth="1" BorderColor="lightgray" CellPadding="2"
          Font-Name="Verdana" Font-Size="8pt" GridLines="vertical"
          OnItemCommand="OnItemCommand" OnSortCommand="OnSort"
          Width="90%" AllowSorting="true" RunAt="server">
          <Columns>
            <asp:ButtonColumn ButtonType="PushButton"
              HeaderText="Cover" Text="View"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center"
              CommandName="ViewComic" />
            <asp:BoundColumn HeaderText="Title" DataField="Title"
              SortExpression="Title ASC"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Number" DataField="Number"
              SortExpression="Number ASC"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Year" DataField="Year"
              SortExpression="Year ASC"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating" DataField="Rating"
              DataFormatString="{0:f1}" SortExpression="Rating ASC"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:TemplateColumn HeaderText="CGC"
              HeaderStyle-HorizontalAlign="center">
              <ItemTemplate>
                <center>
                  <%# ((bool)DataBinder.Eval(Container.DataItem,"CGC"))==false ? "N" : "Y" %>
                </center>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="Large Cover"
              DataField="LargeCover"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Small Cover"
              DataField="SmallCover"
              HeaderStyle-HorizontalAlign="center" />
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

<script language="C#" runat="server">
  void Page_Load (Object sender, EventArgs e)
  {
     if(!IsPostBack)
       {
          string
            connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

          OleDbConnection
            connection=new OleDbConnection(connstring);

          OleDbDataAdapter
            da=new OleDbDataAdapter("select * from books order by title, number",connection);

          DataSet
            ds=new DataSet();

          da.Fill(ds);
          MyDataGrid.DataSource=ds;
          MyDataGrid.DataBind ();
       }
  }

  void OnSort(Object sender, DataGridSortCommandEventArgs e) 
  {
     string
       connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

     OleDbConnection
       connection=new OleDbConnection(connstring);

     OleDbDataAdapter
       da=new OleDbDataAdapter("select * from books order by title, number",connection);

     DataSet
       ds=new DataSet();

     da.Fill(ds);
     
     DataView
       view=new DataView(ds.Tables[0]);

     view.Sort=e.SortExpression.ToString();
     MyDataGrid.DataSource=view;
     MyDataGrid.DataBind();
  }

  void OnItemCommand (Object sender, DataGridCommandEventArgs e)
  {
     if(e.CommandName=="ViewComic")
       Response.Redirect("images/large/"+e.Item.Cells[6].Text);
  }
</script>