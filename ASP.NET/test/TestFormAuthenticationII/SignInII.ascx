<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SignInII.ascx.cs" Inherits="TestFormAuthentication.SignInII" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
	<tr>
		<td align="center"><asp:Label id="LabelMessage" ForeColor="Red" runat="server" /></td>
	</tr>
	<tr>
		<td>
			<table class="but" cellSpacing="1" cellPadding="0" width="200" align="center" border="0">
				<tr>
					<td>
						<asp:Panel ID="PanelLoginPassword" Runat="server">
							<table class="but" cellSpacing="1" cellPadding="0" width="200" align="center" border="0">
								<tr>
									<td align="center" colspan="2"><b>Введіть ваш логін та пароль</b><br><br></td>
								</tr>
								<tr>
									<td><b>&nbsp;Логін:&nbsp;<br></b><asp:RequiredFieldValidator id="RequiredFieldValidatorLogin" ControlToValidate="TextBoxLogin" ErrorMessage="*" runat="server" /></td>
									<td width="100%"><asp:TextBox id="TextBoxLogin" runat="server" CssClass="textfield" BackColor="white" /></td>
								</tr>
								<tr>
									<td><b>&nbsp;Пароль:&nbsp;<br></b><asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" ErrorMessage="*" runat="server" /></td>
									<td width="100%"><asp:TextBox id="TextBoxPassword" runat="server" CssClass="textfield" textmode="password" BackColor="white" /></td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Panel ID="PanelAdditionalInfo" Visible="false" Runat="server">
							<table class="but" cellSpacing="1" cellPadding="0" width="200" align="center" border="0">
								<tr>
									<td align="center" colspan="2"><b>Введіть додаткову інформацію</b><br><br></td>
								</tr>
								<tr>
									<td><b>&nbsp;Місто:&nbsp;<br></b><asp:RequiredFieldValidator id="RequiredFieldValidatorTextBoxCity" ControlToValidate="TextBoxCity" ErrorMessage="*" runat="server" /></td>
									<td width="100%"><asp:TextBox id="TextBoxCity" runat="server" CssClass="textfield" BackColor="white" /></td>
								</tr>
								<tr>
									<td><b>&nbsp;Номер контактного телефону:&nbsp;<br></b><asp:RequiredFieldValidator id="RequiredFieldValidatorPhone" ControlToValidate="TextBoxPhone" ErrorMessage="*" runat="server" /></td>
									<td width="100%"><asp:TextBox id="TextBoxPhone" runat="server" CssClass="textfield" BackColor="white" /></td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
				<tr>
					<td align="center" colspan="2"><br><asp:Button id="btnSignIn" runat="server" CssClass="but" Text="Вхід" /><br><br></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<script type="text/javascript">
<!--
var
	SignInIITextBoxLogin;
	
if(SignInIITextBoxLogin=document.getElementById("<%=TextBoxLogin.ClientID%>"))
	SignInIITextBoxLogin.focus();
// -->
</script>

