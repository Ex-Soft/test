<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<html>
<head>
<title>Repeater simple</title>
</head>
  <body>
    <h1>Repeater simple</h1>
    <hr>
    <form runat="server">
      Repeater1<br>
      <asp:repeater id="MyRepeater1" runat="server">
        <HeaderTemplate>
          <ul>
        </HeaderTemplate>
        <ItemTemplate>
          <li><%# Container.DataItem %><br>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <li type="circle"><span style="background-color:gainsboro; width:128;"><%# Container.DataItem %></span><br>
        </AlternatingItemTemplate>
        <FooterTemplate>
          </ul>
        </FooterTemplate>
      </asp:repeater><br>
      Repeater2<br>
      <asp:repeater id="MyRepeater2" runat="server">
        <HeaderTemplate>
          <ul type="square">
        </HeaderTemplate>
        <ItemTemplate>
          <li><%# DataBinder.Eval(Container.DataItem,"Name")+" ("+DataBinder.Eval(Container.DataItem,"Salary","{0:c}")+")" %><br>
        </ItemTemplate>
        <FooterTemplate>
          </ul>
        </FooterTemplate>
      </asp:repeater><br>
      Repeater3<br>
      <asp:repeater id="MyRepeater3" runat="server">
        <HeaderTemplate>
          <ol type="a">
        </HeaderTemplate>
        <ItemTemplate>
          <li><%# ((System.Data.Common.DbDataRecord)Container.DataItem)["Name"]+" ("+String.Format("{0:c}",((System.Data.Common.DbDataRecord)Container.DataItem)["Salary"])+")" %><br>
        </ItemTemplate>
        <FooterTemplate>
          </ol>
        </FooterTemplate>
      </asp:repeater><br>
      Repeater4
      <asp:repeater id="MyRepeater4" runat="server" OnItemCommand="OnItemCommand">
        <HeaderTemplate>
          <table border="1">
            <tr>
              <td align="center">Name</td>
              <td align="center">Salary</td>
              <td align="center">Action</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
          <tr>
            <td><%# DataBinder.Eval(Container.DataItem,"Name") %></td>
            <td align="center"><%# DataBinder.Eval(Container.DataItem,"Salary","{0:c}") %></td>
            <td align="center"><asp:Button text="Add to Cart" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Salary","{0:c}") %>' /></td>
          </tr>
        </ItemTemplate>
        <FooterTemplate>
          </table>
        </FooterTemplate>
      </asp:repeater>
      <asp:label id="Output" runat="server"></asp:label>
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void Page_Load (Object sender, EventArgs e)
  {
     if(!IsPostBack)
       {
          string[]
            beatles={"John", "Paul", "George", "Ringo"};

          MyRepeater1.DataSource=beatles;
          MyRepeater1.DataBind();

          string
            connstring = (string)Application["connectionString"];
 
          OleDbConnection
            connection=new OleDbConnection(connstring);

          try
            { 
               try
                 {
                    connection.Open();

                    OleDbCommand
                      command=new OleDbCommand("select * from staff",connection);

                    OleDbDataReader
                      reader=command.ExecuteReader();

                    MyRepeater2.DataSource=reader;
                    MyRepeater2.DataBind();
                    reader.Close();

                    reader=command.ExecuteReader();
                    MyRepeater3.DataSource=reader;
                    MyRepeater3.DataBind();
                    reader.Close();

                    OleDbDataAdapter
                      da=new OleDbDataAdapter();

                    da.SelectCommand=command;

                    DataSet
                      ds=new DataSet();

                    da.Fill(ds,"OutputDataSetName");
                    MyRepeater4.DataSource=ds.Tables["OutputDataSetName"];
                    MyRepeater4.DataBind();
                 }
               catch(OleDbException eException)
                 {
                    Output.Text=eException.Message;
                 }
            }
          finally
            {
               connection.Close();
            }
       }
  }

  void OnItemCommand(object sender, RepeaterCommandEventArgs e)
  {
     Output.Text=e.CommandArgument.ToString();
  }
</script>