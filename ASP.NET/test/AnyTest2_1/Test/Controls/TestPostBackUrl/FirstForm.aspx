<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstForm.aspx.cs" Inherits="AnyTest2_1.FirstForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>First Form</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta content="False" name="vs_snapToGrid" />
</head>
<body>
    <form id="FirstForm" runat="server">
    <div>
        <h1>First Form</h1>
        <hr>
        <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td><asp:TextBox id="TextBoxFirstForm" runat="server" /></td>
                <td><asp:Button id="ButtonSubmit" Text="Submit" PostBackUrl="SecondForm.aspx" runat="server" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
