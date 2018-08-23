Ext.BLANK_IMAGE_URL = "../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		body = Ext.getBody(),
		toolTip = new Ext.ToolTip({
			target: Ext.getBody(),
			renderTo: Ext.getBody(),
			anchor: "top",
			autoHide: false,
			html: "Ext.ToolTip.html"
		});

	body.on("resize", function (w, h) {
		if (window.console && console.log)
			console.log("body.resize(%o)", arguments);
	});

	body.dom.onresize = function (e) {
		if (window.console && console.log)
			console.log("body.dom.onresize(%o)", arguments);
	};

	body.on("onresize", function (w, h) {
		if (window.console && console.log)
			console.log("body.onresize(%o)", arguments);
	});
	
	toolTip.on("bodyresize", function (w, h) {
		if (window.console && console.log)
			console.log("Ext.ToolTip.bodyresize(%o)", arguments);
	});

	toolTip.target.on("resize", function (w, h) {
		if (window.console && console.log)
			console.log("Ext.ToolTip.target.resize(%o)", arguments);
	});

	toolTip.target.on("onresize", function (w, h) {
		if (window.console && console.log)
			console.log("Ext.ToolTip.target.onresize(%o)", arguments);
	});

	toolTip.show();
});
