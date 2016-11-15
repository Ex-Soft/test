<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestNLog._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>&laquo;Test NLog&raquo;</title>
</head>
<body>
    <form id="TestNLogMainForm" runat="server">
        <h1 style="text-align: center;">Main Form</h1>
        <hr />
        <asp:Label ID="LabelInfo" runat="server" />
        <hr />
        <a href="PageWithQueryString.aspx?queryString1=TestQueryString1&queryString2=TestQueryString2">Page with QueryString</a>
        <hr />
        <asp:TextBox ID="TextBox1" runat="server" />&nbsp;<asp:Label ID="lblTextBox1Text" runat="server"/><br/>
        <asp:Button ID="btnSubmit" Text="Submit" onclick="BtnSubmitClick" runat="server" />
        <hr/>
        <asp:Label ID="lblRequestData" runat="server" />
    </form>
</body>
</html>
