<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestImageForm.aspx.cs" Inherits="AnyTest2_1.TestImageForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test Image</title>
    <script type="text/javascript">
<!--
function ResizeImage()
{
    var
        Ctrl;
        
    if(!(Ctrl=document.getElementById("HtmlInputHiddenScale")))
        return;
        
    Ctrl.value = Ctrl.value=="100" ? "50" : "100";
    
    if(!(Ctrl=document.getElementById("TestImageForm")))
        return;

    Ctrl.submit();
}
// -->
    </script>
</head>
<body>
    <form id="TestImageForm" runat="server">
        <input type="hidden" id="HtmlInputHiddenScale" value="100" runat="server" />
        <asp:Image ID="ImageTest" onclick="ResizeImage()" BorderWidth="0" style="cursor:se-resize" runat="server" />
    </form>
</body>
</html>
