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
                alert(e.name + ": " + e.message);
            }
        }
    }

    return (xRequest);
}

function doRequest() {
    var req;

    if (!(req = initXMLHTTPRequest()))
        return;

    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            if (req.status == 200)
                process(req);
            else {
                if (window.console && console.log)
                    console.log("status=" + req.status + "\r\nstatusText=\"" + req.statusText + "\"\r\nresponseText=\"" + req.responseText + "\"");
            }
            req = null;
        }
    };
    req.open("GET", "api/default", true);
    //req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.send();
}
