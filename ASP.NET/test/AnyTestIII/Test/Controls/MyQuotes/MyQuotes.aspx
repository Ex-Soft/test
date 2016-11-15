<%@ Register TagPrefix="user" TagName="MyQuotes" Src="MyQuotes.ascx" %>

<html>
  <body>
    <h1>MyQuotes</h1>
    <hr>
    <form runat="server">
      <asp:CheckBox ID="ShowQuotes" Text="Show quotes" RunAt="server"
        AutoPostBack="true" OnCheckedChanged="OnCheckBoxClicked" />
      <span ID="PlaceHolder" runat="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
  const string CookieName = "MyQuotes";
  const string CookieVal = "ShowQuotes";

  void Page_Load (Object sender, EventArgs e)
  {
      if (!IsPostBack) {
          // If a "MyQuotes" cookie is present, load the
          // user control and check the "Show quotes" box
          HttpCookie cookie = Request.Cookies["MyQuotes"];
          if (cookie != null) {
              MyQuotes_ascx ctrl =
                  (MyQuotes_ascx) LoadControl ("MyQuotes.ascx");
              ctrl.Width = Unit.Percentage (100);
              PlaceHolder.Controls.Add (ctrl);
              ShowQuotes.Checked = true;
          }
      }
  }

  void OnCheckBoxClicked (Object sender, EventArgs e)
  {
      if (ShowQuotes.Checked) {
          // Load the user control
          MyQuotes_ascx ctrl =
              (MyQuotes_ascx) LoadControl ("MyQuotes.ascx");
          ctrl.Width = Unit.Percentage (100);
          PlaceHolder.Controls.Add (ctrl);

          // Return a "MyQuotes" cookie that's good for one year
          HttpCookie cookie = new HttpCookie (CookieName, CookieVal);
          cookie.Expires = DateTime.Now + new TimeSpan (365, 0, 0, 0);
          Response.Cookies.Add (cookie);
      }
      else {
          // Delete the "MyQuotes" cookie
          HttpCookie cookie = new HttpCookie (CookieName);
          cookie.Expires = new DateTime (1959, 9, 30);
          Response.Cookies.Add (cookie);
      }
  }
</script>