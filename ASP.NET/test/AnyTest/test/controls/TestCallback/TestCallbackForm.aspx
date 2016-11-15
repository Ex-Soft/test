<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCallbackForm.aspx.cs" Inherits="AnyTest.TestCallbackForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Test Callback</title>
        <script type="text/javascript">
var 
    value1 = 0,
    value2 = 0;

function ReceiveServerData2(arg, context)
{
    var
        Ctrl;
        
    if((Ctrl=document.getElementById("Message2")))
        Ctrl.innerHTML = arg;

    value2 = arg;
}

function ProcessCallBackError(arg, context)
{
    var 
        Ctrl;

    if ((Ctrl = document.getElementById("Message2")))
        Ctrl.innerHTML = 'An error has occurred.';
}

function ClientValidate(source, arguments)
{
    if (arguments.Value % 2 == 0)
    {
        arguments.IsValid = true;
    }
    else
    {
        arguments.IsValid = false;
    }
}

function OnOff(enable)
{
    var
        Ctrl;

    if (Ctrl = document.getElementById("tbCustomValidator"))
        ValidatorEnable(Ctrl, enable);
}
        </script>
    </head>
    <body>
        <form id="TestCallbackForm" runat="server">
            <asp:RadioButton ID="rbOn" GroupName="radioOnOff" Text="On" Checked="true" onclick="OnOff(true)" runat="server" />
            <asp:RadioButton ID="rbOff" GroupName="radioOnOff" Text="Off" Checked="false" onclick="OnOff(false)" runat="server" />
            <hr />
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>1st</asp:ListItem>
                <asp:ListItem>2nd</asp:ListItem>
                <asp:ListItem>3rd</asp:ListItem>
            </asp:ListBox> <!-- ControlToValidate="ListBox1" EnableClientScript="true" ClientValidationFunction="ClientValidate" -->
            <asp:CustomValidator ID="lbCustomValidator" OnServerValidate="OnServerValidateListBox" runat="server" />
            <br/>
            <asp:TextBox ID="TextBox1" runat="server" /> <!-- ControlToValidate="TextBox1" -->
            <asp:CustomValidator ID="tbCustomValidator" OnServerValidate="OnServerValidateTextBox" runat="server" />
            <br />
            <asp:Button ID="btnSubmit" Text="submit" OnClick="OnClickSubmit" runat="server" />
            <asp:Label ID="LabelInfo" runat="server" />
            <hr />
            Callback 1 result: <span id="Message1">0</span>
            <br />
            Callback 2 result: <span id="Message2">0</span>
            <br /> <br />
            <input type="button" value="ClientCallBack1" onclick="CallTheServer1(value1, alert('Increment value'))"/>
            <input type="button" value="ClientCallBack2" onclick="CallTheServer2(value2, alert('Increment value'))"/>
            <br /> <br />
            <asp:Label id="MyLabel" runat="server" />
        </form>
    </body>
</html>
