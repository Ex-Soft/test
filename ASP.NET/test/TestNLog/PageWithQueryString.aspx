<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageWithQueryString.aspx.cs" Inherits="TestNLog.PageWithQueryString" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page with QueryString</title>
</head>
<body>
    <form id="FormOnPageWithQueryString" runat="server">
        <asp:Label ID="lblQueryString" runat="server"/>
        <hr />
        <asp:TextBox ID="TextBox1" runat="server" />&nbsp;<asp:Label ID="lblTextBox1Text" runat="server"/><br/>
        <asp:Button ID="btnSubmit" Text="Submit" onclick="BtnSubmitClick" runat="server" />
        <hr/>
        <asp:Label ID="lblRequestData" runat="server" />
    </form>
</body>
</html>
