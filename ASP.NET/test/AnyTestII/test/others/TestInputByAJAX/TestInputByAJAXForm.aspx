<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestInputByAJAXForm.aspx.cs" Inherits="AnyTestII.TestInputByAJAXForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Input By AJAX</title>
    <script type="text/javascript" charset="windows-1251" src="../../../ajax.js"></script>
    <script type="text/javascript" charset="windows-1251" src="TestInputByAJAX.js"></script>
</head>
<body>
    <form id="TestInputByAJAXForm" runat="server">
        <input type="text" id="HtmlInputTextSubstring" />
        <input type="button" id="HtmlInputButtonLoad" value="Load..." onclick="LoadNSI(document.getElementById('HtmlInputTextSubstring').value,document.getElementById('AVAILABLE'))" />
        <select id="AVAILABLE" multiple />
    </form>
</body>
</html>
