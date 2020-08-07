function testHeader() {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                if (window.console && console.log)
                    console.log(xhr);
            } else {
                if (window.console && console.log)
                    console.log(xhr);
            }

            xhr = null;
        }
    };
    xhr.open("GET", "api/home/testheader", true);
    xhr.setRequestHeader("Code", "CodeValue");
    xhr.setRequestHeader("Env", "EnvValue");
    xhr.setRequestHeader("X-Extra", "X-ExtraValue");
    xhr.send();
}

function testGet(id) {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                if (window.console && console.log)
                    console.log(xhr);
            } else {
                if (window.console && console.log)
                    console.log(xhr);
            }

            xhr = null;
        }
    };
    xhr.open("GET", `api/values${id ? `/${id}` : ""}`, true);
    xhr.send();
}

function testPost() {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                if (window.console && console.log)
                    console.log(xhr);
            } else {
                if (window.console && console.log)
                    console.log(xhr);
            }

            xhr = null;
        }
    };
    xhr.open("POST", "api/values", true);
    xhr.setRequestHeader("Content-Type","application/json;utf-8");
    xhr.send("{\"value\":\"string value\"}");
}

function testPut() {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                if (window.console && console.log)
                    console.log(xhr);
            } else {
                if (window.console && console.log)
                    console.log(xhr);
            }

            xhr = null;
        }
    };
    xhr.open("PUT", "api/values/13", true);
    xhr.setRequestHeader("Content-Type", "application/json;utf-8");
    xhr.send("{\"value\":\"string value\"}");
}

function testDelete() {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                if (window.console && console.log)
                    console.log(xhr);
            } else {
                if (window.console && console.log)
                    console.log(xhr);
            }

            xhr = null;
        }
    };
    xhr.open("DELETE", "api/values/13", true);
    xhr.send();
}
