<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRefreshForm.aspx.cs" Inherits="AnyTestII.TestRefreshForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Refresh</title>
</head>
<body>
    <form id="TestRefreshForm" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" />
        <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" runat="server" />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
