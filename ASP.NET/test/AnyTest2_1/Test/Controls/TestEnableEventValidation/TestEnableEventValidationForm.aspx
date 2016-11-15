<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TestEnableEventValidationForm.aspx.cs" Inherits="AnyTest2_1.TestEnableEventValidationForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test EnableEventValidation</title>
    <meta name="vs_snapToGrid" content="False" />
    <script type="text/javascript">
<!--
function ChangeDropDownListVictim()
{
    var
        Ctrl;
        
    if(!(Ctrl=document.getElementById("DropDownListVictim")))
        return;
        
    Ctrl.options.length=0;
    for(var i=10; i<15; ++i)
        Ctrl.options.add(new Option(i,i,false,false));
}
// -->
    </script>
</head>
<body>
    <h1>EnableEventValidation=&quot;false&quot;</h1>
    <form id="TestEnableEventValidationForm" runat="server">
        <asp:DropDownList ID="DropDownListVictim" runat="server" /><br />
        <input type="button" id="ButtonChangeDropDownListVictim" value="ChangeDropDownListVictim" onclick="ChangeDropDownListVictim()" /><br />
        <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" runat="server" /><br />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
