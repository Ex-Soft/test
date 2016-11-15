<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTransferRedirectMainForm.aspx.cs" Inherits="AnyTestII.TestTransferRedirectMainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Transfer vs Redirect (Main Form)</title>
</head>
<body>
    <form id="TestTransferRedirectMainForm" runat="server">
        <asp:Button ID="ButtonTransfer" Text="Transfer" OnClick="Button_Click" runat="server" />
        <asp:Button ID="ButtonRedirect" Text="Redirect" OnClick="Button_Click" runat="server" />
        <br />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
