<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPageEventsForm.aspx.cs" Inherits="AnyTest2_1.TestPageEventsForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <!-- <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" /> -->
    <title>Test Page Events</title>
    <script type="text/javascript">
<!--
var
    TestVar=<%=TestVar%>;
// -->
    </script>
</head>
<body>
    <form id="TestPageEventsForm" runat="server">
        <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="Button_Click" runat="server" /><br />
        <asp:Label ID="LabelInfo" runat="server" />
    </form>
</body>
</html>
