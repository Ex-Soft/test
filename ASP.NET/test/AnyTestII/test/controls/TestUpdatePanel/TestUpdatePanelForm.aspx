<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUpdatePanelForm.aspx.cs" Inherits="AnyTestII.TestUpdatePanelForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test UpdatePanel</title>
    <script type="text/javascript">
function f(eventTarget, eventArgument)
{
    //alert("oB!");
    __doPostBack(eventTarget,eventArgument);
}
    </script>
</head>
<body>
    <form id="TestUpdatePanelForm" runat="server">
        <asp:Label ID="LabelIsPostBack" runat="server" />
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="UpdatePanelLabelInfo" runat="server" />
                <asp:Button ID="UpdatePanelButton" Text="DoIt!" OnClick="Button_Click" runat="server" />
                <input type="button" value="DoIt!" onclick="f('<%=UpdatePanelButton.ClientID%>','');" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="LabelInfo" runat="server" />
        <asp:Button ID="Button1" Text="DoIt!" OnClick="Button_Click" runat="server" />
        <input type="button" value="DoIt!" onclick="f('<%=Button1.ClientID%>','');" />
    </form>
</body>
</html>
