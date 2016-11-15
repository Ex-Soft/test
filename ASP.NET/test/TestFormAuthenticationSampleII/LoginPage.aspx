<html>
  <body>
    <h1>Please Log In</h1>
    <hr>
    <form runat="server">
      <table cellpadding="8">
        <tr>
          <td>
            User Name:
          </td>
          <td>
            <asp:TextBox ID="UserName" RunAt="server" />
          </td>
        </tr>
        <tr>	
          <td>
            Password:
          </td>
          <td>
            <asp:TextBox ID="Password" TextMode="password"
              RunAt="server" />
          </td>
        </tr>
        <tr>
          <td>
            <asp:Button Text="Log In" OnClick="OnLogIn"
              RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
      </table>
    </form>
    <hr>
    <h3><asp:Label ID="Output" RunAt="server" /></h3>
  </body>
</html>

<script language="C#" runat="server">
  void OnLogIn (Object sender, EventArgs e)
  {
      if (FormsAuthentication.Authenticate (UserName.Text,
          Password.Text))
          FormsAuthentication.RedirectFromLoginPage (UserName.Text,
              false);
      else
          Output.Text = "Invalid login";
  }
</script>