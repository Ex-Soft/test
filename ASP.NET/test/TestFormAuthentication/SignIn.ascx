<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignIn.ascx.cs" Inherits="TestFormAuthentication.SignIn" %>
<table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
	<tr>
		<td align="center"><asp:Label id="LabelMessage" ForeColor="Red" runat="server" /></td>
	</tr>
	<tr>
		<td>
			<table cellspacing="1" cellpadding="0" width="200" align="center" border="0">
				<tr>
					<td>
						<table cellspacing="1" cellpadding="0" width="200" align="center" border="0">
							<tr>
								<td><b>Логин:</b><asp:RequiredFieldValidator id="RequiredFieldValidatorLogin" ControlToValidate="TextBoxLogin" ErrorMessage="*" runat="server" /></td>
								<td width="100%"><asp:TextBox id="TextBoxLogin" runat="server" /></td>
							</tr>
							<tr>
								<td><b>Пароль:</b><asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" ErrorMessage="*" runat="server" /></td>
								<td width="100%"><asp:TextBox id="TextBoxPassword" textmode="password" runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:Button id="btnSignIn" Text="Войти" OnClick="btnSignIn_Click" runat="server" /></td>
				</tr>
				<tr>
					<td align="center"><a href="Register.aspx">Регистрация</a></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<script type="text/javascript">
<!--
var
	SignInTextBoxLogin;
	
if(SignInTextBoxLogin=document.getElementById("<%=TextBoxLogin.ClientID%>"))
	SignInTextBoxLogin.focus();
// -->
</script>
