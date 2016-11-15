<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
<head>
<title>My Comics (DataList)</title>
</head>
  <body>
    <h1>My Comics (DataList)</h1>
    <hr>
    <form runat="server">
      <asp:Table Width="100%" Height="32" CellPadding="4"
        BackColor="yellow" RunAt="server">
        <asp:TableRow>
          <asp:TableCell ID="Output" />
        </asp:TableRow>
      </asp:Table>
      <br>
      <asp:DataList ID="MyDataList" RepeatColumns="3"
        RepeatDirection="Horizontal" CellPadding="4"
        OnItemCommand="OnItemCommand" RunAt="server">
        <ItemTemplate>
          <table width="100%" cellpadding="4">
            <tr>
              <td width="100">
                <a href='images/large/<%# DataBinder.Eval
                  (Container.DataItem, "LargeCover") %>'>
                  <img src='images/small/<%# DataBinder.Eval
                    (Container.DataItem, "SmallCover") %>'>
                </a>
              </td>
              <td valign="top">
                <asp:LinkButton CommandName="Select" RunAt="server"
                  CommandArgument='<%# DataBinder.Eval
                  (Container.DataItem, "Comment") %>'
                  Text='<%# DataBinder.Eval (Container.DataItem,
                  "Title") + " " +
                  DataBinder.Eval (Container.DataItem,
                  "Number") %>' /><br>
                <%# DataBinder.Eval (Container.DataItem, "Year") %><br>
                <%# DataBinder.Eval (Container.DataItem, "Rating",
                  "{0:f1}") %><br>
              </td>
            </tr>
          </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="gainsboro" />
      </asp:DataList>
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
        
           try
             {
                connection.Open ();
                
                OleDbCommand
                  command=new OleDbCommand
                  ("select * from books order by title, number",connection);
                  
                OleDbDataReader
                  reader=command.ExecuteReader();
                  
                MyDataList.DataSource=reader;
                MyDataList.DataBind();
             }
           finally
             {
                connection.Close();
             }
        }
  }

  void OnItemCommand(Object sender, DataListCommandEventArgs e) 
  {
     if(e.CommandName=="Select")
       {
          MyDataList.SelectedIndex=e.Item.ItemIndex;
          Output.Text=e.CommandArgument.ToString();
       }
  }
</script>