﻿function redirectToAction() {
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
    xhr.open("POST", "/home/action1", true);
    xhr.send();
}
