<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRODCtrlsForm.aspx.cs" Inherits="AnyTest2_1.TestRODCtrlsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test ReadOnly or Disabled Ctrls</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta content="False" name="vs_snapToGrid" />
    <script type="text/javascript">
<!--
function DoIt()
{
    var
        Ctrl;
        
    if(Ctrl=document.getElementById("TextBoxReadOnly"))
        Ctrl.value="ReadOnly";
    if(Ctrl=document.getElementById("TextBoxDisabled"))
        Ctrl.value="Disabled";
    if(Ctrl=document.getElementById("TextBoxReadOnlyDisabled"))
        Ctrl.value="ReadOnlyDisabled";
}
// -->
    </script>
</head>
<body>
    <form id="TestRODCtrlsForm" submitdisabledcontrols="false" runat="server">
    <div>
        <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td>ReadOnly</td>
                <td><asp:TextBox id="TextBoxReadOnly" ReadOnly="true" runat="server" /></td>
            </tr>
            <tr>
                <td>Disabled</td>
                <td><asp:TextBox id="TextBoxDisabled" Enabled="false" runat="server" /></td>
            </tr>
            <tr>
                <td>ReadOnly &amp; Disabled</td>
                <td><asp:TextBox id="TextBoxReadOnlyDisabled" ReadOnly="true" Enabled="false" runat="server" /></td>
            </tr>
            <tr>
                <td>Ordinary</td>
                <td><asp:TextBox ID="TextBoxOrdinary" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center"><input type="button" value="DoIt!" onclick="DoIt()" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center"><asp:Button id="ButtonSubmit" Text="Submit" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table style="width: 100%; " cellspacing="0" cellpadding="0" border="1">
                        <tr>
                            <td>AllKeys</td>
                            <td><asp:Label ID="LabelAllKeys" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Keys</td>
                            <td><asp:Label ID="LabelKeys" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Text</td>
                            <td><asp:Label ID="LabelText" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Value</td>
                            <td><asp:Label ID="LabelValue" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
