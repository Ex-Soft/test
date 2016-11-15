<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAnchorForm.aspx.cs" Inherits="AnyTestII.TestAnchorForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Anchor</title>
</head>
<body>
    <form id="TestAnchorForm" runat="server">
        <h1>Test Anchor With Updating URL</h1>
        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td><a href="TestAnchorHandler.aspx" onclick="this.href+='?opt='+document.getElementById('ComboBox1').value">link</td>
                <td>
                    <select id="ComboBox1">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                    </select>
                </td>
            </tr>
        </table>
        <hr />
        <h1>Test Anchor With Binding URL</h1>
        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td><asp:HyperLink ID="HyperLink1" Text="link" NavigateUrl='<%# "TestAnchorHandler.aspx?param1="+1+"&param2="+2+"&opt="+99+"&param3=йцукен" %>' runat="server" /></td>
            </tr>
        </table>
        <hr />
    </form>
</body>
</html>
