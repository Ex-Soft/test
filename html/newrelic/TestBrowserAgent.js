function loadByAjax() {
    const req = new XMLHttpRequest();
    req.addEventListener("load", reqOnLoad);
    req.open("GET", "http://localhost/JavaScript/test/AJAX/data.txt", true);
    req.send();
}

function reqOnLoad(progressEvent) {
    if (window.console && console.log) {
        console.log(progressEvent);

        if (progressEvent.currentTarget.readyState === 4 /* DONE */ && progressEvent.currentTarget.statusText === "OK") {
            console.log(progressEvent.currentTarget.responseText);
        }
    }
}

function loadByFetch() {
    fetch("http://localhost/JavaScript/test/AJAX/data.txt")
        .then(response => response.text())
        .then(body => {
            if (window.console && console.log) {
                console.log(body);
            }
        });
}
