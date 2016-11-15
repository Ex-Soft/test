<table id="LoginControlTable" cellpadding="4" runat="server">
	<tr>
		<td>User name:</td>
		<td>
			<asp:TextBox id="LoginControlUserName" runat="server" />
			<asp:RequiredFieldValidator ID="LoginControlUserNameValidator" Runat="server" ControlToValidate="LoginControlUserName"
				ErrorMessage="Please enter a User name" ForeColor="red" Font-Size="8pt" />
		</td>
	</tr>
	<tr>
		<td>Password:</td>
		<td>
			<asp:TextBox id="LoginControlPassword" TextMode="password" runat="server" />
			<asp:RequiredFieldValidator ID="LoginControlPasswordValidator" Runat="server" ControlToValidate="LoginControlPassword"
				ErrorMessage="Please enter a password" ForeColor="red" Font-Size="8pt" />
		</td>
	</tr>
	<tr>
		<td></td>
		<td><asp:LinkButton Text="Log in" runat="server" id="LoginControlLinkButton" OnClick="LoginControlLinkButtonOnClick">Log in</asp:LinkButton></td>
	</tr>
</table>

<script language="C#" runat="server">
  public string BackColor
  {
     get
     {
        return(LoginControlTable.BgColor);
     }
     
     set
     {
        if(LoginControlTable.BgColor.CompareTo(value)!=0)
          LoginControlTable.BgColor=value;
     }
  }
  
  public string UserName
  {
     get
     {
        return(LoginControlUserName.Text);
     }
     
     set
     {
        if(LoginControlUserName.Text.CompareTo(value)!=0)
          LoginControlUserName.Text=value;
     }
  }
  public string Password
  {
     get
     {
        return(LoginControlPassword.Text);
     }
     
     set
     {
        if(LoginControlPassword.Text.CompareTo(value)!=0)
          LoginControlPassword.Text=value;
     }
  }

  public event EventHandler LoginControlLogin;

  void LoginControlLinkButtonOnClick(Object sender, EventArgs e)
  {
     if(LoginControlLogin!=null
        && LoginControlUserNameValidator.IsValid
        && LoginControlPasswordValidator.IsValid
       )
       LoginControlLogin(this,new EventArgs());
  }
</script>
