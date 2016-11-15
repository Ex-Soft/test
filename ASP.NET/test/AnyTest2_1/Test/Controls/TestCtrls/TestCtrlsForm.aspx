<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCtrlsForm.aspx.cs" Inherits="AnyTest2_1.TestCtrlsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Controls Form</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestCtrlsForm" runat="server">
        <table cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td><asp:Button ID="ButtonNotSubmit" Text="!Submit" OnClientClick="alert('!Submit');return(false);" runat="server" /></td>
                            <td><asp:Button ID="ButtonSubmit" Text="Submit" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td><asp:Label ID="Label1" Text="Label" runat="server" /></td>
                            <td><asp:Button ID="Button1" Text="Button" Visible="true" runat="server"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td><asp:ImageButton ID="ImageButton1" ImageUrl="../images/wall.gif" AlternateText="Push me" ToolTip="Push Me" BorderStyle="None" BorderWidth="0px" OnClick="ImageButton1_Click" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
