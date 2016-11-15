<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDoPostBackForm.aspx.cs" Inherits="AnyTest2_1.TestDoPostBackForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test DoPostBack</title>
    <script type="text/javascript">
<!--
function DoIt()
{
    __doPostBack("ButtonVictim","SmthArgument");
}
// -->
    </script>
</head>
<body>
    <form id="TestDoPostBackForm" runat="server">
        <asp:CheckBox ID="CheckBoxVictim" Text="Victim" AutoPostBack="true" OnCheckedChanged="CheckBoxVictim_Changed" runat="server" /><br />
        <asp:Button ID="ButtonVictim" Text="Victim" OnClick="ButtonVictim_Click" runat="server" /><br />
        <asp:Button ID="ButtonMain" Text="Main" OnClientClick="DoIt()" runat="server" /><br />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
