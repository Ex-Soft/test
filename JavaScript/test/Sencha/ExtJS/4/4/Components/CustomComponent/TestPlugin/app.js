Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("SimplePlugin", {
	extend: "Ext.AbstractPlugin",
	alias: "plugin.simpleplugin",

    ptype: "simpleplugin",

	constructor: function (config) {
		if(window.console && console.log)
			console.log("SimplePlugin.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	init: function (cmp) {
		if(window.console && console.log)
			console.log("SimplePlugin.init(%o)", arguments);

		var me = this;

		cmp.addEvents({
			"testEvent1": true,
			"testEvent2": true
		});

		cmp.on("testEvent1", me.onTestEvent1, me);
		cmp.on({
			testEvent2: me.onTestEvent1,
			scope: me
		});
	},

	destroy: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.destroy(%o)", arguments);
	},

	onTestEvent1: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.onTestEvent1(%o)", arguments);
	},

	onTestEvent2: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.onTestEvent2(%o)", arguments);
	}
});

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomPanel.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("CustomPanel.initComponent(%o)", arguments);

		Ext.apply(this, {
			plugins: ["simpleplugin"]
		});

		this.callParent();
	}
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		p = Ext.create("CustomPanel", {
			border: 50,
			renderTo: Ext.getBody(),
			listeners: {
				render: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.render(%o)", arguments);
				}
			}
		});
});
