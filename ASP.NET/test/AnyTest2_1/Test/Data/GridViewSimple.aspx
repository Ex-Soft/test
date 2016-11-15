<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
  <head>
  <title>My Comics (GridView simple)</title>
  </head>
  <body>
    <h1>My Comics (GridView simple)</h1>
    <hr>
    <form runat="server">
      <asp:GridView ID="MyGridView" RunAt="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void Page_Load (Object sender, EventArgs e)
  {
     if(!IsPostBack)
       {
          string
            connstring = (string)Application["connectionString"];

          OleDbConnection
            connection=new OleDbConnection(connstring);

          OleDbDataAdapter
            da=new OleDbDataAdapter("select * from books order by title, number",connection);

          DataSet
            ds=new DataSet();

          da.Fill(ds);
          MyGridView.DataSource=ds;
          MyGridView.DataBind();
       }
  }
</script>