<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDynamicFrameForm.aspx.cs" Inherits="AnyTest2_1.TestDynamicFrameForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test Dynamic Frame</title>
    <meta name="vs_snapToGrid" content="False" />
</head>
<body>
    <form id="TestDynamicFrameForm" runat="server">
        <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="True" runat="server">
            <asp:ListItem Value="File" Text="File" Selected="True" />
            <asp:ListItem Value="HtmlTextWriter" Text="HtmlTextWriter" />
        </asp:RadioButtonList>
        <iframe id="IFrameDynamic" runat="server"></iframe><br />
        <input type="submit" id="btnSubmit" value="Submit" />
    </form>
</body>
</html>
