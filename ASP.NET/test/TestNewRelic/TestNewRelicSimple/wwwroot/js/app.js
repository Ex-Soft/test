function onGet(statusCode) {
    const url = `http://localhost:5292/api/home${statusCode ? `?statusCode=${statusCode}` : ""}`;
    fetch(url)
        .then(request => {
            if (window.console && console.log) {
                console.log(request);
            }
            return request.json();
        })
        .then(data => {
            if (window.console && console.log) {
                console.log(data);
            }
        })
        .catch(error => {
            if (window.console && console.log) {
                console.log(error);
            }
        });
}