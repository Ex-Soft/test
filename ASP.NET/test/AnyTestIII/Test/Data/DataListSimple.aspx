<html>
<head>
<title>DataList Simple</title>
</head>
  <body>
    <h1>DataList Simlpe</h1>
    <hr>
    <form runat="server">
      <asp:DataList id="DataListSimple" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemCommand="OnItemCommand">
        <ItemTemplate>
          <asp:LinkButton Text="<%# Container.DataItem %>" runat="server" /><br>
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
           string[]
             beatles={"John", "Paul", "George", "Ringo"};

           DataListSimple.DataSource=beatles;
           DataListSimple.DataBind();
        }
  }

  void OnItemCommand(Object sender, DataListCommandEventArgs e) 
  {
     DataListSimple.SelectedIndex=e.Item.ItemIndex;
  }
</script>