Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomSelectField",{
	extend: "Ext.Container",
	xtype: "customselectfield",
	alias: "widget.customselectfield",

	config: {
		layout: "hbox",
		items: [{
			xtype: "textfield",
		}, {
			xtype: "button"
		}]
	},

	constructor: function(config) {
		if(window.console && console.log)
			console.log("constructor(%o)", arguments);

		this.callParent(arguments);

		return this;
	},

	initConfig: function(config) {
		if(window.console && console.log)
			console.log("initConfig(%o)", arguments);

		this.callParent(arguments);

		return this;
	},

	initialize: function() {
		if(window.console && console.log)
			console.log("initialize(%o)", arguments);

		this.callParent(arguments);

		return this;
	}
});

Ext.application({
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.Panel", {
			fullscreen: true,
			items: [{
				xtype: "customselectfield"
			}]
		}));
	}
});