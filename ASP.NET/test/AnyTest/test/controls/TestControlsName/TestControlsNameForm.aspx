<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestControlsNameForm.aspx.cs" Inherits="AnyTest.TestControlsNameForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Control's Name</title>
</head>
<body>
    <form id="TestControlsNameForm" runat="server">
        <label>HtmlInput1[]: <input type="text" name="HtmlInput1[]" /></label><br/>
        <label>HtmlInput1[]: <input type="text" name="HtmlInput1[]" /></label><br/>
        <label>HtmlInput1[]: <input type="text" name="HtmlInput1[]" /></label><br/>
        <label>HtmlInput2[]: <input type="text" name="HtmlInput2[]" runat="server" /></label><br/>
        <label>HtmlInput2[]: <input type="text" name="HtmlInput2[]" runat="server" /></label><br/>
        <label>HtmlInput2[]: <input type="text" name="HtmlInput2[]" runat="server" /></label><br/>
        <asp:Button ID="btnSubmit" Text="submit" OnClick="OnClickSubmit" runat="server" /><br/>
        <hr/>
        <asp:Label ID="LabelInfo1" runat="server" /><br/>
        <asp:Label ID="LabelInfo2" runat="server" /><br/>
    </form>
</body>
</html>
