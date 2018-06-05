Ext.define("TestPanelI", {
	extend: "Ext.panel.Panel",
	alias: "widget.TestPanelI",

	requires: [
		"TestPanelII"
	],

	constructor: function(config) {
		if(window.console && console.log)
			console.log("TestPanelI.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("TestPanelI.initComponent(%o)", arguments);

		Ext.apply(this, {
			height: 200,
			items: [{
				xtype: "TestPanelII",
				listeners: {
					beforerender: function(panel, eOpts) {
						if (window.console && console.log)
							console.log("TestPanelI.initComponent(...items[{...listeners{...beforerender(%o)...}...}]...)", arguments);
					},
					afterrender: function(panel, eOpts) {
						if (window.console && console.log)
							console.log("TestPanelI.initComponent(...items[{...listeners{...afterrender(%o)...}...}]...)", arguments);
					}
				}
			}, {
				xtype: "TestPanelII",
				applyIf: true,
				listeners: {
					beforerender: function(panel, eOpts) {
						if (window.console && console.log)
							console.log("TestPanelI.initComponent(...items[{...listeners{...beforerender(%o)...}...}]...)", arguments);
					},
					afterrender: function(panel, eOpts) {
						if (window.console && console.log)
							console.log("TestPanelI.initComponent(...items[{...listeners{...afterrender(%o)...}...}]...)", arguments);
					}
				}
			}]
		});

		this.callParent(arguments);
	}
});
//@ sourceURL=TestPanelI.js

