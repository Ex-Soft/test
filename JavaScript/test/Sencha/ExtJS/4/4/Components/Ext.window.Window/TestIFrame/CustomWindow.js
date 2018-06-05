Ext.define("CustomWindow", {
	extend: "Ext.window.Window",
	alias: "widget.CustomWindow",

	requires: [
		"CustomContainer"
	],

	layout: "fit",

	initComponent: function() {
		Ext.apply(this, {
			items: [{
				//xtype: "CustomContainer"
				xtype: "CustomIFrame"
				//, url: "iframe.html"
			}]
		});

		this.callParent(arguments);
	}
});

