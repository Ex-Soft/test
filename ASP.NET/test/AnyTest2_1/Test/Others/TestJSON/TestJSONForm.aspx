<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJSONForm.aspx.cs" Inherits="AnyTest2_1.TestJSONForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test JSON</title>
    <script type="text/javascript" charset="windows-1251" src="../../../js/jquery-1.4.2.js"></script>
    <script type="text/javascript" charset="windows-1251" src="TestJSONForm.js"></script>
</head>
<body>
    <form id="TestJSONForm" runat="server">
        <input type="button" value="GetObjects" onclick="OnLoad(true)" />
    </form>
</body>
</html>
