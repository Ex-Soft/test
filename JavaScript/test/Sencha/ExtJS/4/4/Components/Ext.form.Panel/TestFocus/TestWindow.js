Ext.define("TestWindow", {
	extend: "Ext.window.Window",
	alias: "widget.testwindow",

	requires: ["TestForm"],

	initComponent: function() {
		this.border = 0;
		this.layout = "fit";

		this.items = [{
			xtype: "testform"
		}];

		this.callParent(arguments);
	},

	render: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestWindow.render(%o)", arguments);

		this.callParent(arguments);
	},

	afterRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestWindow.afterRender(%o)", arguments);

		this.callParent(arguments);
	}
});