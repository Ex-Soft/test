<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="TestJQuery.MainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test jQuery</title>
    <script type="text/javascript" charset="windows-1251" src="jquery/jquery.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/testjquery.js"></script>
</head>
<body>
    <form id="MainForm" runat="server">
        <input type="button" id="btnDoIt" value="DoIt!" />
    </form>
</body>
</html>
