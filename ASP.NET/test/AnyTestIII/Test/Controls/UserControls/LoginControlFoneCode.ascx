<%@ Control Inherits="LoginBase" Src="LoginBase.cs" %>

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
