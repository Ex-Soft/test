<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPostBackUrlIIFirstForm.aspx.cs" Inherits="AnyTest2_1.TestPostBackUrlIIFirstForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test PostBackUrl II (First Form)</title>
</head>
<body>
    <form id="TestPostBackUrlIIFirstForm" runat="server">
        <input type="button" id="InputButtonOpen" value="open" onclick="window.open('TestPostBackUrlIISecondForm.aspx')" />
        <asp:Label ID="Label1" runat="server" />
    </form>
</body>
</html>
