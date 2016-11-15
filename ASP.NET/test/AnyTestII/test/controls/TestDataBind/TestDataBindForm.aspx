<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDataBindForm.aspx.cs" Inherits="AnyTestII.TestDataBindFormForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test DataBind</title>
    <script type="text/javascript">
<!--
var
    tmpStringIsEmpty=<%=string.IsNullOrEmpty(tmpString).ToString().ToLower()%>,
    tmpStringIsEmpty=<%#string.IsNullOrEmpty(tmpString).ToString().ToLower()%>;
// -->
    </script>
</head>
<body>
    <form id="TestDataBindFormForm" runat="server">
        <div id="TestDiv" visible="<%#!string.IsNullOrEmpty(tmpString)%>" runat="server">
            <b>Test</b>
        </div>
        <div id="TestDivII" visible="false" runat="server">
            <b>TestII</b>
        </div>
        <table id="HtmlTable1" visible="<%#!string.IsNullOrEmpty(tmpString)%>" runat="server">
            <tr>
                <td><b>TD</b></td>
                <td id="HtmlTd1" visible="<%#!string.IsNullOrEmpty(tmpString)%>" runat="server"><b>TD</b></td>
            </tr>
        </table>
        <table id="HtmlTable2" runat="server">
            <tr>
                <td><b>TD II</b></td>
                <td><b>TD II</b></td>
                <td id="HtmlTd2" runat="server"><b>TD II</b></td>
            </tr>
        </table>
        <asp:Button ID="ButtonSubmit" Text="submit" runat="server" />
    </form>
</body>
</html>
