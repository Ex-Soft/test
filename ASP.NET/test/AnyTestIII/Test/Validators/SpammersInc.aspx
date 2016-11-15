<html>
  <head>
    <style>
    <!--
      body { font: 10pt verdana };
      table { font: 10pt verdana };
      input { font: 10pt verdana };
    -->
    </style>
  </head>
  <body>
    <table cellpadding="4" border="1">
      <tr bgcolor="yellow">
        <td>
Hi! We're Spammers, Incorporated. If you'll provide us with an e-mail
address, we'll clog your in-box with e-mail. Leave a snail mail address
and we'll bombard you with paper mail, too. If you're a totally
trusting person, type in a credit card number. We'll use it to defray
office costs next month.
        </td>
      </tr>
    </table>
    <h3>Yes, I want to be spammed. Sign me up now!</h3>
    <form runat="server">
      <table cellpadding="4">
        <tr>
          <td align="right">
            Name
          </td>
          <td>
            <asp:TextBox ID="Name" RunAt="server" ToolTip="Type your name here" />
          </td>
          <td>
            <asp:RequiredFieldValidator
              ControlToValidate="Name"
              ErrorMessage="Please enter your name"
              Display="dynamic"
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
              RunAt="server"
            />
            <asp:RegularExpressionValidator
              ControlToValidate="EMail"
              ValidationExpression="^[\w\.-]+@[\w-]+\.[\w\.-]+$"
              ErrorMessage="Invalid e-mail address"
              Display="dynamic"
              RunAt="server"
            />
          </td>
        </tr>
        <tr>
          <td align="right">
            Address
          </td>
          <td>
            <asp:TextBox ID="Address" RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td align="right">
            City
          </td>
          <td>
            <asp:TextBox ID="City" RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td align="right">
            State
          </td>
          <td>
            <asp:DropDownList ID="StateList" RunAt="server">
              <asp:ListItem Text="AL" RunAt="server" />
              <asp:ListItem Text="AK" RunAt="server" />
              <asp:ListItem Text="AR" RunAt="server" />
              <asp:ListItem Text="AZ" RunAt="server" />
              <asp:ListItem Text="CA" RunAt="server" />
              <asp:ListItem Text="CO" RunAt="server" />
              <asp:ListItem Text="CT" RunAt="server" />
              <asp:ListItem Text="DC" RunAt="server" />
              <asp:ListItem Text="DE" RunAt="server" />
              <asp:ListItem Text="FL" RunAt="server" />
              <asp:ListItem Text="GA" RunAt="server" />
              <asp:ListItem Text="HI" RunAt="server" />
              <asp:ListItem Text="IA" RunAt="server" />
              <asp:ListItem Text="ID" RunAt="server" />
              <asp:ListItem Text="IL" RunAt="server" />
              <asp:ListItem Text="IN" RunAt="server" />
              <asp:ListItem Text="KS" RunAt="server" />
              <asp:ListItem Text="KY" RunAt="server" />
              <asp:ListItem Text="LA" RunAt="server" />
              <asp:ListItem Text="MA" RunAt="server" />
              <asp:ListItem Text="MD" RunAt="server" />
              <asp:ListItem Text="ME" RunAt="server" />
              <asp:ListItem Text="MI" RunAt="server" />
              <asp:ListItem Text="MN" RunAt="server" />
              <asp:ListItem Text="MO" RunAt="server" />
              <asp:ListItem Text="MS" RunAt="server" />
              <asp:ListItem Text="MT" RunAt="server" />
              <asp:ListItem Text="NC" RunAt="server" />
              <asp:ListItem Text="ND" RunAt="server" />
              <asp:ListItem Text="NE" RunAt="server" />
              <asp:ListItem Text="NH" RunAt="server" />
              <asp:ListItem Text="NJ" RunAt="server" />
              <asp:ListItem Text="NM" RunAt="server" />
              <asp:ListItem Text="NV" RunAt="server" />
              <asp:ListItem Text="NY" RunAt="server" />
              <asp:ListItem Text="OH" RunAt="server" />
              <asp:ListItem Text="OK" RunAt="server" />
              <asp:ListItem Text="OR" RunAt="server" />
              <asp:ListItem Text="PA" RunAt="server" />
              <asp:ListItem Text="RI" RunAt="server" />
              <asp:ListItem Text="SC" RunAt="server" />
              <asp:ListItem Text="SD" RunAt="server" />
              <asp:ListItem Text="TN" RunAt="server" />
              <asp:ListItem Text="TX" RunAt="server" />
              <asp:ListItem Text="UT" RunAt="server" />
              <asp:ListItem Text="VA" RunAt="server" />
              <asp:ListItem Text="VT" RunAt="server" />
              <asp:ListItem Text="WA" RunAt="server" />
              <asp:ListItem Text="WI" RunAt="server" />
              <asp:ListItem Text="WV" RunAt="server" />
              <asp:ListItem Text="WY" RunAt="server" />
            </asp:DropDownList>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td align="right">
            Zip
          </td>
          <td>
            <asp:TextBox ID="ZipCode" RunAt="server" />
          </td>
          <td>
            <asp:RegularExpressionValidator
              ControlToValidate="ZipCode"
              ValidationExpression="^(\d{5}|\d{5}\-\d{4})$"
              ErrorMessage="Invalid zip code"
              Display="dynamic"
              RunAt="server"
            />
          </td>
        </tr>
        <tr>
          <td align="right">
            Credit Card Number
          </td>
          <td>
            <asp:TextBox ID="CreditCardNumber" RunAt="server" />
          </td>
          <td>
            <asp:RegularExpressionValidator
              ControlToValidate="CreditCardNumber"
              ValidationExpression="^[\d\-]{15,20}$"
              ErrorMessage="Invalid card number"
              Display="dynamic"
              RunAt="server"
            />
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <asp:Button Text="Sign Me Up" OnClick="OnSignMeUp"
              RunAt="server" />
          </td>
          <td>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void OnSignMeUp (Object sender, EventArgs e)
  {
      if (IsValid) {
          StringBuilder sb = new StringBuilder ("Thanks.aspx?Name=", 256);
          sb.Append (Name.Text);
          sb.Append ("&EMail=");
          sb.Append (EMail.Text);

          string address = Address.Text;
          string city = City.Text;
          string state = StateList.SelectedItem.Text;
          string zip = ZipCode.Text;

          if (address.Length > 0 && city.Length > 0 && zip.Length > 0) {
              sb.Append ("&Address=");
              sb.Append (address);
              sb.Append ("&City=");
              sb.Append (city);
              sb.Append ("&State=");
              sb.Append (state);
              sb.Append ("&ZipCode=");
              sb.Append (zip);
          }

          string number = CreditCardNumber.Text;

          if (number.Length > 0) {
              sb.Append ("&CreditCardNumber=");
              sb.Append (number);
          }

          Response.Redirect (sb.ToString ());
      }
  }
</script>