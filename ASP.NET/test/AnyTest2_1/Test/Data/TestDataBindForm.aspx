<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDataBindForm.aspx.cs" Inherits="AnyTest2_1.TestDataBindForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test DataBind</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestDataBindForm" runat="server">
        <asp:Literal ID="Literal1" Text="<%$ AppSettings:LogFileName %>" runat="server" /><br />
        <asp:Literal ID="Literal2" Text="<%$ ConnectionStrings:SybaseASEServer %>" runat="server" /><br />
        <%# a %><br />
        <%# b.ToString() %><br />
        <asp:Image ID="Image1" AlternateText="AlternateText" ToolTip="ToolTip" ImageUrl="<%# ImageUrl %>" BorderWidth="0" runat="server" /><br />
        <select id="Select1" size="3" datavaluefield="Value" datatextfield="key" runat="server" />
        <select id="Select2" datavaluefield="Value" datatextfield="key" runat="server" />
        <asp:ListBox ID="ListBox1" size="3" datavaluefield="Value" datatextfield="key" runat="server" />
        <asp:DropDownList ID="DropDownList1" datavaluefield="Value" datatextfield="key" runat="server" />
        <asp:RadioButtonList ID="RadioButtonList1" datavaluefield="Value" datatextfield="key" runat="server" />
        <asp:CheckBoxList ID="CheckBoxList1" datavaluefield="Value" datatextfield="key" runat="server" />
        <asp:ListBox ID="ListBoxNames" DataValueField="id" DataTextField="name" Size="10" SelectionMode="Multiple" runat="server" />
        <br />
        <asp:Button ID="ButtonGetSelection" Text="Get Selection" OnClick="ButtonGetSelection_Click" runat="server" />
        <br />
        <asp:Literal ID="LiteralSelectionResult" EnableViewState="false" runat="server" />
    </form>
</body>
</html>
