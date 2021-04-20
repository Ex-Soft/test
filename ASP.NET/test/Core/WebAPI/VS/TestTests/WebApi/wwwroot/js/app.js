function testClass(btn) {
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
    xhr.open("POST", `api/${btn.dataset.controller}/${btn.value}`, true);
    xhr.setRequestHeader("Content-Type","application/json;utf-8");
    xhr.send("{\"p1\":\"p1 value (from FE)\"}");
}
