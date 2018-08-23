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
			//autoHide: false,
			html: "Ext.tip.ToolTip.html",
			listeners: {
				beforeclose: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforeclose(%o)", arguments);
				},
				beforecollapse: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforecollapse(%o)", arguments);
				},
				collapse: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.collapse(%o)", arguments);
				},
				beforedeactivate: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforedeactivate(%o)", arguments);
				},
				deactivate: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.deactivate(%o)", arguments);
				},
				beforedestroy: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforedestroy(%o)", arguments);
				},
				destroy: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.destroy(%o)", arguments);
				},
				beforeexpand: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforeexpand(%o)", arguments);
				},
				expand: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.expand(%o)", arguments);
				},
				beforehide: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforehide(%o)", arguments);
				},
				hide: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.hide(%o)", arguments);
				},
				beforeshow: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.beforeshow(%o)", arguments);
				},
				show: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.show(%o)", arguments);
				},
				bodyresize: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.bodyresize(%o)", arguments);
				},
				resize: function () {
					if (window.console && console.log)
						console.log("Ext.tip.ToolTip.resize(%o)", arguments);
				}
			}
		}),
		viewport = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "center",
				html: "center"
			}]
		});

	toolTip.show();

	viewport.on("resize", function (vp, adjWidth, adjHeight, rawWidth, rawHeight) {
		if (window.console && console.log)
			console.log("Ext.Viewport.resize(%o)", arguments);

		toolTip.hide();
		toolTip.show();
	});
});
