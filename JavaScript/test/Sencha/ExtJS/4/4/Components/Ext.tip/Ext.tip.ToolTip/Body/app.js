Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.tip.QuickTipManager"
]);

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.tip.QuickTipManager.init();

	var
		body = Ext.getBody(),
		toolTip = Ext.create("Ext.tip.ToolTip", {
			target: body,
			renderTo: body,
			anchor: "top",
			autoHide: false,
			html: "Ext.tip.ToolTip.html"
		});

	toolTip.show();

	body.dom.onresize = function () {
		if (window.console && console.log)
			console.log("body.dom.onresize(%o)", arguments);

		toolTip.show();
	}
});
