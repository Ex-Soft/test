(function (global) {
    if (typeof WebApp === "undefined")
        global.WebApp = new (function () {
            let me = this;

            me.addEventListener = function (element, eventName, handler) {
                if (element.addEventListener)
                    element.addEventListener(eventName, handler, false);
                else if (element.attachEvent)
                    element.attachEvent("on" + eventName, handler);
                else
                    element.onload = handler;
            };

            me.onLoad = function (e) {
                let btns;
                if (btns = document.getElementById("btnAdd"))
                    me.addEventListener(btns, "click", me.onAddClick);

                if (btns = document.getElementById("btnGetIP"))
                    me.addEventListener(btns, "click", me.onGetIPClick);

                if (btns = document.querySelectorAll("input[data-url]")) {
                    for (let btn of btns) {
                        me.addEventListener(btn, "click", me.onDelClick);
                    }
                }
            };

            me.onAddClick = function (e) {
                let form;
                if (!(form = document.getElementById("formAdd")))
                    return;

                let xhr = new XMLHttpRequest();

                xhr.onreadystatechange = function () {
                    if (xhr.readyState === XMLHttpRequest.DONE) {
                        if (xhr.status === 201) {
                            location.reload();
                        } else {
                            if (window.console && console.log)
                                console.log(xhr);
                        }

                        xhr = null;
                    }
                };
                xhr.open("POST", form.action, true);
                xhr.send(new FormData(form));
            };

            me.onDelClick = function (e) {
                let btn, url, id;

                if (!e
                    || !(btn = e.target)
                    || !btn.dataset
                    || !(url = btn.dataset.url)
                    || !url.length
                    || !(id = btn.dataset.id)
                    || !id.length)
                    return;

                let xhr = new XMLHttpRequest();

                xhr.onreadystatechange = function () {
                    if (xhr.readyState === XMLHttpRequest.DONE) {
                        if (xhr.status === 200) {
                            location.reload();
                        } else {
                            if (window.console && console.log)
                                console.log(xhr);
                        }

                        xhr = null;
                    }
                };
                xhr.open("DELETE", `${url}${(url.charAt(url.length - 1) !== "/" ? "/" : "")}${id}`, true);
                xhr.send();
            };

            me.onGetIPClick = function (e) {
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
                xhr.open("GET", "/staff/getip", true);
                xhr.send();
            };
        })();

    global.WebApp.addEventListener(global, "load", global.WebApp.onLoad);
})(this);