(function (global) {
	if (typeof (BundleAndMinifySite2) === "undefined")
		global.BundleAndMinifySite2 = new (function () {
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
                if (window.console && console.log)
					console.log("BundleAndMinifySite2.onLoad()");
            };
        })();

	global.BundleAndMinifySite2.addEventListener(global, "load", global.BundleAndMinifySite2.onLoad);
})(this);
