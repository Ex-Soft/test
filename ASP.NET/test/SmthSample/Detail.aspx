<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="SmthSample.DetailPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Detail Page</title>
    <meta name="vs_snapToGrid" content="False" />
</head>
<body>
    <form id="DetailPageForm" runat="server">
        <input type="hidden" id="HtmlInputHiddenId" runat="server" />
        Value: <asp:TextBox Id="TextBoxValue" runat="server" />
        <asp:Button ID="ButtonSave" Text="Save" OnClick="ButtonSave_Click" runat="server" />
    </form>
</body>
</html>
