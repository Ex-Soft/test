<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="ASP.Net FormsAuthentication user impersonation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Home</h2>
    
    <h3>User impersonation control</h3>
    <p><asp:Button ID="ImpersonateButton" runat="server" Text="Impersonate Alice" OnClick="Impersonate" /></p>
    
    <h3>Alice's private page</h3>
    <p><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Alice.aspx" Text="Private/Alice.aspx" /></p>
</asp:Content>

