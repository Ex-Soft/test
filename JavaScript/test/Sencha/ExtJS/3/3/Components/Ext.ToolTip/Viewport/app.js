Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		viewport = new Ext.Viewport({
			id: "idViewportId",
			layout: "border",
			items: [{
				region: "north",
				height: 50,
				html: "north"
			},{
				region: "center",
				html: "center"
			}, {
				region: "south",
				height: 50,
				html: "south"
			}]
		}),
		toolTip = new Ext.ToolTip({
			target: Ext.getBody(),
			renderTo: Ext.getBody(),
			anchor: "left",
			autoHide: false,
			html: "Ext.ToolTip.html",
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
		vp;

	toolTip.show();

	viewport.on("resize", function (vp, adjWidth, adjHeight, rawWidth, rawHeight) {
		if (window.console && console.log)
			console.log("Ext.Viewport.resize(%o)", arguments);

		toolTip.hide();
		toolTip.show();
	});

	vp = Ext.get("viewport");
	if (window.console && console.log)
		console.log("viewport = %o", vp);
});
