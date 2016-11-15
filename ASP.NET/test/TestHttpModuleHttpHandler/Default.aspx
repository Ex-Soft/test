<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestHttpModuleHttpHandler.MainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test HttpModule &amp; HttpHandler</title>
</head>
<body>
    <form id="MainForm" runat="server">
    <div>
        <a href="TestHttpModuleHttpHandler.aspx">DoIt!</a>&nbsp;<a href="TestHttpModuleHttpHandler.aspx?q=1">DoIt! (I)</a>&nbsp;<a href="TestHttpModuleHttpHandler.aspx?q=2">DoIt! (II)</a>
    </div>
    </form>
</body>
</html>
