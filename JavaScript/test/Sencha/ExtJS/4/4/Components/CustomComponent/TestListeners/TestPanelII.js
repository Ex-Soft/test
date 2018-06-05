Ext.define("TestPanelII", {
	extend: "Ext.panel.Panel",
	alias: "widget.TestPanelII",

	constructor: function(config) {
		if(window.console && console.log)
			console.log("TestPanelII.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("TestPanelII.initComponent(%o)", arguments);

		Ext[this.applyIf ? "applyIf" : "apply"](this, {
			height: 100,
			listeners: {
				beforerender: function(panel, eOpts) {
					if (window.console && console.log)
						console.log("TestPanelII.initComponent(...listeners{...beforerender(%o)...}...)", arguments);
				},
				afterrender: function(panel, eOpts) {
					if (window.console && console.log)
						console.log("TestPanelII.initComponent(...listeners{...afterrender(%o)...}...)", arguments);
				}
			}
		});

		this.callParent(arguments);
	}
});
//@ sourceURL=TestPanelII.js

