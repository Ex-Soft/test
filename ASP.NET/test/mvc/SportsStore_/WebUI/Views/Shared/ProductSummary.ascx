<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.Product>" %>
<div class="item">
    <h3><%= Model.Name %></h3>
    <%= Model.Description %>
    <h4><%= Model.Price.ToString("c") %></h4>
</div>

