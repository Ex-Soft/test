Ext.define("TestWindow", {
	extend: "Ext.window.Window",
	alias: "widget.testwindow",

	requires: ["TestPanel"],

	initComponent: function() {
		Ext.apply(this, {
			height: 300,
			width: 300,
			items: [{
				xtype: "testpanel"
			}]
		});

		this.callParent(arguments);
	}
});