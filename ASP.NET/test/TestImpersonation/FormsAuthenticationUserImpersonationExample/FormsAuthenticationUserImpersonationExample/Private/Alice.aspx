<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alice.aspx.cs" Inherits="Private_Alice" Title="ASP.Net FormsAuthentication user impersonation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>Alice's private page</h2>
        <p>Only alice may view this page as specified in web.config:</p>
        <pre><code>
  &lt;location path=&quot;Private&quot;&gt;
    &lt;system.web&gt;
      &lt;authorization&gt;
        &lt;allow users=&quot;Alice&quot; /&gt;
        &lt;deny users=&quot;*&quot; /&gt;
      &lt;/authorization&gt;
    &lt;/system.web&gt;
  &lt;/location&gt;
        </code></pre>
</asp:Content>

