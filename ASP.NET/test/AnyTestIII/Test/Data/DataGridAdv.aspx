<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
  <head>
  <title>My Comics (DataGrid advanced)</title>
  </head>
  <body>
    <h1>My Comics (DataGrid advanced)</h1>
    <hr>
    <form runat="server">
      <center>
        <asp:DataGrid ID="MyDataGrid"
          AutoGenerateColumns="false" CellPadding="2"
          BorderWidth="1" BorderColor="lightgray" 
          Font-Name="Verdana" Font-Size="8pt"
          GridLines="vertical" Width="90%"
          OnItemCommand="OnItemCommand" RunAt="server"
          AllowSorting="true" OnSortCommand="OnSort">
          <Columns>
            <asp:BoundColumn HeaderText="Number"
              DataField="Number"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Title"
              DataField="Title" SortExpression="title ASC"
              HeaderStyle-HorizontalAlign="center" />
            <asp:BoundColumn HeaderText="Rating"
              DataField="Rating" DataFormatString="{0}"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="right"
              SortExpression="rating DESC" />
            <asp:ButtonColumn HeaderText="Action" Text="Add to Cart"
              HeaderStyle-HorizontalAlign="center"
              ItemStyle-HorizontalAlign="center"
              CommandName="AddToCart" />
            <asp:TemplateColumn>
              <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Delete" CausesValidation="false">
                  <img src="../controls/images/wall.gif" alt="Видалити" style="cursor:hand;" border="0">
                </asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
          <HeaderStyle BackColor="teal" ForeColor="white"
            Font-Bold="true" />
          <ItemStyle BackColor="white" ForeColor="darkblue" />
          <AlternatingItemStyle BackColor="beige"
            ForeColor="darkblue" />
        </asp:DataGrid>
        <br>
        <asp:Label ID="Output" RunAt="server" />
      </center>
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void Page_Load(Object sender, EventArgs e)
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

          DataView
            view=new DataView(ds.Tables[0]);

          view.Sort="Title ASC";
          MyDataGrid.DataSource=view;
          MyDataGrid.DataBind();
      }
  }

  void OnItemCommand(Object sender, DataGridCommandEventArgs e)
  {
     if(e.CommandName=="AddToCart")
       Output.Text=e.Item.Cells[1].Text;
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
</script>