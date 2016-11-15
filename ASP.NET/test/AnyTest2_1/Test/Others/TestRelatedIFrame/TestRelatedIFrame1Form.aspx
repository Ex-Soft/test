<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRelatedIFrame1Form.aspx.cs" Inherits="AnyTest2_1.TestRelatedIFrame1Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Related IFrame (IFrame I)</title>
</head>
<body>
    <asp:Literal ID="JS" Runat="server" />
    <form id="TestRelatedIFrame1Form" runat="server">
        <input type="text" id="HtmlInputText1">
        <input type="button" id="HtmlInputButton1" value="WO Submit" onclick="parent.document.getElementById('iframe2').src='TestRelatedIFrame2Form.aspx?data='+document.getElementById('HtmlInputText1').value">
        <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" Runat="server" />
        <asp:Label ID="LabelInfo" Runat="server" />
    </form>
</body>
</html>
