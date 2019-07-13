var
    req = null;

function DoGet()
{
    DoIt("api/values", null);
}

function DoIt(url, params, HttpMethod) {
    if (req = initXMLHTTPRequest()) {
        var
            FileName = document.location.href,
            pos = FileName.lastIndexOf("/");

        if (pos != -1)
            FileName = FileName.substr(0, pos + 1) + url;
        if (!HttpMethod)
            HttpMethod = "GET";
        req.onreadystatechange = onReadyState;
        req.open(HttpMethod, FileName, true);
        req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        req.send(params);
    }
}

function initXMLHTTPRequest() {
    var
        xRequest = null;

    if (window.XMLHttpRequest)
        xRequest = new XMLHttpRequest();
    else if (window.ActiveXObject) {
        try {
            xRequest = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xRequest = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
            }
        }
    }

    return (xRequest);
}

function onReadyState() {
    // toConsole(req.readyState==4 ? req.responseText : "loading... ["+req.readyState+"]");
    if (req.readyState == 4) {
        toConsole(req.responseText);
        toConsole("xRequest.status=" + req.status);
    }
    else
        toConsole("loading... [" + req.readyState + "]");
}

function toConsole(data) {
    if (window.console && console.log)
        console.log(data);
}