<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>ASP.NET && WCF</title>
</head>
<body>
    <form id="DefaultForm" method="post" runat="server">
        <asp:Button ID="btnDoWork" Text="DoWork()" OnClick="BtnDoWorkClick" runat="server"/>
        <asp:Button ID="btnDoWork2" Text="DoWork2()" OnClick="BtnDoWork2Click" runat="server"/>
    </form>
</body>
</html>
