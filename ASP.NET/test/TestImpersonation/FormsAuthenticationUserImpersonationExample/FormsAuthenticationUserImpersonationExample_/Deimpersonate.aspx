<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="ASP.Net FormsAuthentication user impersonation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>User impersonation has ended and you have been redirected accordingly</h2>
    <p><asp:HyperLink ID="link" runat="server" NavigateUrl="~/Default.aspx" Text="Return" /></p>
</asp:Content>

