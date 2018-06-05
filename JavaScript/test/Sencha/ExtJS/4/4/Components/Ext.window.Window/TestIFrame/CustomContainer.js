Ext.define("CustomContainer", {
	extend: "Ext.Container",
	alias: "widget.CustomContainer",

	requires: [
		"CustomIFrame"
	],

	initComponent: function() {
		Ext.apply(this, {
			items: [{
				xtype: "CustomIFrame"
				//, url: "iframe.html"
			}]
		});

		this.callParent(arguments);
	}
});

