<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestImpersonation.Login" %>
<!doctype html>
<html>
    <head runat="server">
        <meta charset="utf-8"/>
        <title>Login Form</title>
    </head>
    <body>
        <form id="LoginForm" runat="server">
            <asp:Label AssociatedControlID="UserName" runat="server">User name: </asp:Label>
            <asp:TextBox ID="UserName" Text="admin" runat="server" /><br/>
            <asp:Label AssociatedControlID="Password" runat="server">Password: </asp:Label>
            <asp:TextBox ID="Password" TextMode="Password" Text="1" runat="server" /><br/>
            <asp:Button ID="btnLogin" Text="Login" OnClick="BtnLoginClick" runat="server" />
        </form>
    </body>
</html>
