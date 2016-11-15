<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadFileForm.aspx.cs" Inherits="AnyTest.TestUploadFileForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Upload File</title>
</head>
<body>
    <form id="TestUploadFileForm" runat="server">
        1&nbsp;<input type="file" name="File1" /><br />
        2&nbsp;<input type="file" name="File2" /><br />
        X&nbsp;<input type="file" name="FileX" /><br />
        X&nbsp;<input type="file" name="FileX" /><br />
        0&nbsp;<input type="file" name="File0" /><br />
        0&nbsp;<input type="file" name="File0" /><br />
        <input type="file" id="HtmlInputFile1" runat="server" /><br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="ButtonSubmit_Click" runat="server" />
        <hr />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
