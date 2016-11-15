<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DomainModel.Entities.Product>>" %>
<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var product in Model) { %>
        <% Html.RenderPartial("ProductSummary", product); %>
    <% } %>
    <div class="pager">
        Page:
        <%= Html.PageLinks((int)ViewData["CurrentPage"], (int)ViewData["TotalPages"], x => Url.Action("List", new { page = x })) %>
    </div>
</asp:Content>
