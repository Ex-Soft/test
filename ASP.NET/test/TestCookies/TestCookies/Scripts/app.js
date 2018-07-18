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
    req.withCredentials = true;
    req.open("GET", "api/default", true);
    //req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.send();
}

function process(request) {
    var data = JSON.parse(request.responseText);
    list(data, "cookies");

    var headers = request.getAllResponseHeaders();
    //var headers = request.getResponseHeader("Set-Cookie");
    var arr = headers.trim().split(/[\r\n]+/);

    data = {};
    arr.forEach(function (line) {
        var parts = line.split(': ');
        var header = parts.shift();
        var value = parts.join(': ');
        data[header] = value;
    });

    list(data, "headers");
}

function list(data, id) {
    var
        p,
        key = "",
        pairs = "<tr><th>Name</th><th>Value</th></tr>\n";

    if (!(p = document.getElementById(id)))
        return;

    if (Array.isArray(data)) {
        for (var i = 0, l = data.length; i < l; ++i) {
            pairs += "<tr><td>" + i + "</td>\n<td>" + JSON.stringify(data[i]) + "</td></tr>\n";
        }
    } else {
        for (var item in data) {
            pairs += "<tr><td>" + item + "</td>\n<td>" + data[item] + "</td></tr>\n";
        }
    }

    if (pairs == "<tr><th>Name</th><th>Value</th></tr>\n")
        pairs += "<tr><td><i>empty</i></td>\n<td><i>empty</i></td></tr>\n";
    p.innerHTML = pairs;
}
