<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPostBackUrlIISecondForm.aspx.cs" Inherits="AnyTest2_1.TestPostBackUrlIISecondForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test PostBackUrl II (Second Form)</title>
</head>
<body>
    <form id="TestPostBackUrlIISecondForm" runat="server">
        <asp:TextBox ID="TestPostBackUrlIISecondFormTextBox1" runat="server" />
        <asp:Button ID="Button1" Text="submit" PostBackUrl="TestPostBackUrlIIFirstForm.aspx" runat="server" />
    </form>
</body>
</html>
