<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDynamicCtrlsForm.aspx.cs" Inherits="AnyTest2_1.TestDynamicCtrlsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Dynamic Ctrls</title>
	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestDynamicCtrlsForm" runat="server">
        <table cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td><asp:PlaceHolder ID="PlaceHolderTextBox" runat="server" /></td>
                <td><asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" runat="server" /></td>
                <td><asp:Label id="LabelInfo" runat="server" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
