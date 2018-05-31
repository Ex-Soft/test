Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.panel.Panel"
]);

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	config: {
		buttons: [
			{
				text: "Button# 1"
			}
		],
		listeners: {
			beforeadd: function(panel, eOpts) {
				if(window.console && console.log)
					console.log("CustomPanel.beforeadd(%o)", arguments);
			}
		}
	},

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomPanel.constructor(%o)", arguments);

		this.initConfig(config);

		if(window.console && console.log)
			console.log("CustomPanel.constructor(): b4 callParent()");

		this.callParent([this.config]);

		if(window.console && console.log)
			console.log("CustomPanel.constructor(): after callParent()");

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
