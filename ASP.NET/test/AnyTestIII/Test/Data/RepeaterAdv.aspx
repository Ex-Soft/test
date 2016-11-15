<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
<head>
<title>My Comics (Repeater)</title>
</head>
  <body>
    <h1>My Comics (Repeater)</h1>
    <hr>
    <form runat="server">
      <table width="100%">
        <tr>
          <td width="104" />
          <td>
            <table cellpadding="4" width="100%">
              <tr height="48" bgcolor="yellow">
                <td width="40%" align="center">
                  Title
                </td>
                <td width="15%" align="center">
                  Number
                </td>
                <td width="15%" align="center">
                  Year
                </td>
                <td width="15%" align="center">
                  Rating
                </td>
                <td width="15%" align="center">
                  CGC Rated?
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      <asp:Repeater ID="MyRepeater" RunAt="server">
        <ItemTemplate>
          <table width="100%">
            <tr>
              <td width="104">
                <a href='images/large/<%# DataBinder.Eval
                  (Container.DataItem, "LargeCover") %>'>
                  <img src='images/small/<%# DataBinder.Eval
                    (Container.DataItem, "SmallCover") %>'
                </a>
              </td>
              <td>
                <table cellpadding="4" height="100%" width="100%">
                  <tr height="48" bgcolor="gainsboro">
                    <td width="40%">
                      <%# DataBinder.Eval
                        (Container.DataItem, "Title") %>
                    </td>
                    <td width="15%" align="center">
                      <%# DataBinder.Eval
                        (Container.DataItem, "Number") %>
                    </td>
                    <td width="15%" align="center">
                      <%# DataBinder.Eval
                        (Container.DataItem, "Year") %>
                    </td>
                    <td width="15%" align="center">
                      <%# DataBinder.Eval
                        (Container.DataItem, "Rating", "{0:f1}") %>
                    </td>
                    <td width="15%" align="center">
                      <%# ((bool) DataBinder.Eval
                        (Container.DataItem, "CGC")) ? "Yes" : "No"
                      %>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="5">
                      <%# DataBinder.Eval
                        (Container.DataItem, "Comment") %>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </ItemTemplate>
      </asp:Repeater>
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

          try
            {
               connection.Open ();

               OleDbCommand
                 command=new OleDbCommand("select * from books order by title, number",connection);

               OleDbDataReader
                 reader=command.ExecuteReader();

               MyRepeater.DataSource=reader;
               MyRepeater.DataBind();
            }
          finally
            {
               connection.Close ();
            }
       }
  }
</script>