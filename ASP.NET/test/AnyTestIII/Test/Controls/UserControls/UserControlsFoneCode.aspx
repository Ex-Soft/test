<%@ Register TagPrefix="UserFoneCode" TagName="LoginControlFoneCode" Src="LoginControlFoneCode.ascx" %>
<HTML>
	<body>
		<h1>User Control Demo (fone code)</h1>
		<hr>
		<form runat="server">
			<UserFoneCode:LoginControlFoneCode ID="MyLogin" BackColor="#ccccff" runat="server" OnLoginControlLogin="OnLoginUser" />
		</form>
		<hr>
		<h3><asp:Label ID="Output" Runat="server" /></h3>
	</body>
</HTML>

<script language="C#" runat="server">
  void OnLoginUser(Object sender, LoginEventArgs e)
  {
     if(e.IsValid)     
       Output.Text="Hello, "+MyLogin.UserName;
     else
       {
          Output.Text="Invalid login";
          MyLogin.UserName="";
          MyLogin.Password="";
       }
  }
</script>