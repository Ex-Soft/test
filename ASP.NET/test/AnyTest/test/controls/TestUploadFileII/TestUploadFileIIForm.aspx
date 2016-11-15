<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadFileIIForm.aspx.cs" Inherits="AnyTest.TestUploadFileIIForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Upload File II</title>
</head>
<body>
    <form id="TestUploadFileIIForm" enctype="multipart/form-data" runat="server">
        <input type="file" name="File1" /><br/>
        <input type="submit" value="submit" />
    </form>
</body>
</html>
