<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestIFrameSubmitMainForm.aspx.cs" Inherits="AnyTestII.TestIFrameSubmitMainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Test IFrame Submit (Main Form)</title>
</head>
<body>
    <form id="TestIFrameSubmitMainForm" runat="server">
        <input type="button" value="DoIt!" onclick="document.getElementById('IFrame1').contentWindow.document.getElementById('TestIFrameSubmitIFrameForm').submit()" />
    </form>
    <iframe id="IFrame1" src="TestIFrameSubmitIFrameForm.aspx"></iframe>
</body>
</html>
