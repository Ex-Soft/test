<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
  <head>
  <title>My Comics (DataGrid simple)</title>
  </head>
  <body>
    <h1>My Comics (DataGrid simple)</h1>
    <hr>
    <form runat="server">
      <asp:DataGrid ID="MyDataGrid" RunAt="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void Page_Load (Object sender, EventArgs e)
  {
     if(!IsPostBack)
       {
          string
            connstring=(string)Application["connectionString"];

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
</script>