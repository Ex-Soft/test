<html>
  <body>
    <h1>Public Page</h1>
    <hr>
    <form runat="server">
      <asp:Button Text="View Secret Message" OnClick="OnViewSecret"
        RunAt="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void OnViewSecret (Object sender, EventArgs e)
  {
      Response.Redirect ("Secret/ProtectedPage.aspx");
  }
</script>