<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestPaths.MainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>&laquo;Test Paths&raquo;</title>
    <script type="text/javascript" charset="utf-8" src="js/Default.js"></script>
</head>
<body>
    <form id="MainForm" runat="server">
        <input type="button" onclick="DoIt();" value="DoIt!" />
        <hr />
        <img id="ImgVictim1" onload="alert('ImgVictim1: OnLoad()');" onerror="alert('ImgVictim1: OnError()');" onabort="alert('ImgVictim1: OnAbort()');" />
        <img id="ImgVictim2" onload="alert('ImgVictim2: OnLoad()');" onerror="alert('ImgVictim2: OnError()');" onabort="alert('ImgVictim2: OnAbort()');" />
        <img id="ImgVictim3" onload="alert('ImgVictim3: OnLoad()');" onerror="alert('ImgVictim3: OnError()');" onabort="alert('ImgVictim3: OnAbort()');" />
    </form>
</body>
</html>
