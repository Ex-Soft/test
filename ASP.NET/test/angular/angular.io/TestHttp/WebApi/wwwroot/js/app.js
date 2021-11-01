window.addEventListener("storage", onStorage);

function onStorage(e) {
    if (window.console && console.log) {
        console.log("onStorage(%o)", e);
    }
}

function setItem() {
    if (window.localStorage) {
        window.localStorage.setItem("js", new Date().toString());
    }
}

function getItem() {
    if (window.localStorage) {
        if (window.console && console.log) {
            console.log("js = %s", window.localStorage.getItem("js"));
        }
    }
}

function removeItem() {
    if (window.localStorage) {
        window.localStorage.removeItem("js");
    }
}

function clear() {
    if (window.localStorage) {
        window.localStorage.clear();
    }
}
