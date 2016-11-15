<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadFileByAJAXMainForm.aspx.cs" Inherits="AnyTestII.TestUploadFileByAJAXMainForm" %>

<!-- http://www.codeproject.com/KB/scripting/AJAX_Like_File_Uploading.aspx -->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Test Upload File by AJAX (Main Form)</title>
        <script type="text/javascript">
<!--
function uploadFile()
{
    var
        theForm,
        theFile;

    if(!(theForm=document.getElementById("myForm")))
        return;

    if((theFile=document.getElementById("myFile1"))
        && theFile.value!="")
        theForm.appendChild(theFile);
    if((theFile=document.getElementById("myFile2"))
        && theFile.value!="")
        theForm.appendChild(theFile);
    if((theFile=document.getElementById("myFile3"))
        && theFile.value!="")
        theForm.appendChild(theFile);

    theForm.submit();
}
// -->
        </script>
    </head>
    <body>
        <form id="myForm" name="myForm" action="TestUploadFileByAJAXUploadForm.aspx" method="post" enctype="multipart/form-data" target="myIFrame">
        </form>

        <form id="TestUploadFileByAJAXMainForm" runat="server">
            File# 1: <input type="file" id="myFile1" name="myFile1" /><br />
            File# 2: <input type="file" id="myFile2" name="myFile2" /><br />
            File# 3: <input type="file" id="myFile3" name="myFile3" /><br />
            <input type="button" value="Upload" onclick="uploadFile()" />
        </form>
        <iframe id="myIFrame" name="myIFrame" style="display: none; "></iframe>
    </body>
</html>
