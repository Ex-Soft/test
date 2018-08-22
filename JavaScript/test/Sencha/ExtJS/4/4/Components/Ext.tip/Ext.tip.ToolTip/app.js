Ext.onReady(function() {
	var toolTip = Ext.create("Ext.tip.ToolTip", {
		target: Ext.getBody(),
		renderTo: Ext.getBody(),
		anchor: "top",
		autoHide: false,
		html: "Ext.tip.ToolTip.html"
	});

	toolTip.show();
});
