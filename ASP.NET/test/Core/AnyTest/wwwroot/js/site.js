(function (global) {
	if (typeof (AnyTest) === "undefined")
		global.AnyTest = new (function () {
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
				let divs;
                if (!(divs = document.querySelectorAll("div[data-url]")))
					return;

                for (let div of divs) {
                    me.populate(div);
                }
            };

            me.populate = function(div) {
                if (!div)
                    return;

                let xhr = new XMLHttpRequest();

                xhr.onreadystatechange = function() {
                    if (xhr.readyState === XMLHttpRequest.DONE) {
                        if (xhr.status === 200) {
                            div.innerHTML = xhr.responseText;
                        } else {
                            if (window.console && console.log)
                                console.log(xhr);
                        }

                        xhr = null;
                    }
                };
                xhr.open("GET", div.dataset.url, true);
                xhr.send();
            };
        })();

	global.AnyTest.addEventListener(global, "load", global.AnyTest.onLoad);
})(this);
