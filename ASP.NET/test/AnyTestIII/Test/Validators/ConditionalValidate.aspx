<html>
  <body>
    <h1>Conditional Validation Demo</h1>
    <hr>
    <form runat="server">
      <table cellpadding="4">
        <tr>
          <td align="right">
            Name
          </td>
          <td>
            <asp:TextBox ID="Name" RunAt="server" />
          </td>
          <td>
            <asp:RequiredFieldValidator
              ControlToValidate="Name"
              ErrorMessage="Please enter your name"
              Display="dynamic"
              Color="red"
              RunAt="server"
            />
          </td>
        </tr>
        <tr>
          <td align="right">
            E-Mail Address
          </td>
          <td>
            <asp:TextBox ID="EMail" RunAt="server" />
          </td>
          <td>
            <asp:RequiredFieldValidator
              ControlToValidate="EMail"
              ErrorMessage="Please enter your e-mail address"
              Display="dynamic"
              Color="red"
              Enabled="false"
              ID="EMailRequiredValidator"
              RunAt="server"
            />
            <asp:RegularExpressionValidator
              ControlToValidate="EMail"
              ValidationExpression="^[\w\.-]+@[\w-]+\.[\w\.-]+$"
              ErrorMessage="Invalid e-mail address"
              Display="dynamic"
              Color="red"
              Enabled="false"
              ID="EMailExpressionValidator"
              RunAt="server"
            />
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <asp:CheckBox ID="Confirm"
              Text="E-mail my confirmation"
              OnCheckedChanged="OnCheckBoxClicked"
              AutoPostBack="true" RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <asp:Button Text="Register" OnClick="OnRegister"
              RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
      </table>
      <br><hr><br>
      <asp:Label ID="Output" RunAt="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void OnCheckBoxClicked (Object sender, EventArgs e)
  {
      EMailRequiredValidator.Enabled = Confirm.Checked;
      EMailExpressionValidator.Enabled = Confirm.Checked;
  }

  void OnRegister (Object sender, EventArgs e)
  {
      if (IsValid) {
          if (Confirm.Checked) {
              Output.Text =
                  "Confirmation will be e-mailed to " +
                  EMail.Text + ".";
          }
          else {
              Output.Text =
                  "At your request, no confirmation will " +
                  "be sent.";
          }
      }
  }
</script>