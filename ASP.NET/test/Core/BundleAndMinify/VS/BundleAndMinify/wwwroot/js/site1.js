(function (global) {
	if (typeof (BundleAndMinifySite1) === "undefined")
		global.BundleAndMinifySite1 = new (function () {
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
					console.log("BundleAndMinifySite1.onLoad()");
            };
        })();

	global.BundleAndMinifySite1.addEventListener(global, "load", global.BundleAndMinifySite1.onLoad);
})(this);
