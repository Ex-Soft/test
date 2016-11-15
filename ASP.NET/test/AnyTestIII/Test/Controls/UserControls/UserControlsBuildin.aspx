<%@ Register TagPrefix="UserBuildin" TagName="LoginControlBuildin" Src="LoginControlBuildin.ascx" %>
<HTML>
	<body>
		<h1>User Control Demo (buildin)</h1>
		<hr>
		<form runat="server">
			<UserBuildin:LoginControlBuildin ID="MyLogin" BackColor="#ccccff" runat="server" OnLoginControlLogin="OnLoginUser" />
		</form>
		<hr>
		<h3><asp:Label ID="Output" Runat="server" /></h3>
	</body>
</HTML>

<script language="C#" runat="server">
  void OnLoginUser(Object sender, EventArgs e)
  {
     Output.Text="Hello, "+MyLogin.UserName;
  }
</script>