<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestImageForm.aspx.cs" Inherits="AnyTestII.TestImageForm" %>

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

function Download()
{
    var
        Ctrl;

    if(!(Ctrl=document.createElement("IFRAME")))
        return;

    Ctrl.src="TestResizeImageHandler.ashx?scale=100&fromiframe=true";
    Ctrl.style.display="none";
    document.body.appendChild(Ctrl);
}

function CreateImage()
{
    var
        img;

    img=new Image();
    img.src="";
}
// -->
    </script>
</head>
<body>
    <form id="TestImageForm" runat="server">
        <input type="hidden" id="HtmlInputHiddenScale" value="100" runat="server" />
        <input type="button" id="HtmlInputButtonDownload" value="download" onclick="Download()" /><br />
        <input type="button" id="HtmlInputButtonCreateImage" value="create" onclick="CreateImage()" /><br />
        <asp:Image ID="ImageTest" onclick="ResizeImage()" BorderWidth="0" style="cursor: se-resize" runat="server" />
    </form>
</body>
</html>
