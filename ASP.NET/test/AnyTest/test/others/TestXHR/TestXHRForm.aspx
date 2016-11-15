<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestXHRForm.aspx.cs" Inherits="AnyTest.TestXHRForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test XHR</title>
    <script type="text/javascript" charset="utf-8" src="../../../ajax.js"></script>
    <script type="text/javascript">
function DoIt() {
    var
        req,
        ctrlStatusCode,
        divStatus,
        divResult,
        divError,
        username = "login",
        password = "1";

    if (!(req = initXMLHTTPRequest())
        || !(ctrlStatusCode = document.getElementById("statusCode"))
        || !(divStatus = document.getElementById("DivStatus"))
        || !(divResult = document.getElementById("DivResult"))
        || !(divError = document.getElementById("DivError")))
        return;

    divStatus.innerHTML = "";
    divResult.innerHTML = "";
    divError.innerHTML = "";
    
    req.onreadystatechange = function () {
        divStatus.innerHTML += req.readyState + ":" + req.status + " ";
        
        if (req.readyState == 4) {
            if (req.status == 200)
                divResult.innerHTML = req.responseText;
            else
                divError.innerHTML = "status=" + req.status + "<br/>statusText=\"" + req.statusText + "\"<br/>responseText=\"" + req.responseText + "\"";

            req = null;
        }
    };

    req.open("POST", "TestXHR.aspx", true, username, password); // username && password sent as http://login:1@localhost/test/others/TestXHR/TestXHR.aspx
    req.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
    req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.setRequestHeader("Accept-Charset", "UTF-8");
    req.send("utf8=" + encodeURIComponent(document.getElementById("radio8").checked) + "&statuscode=" + ctrlStatusCode.value);
}
    </script>
</head>
<body>
    <form id="TestXHRForm" runat="server">
        utf-8&nbsp;<input type="radio" id="radio8" name="encoding" value="utf8" checked="checked" />
        windows-1251&nbsp;<input type="radio" id="radio1251" name="encoding" value="win1251" />
        status&nbsp;<input type="text" id="statusCode" />
        <input type="button" value="DoIt!" onclick="DoIt()" />
    </form>
    <div id="DivStatus"></div>
    <div id="DivResult"></div>
    <div id="DivError"></div>
</body>
</html>
