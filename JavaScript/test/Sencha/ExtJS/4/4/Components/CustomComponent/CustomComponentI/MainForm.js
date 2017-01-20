Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomPanel.constructor(%o)", arguments);

		config = config || {};

		Ext.applyIf(config, {
			buttons: [
				{
					text: "Button# 1"
				}
			]
			// !!! Ext.apply_If_ !!!
			/* listeners: {
				beforeadd: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.beforeadd(%o)", arguments);
				}
			}*/
		});

		// !!! this.listeners doesn't exist !!!
		this.listeners = config.listeners;

		// !!! this.events[] doesn't exist !!!
		/*
		this.addListener("beforeadd", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.beforeadd(%o)", arguments);
		});
		*/

		if(window.console && console.log)
			console.log("CustomPanel.constructor(): b4 callParent()");

		this.callParent([config]);

		if(window.console && console.log)
			console.log("CustomPanel.constructor(): after callParent()");

		this.addListener("beforeadd", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.beforeadd(%o)", arguments);
		});

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("CustomPanel.initComponent(%o)", arguments);

		Ext.apply(this, {
			tbar: {
				items: [
					{
						xtype: "button",
						text: "TBar Button #1 (Add)",
						handler: function(btn, e) {
							this.add({ xtype: "button", text: "AddedButton" });
						},
						scope: this
					}
				]
			}
			// !!! Ext._apply_ !!!
			/* listeners: {
				afterrender: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.afterrender(%o)", arguments);
				}
			}*/
		});

		this.addListener("afterrender", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.afterrender(%o)", arguments);
		});

		if(window.console && console.log)
			console.log("CustomPanel.initComponent(): b4 callParent()", arguments);

		this.callParent(arguments);

		if(window.console && console.log)
			console.log("CustomPanel.initComponent(): after callParent()", arguments);

		this.addListener("beforerender", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.beforerender(%o)", arguments);
		});
	}
});

Ext.onReady(function() {
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
