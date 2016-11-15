<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestFormAuthentication.TestFormAuthenticationForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>&laquo;Test Form Authentication&raquo;</title>
</head>
<body>
    <form id="TestFormAuthenticationForm" runat="server">
        <h1 style="text-align: center;">Main Form</h1>
        <hr />
        <asp:Label ID="LabelInfo" runat="server" />
        <hr />
        <a href="Page1.aspx">Page# 1</a>
        <a href="Page2.aspx">Page# 2</a>
        <a href="Page3.aspx">Page# 3</a>
        <a href="PageWithXHR.aspx">Page with XMLHttpRequest</a>
    </form>
</body>
</html>
