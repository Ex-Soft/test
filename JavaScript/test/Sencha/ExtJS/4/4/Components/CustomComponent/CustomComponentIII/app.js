// http://extjsexamples.blogspot.com/2010/03/extjs-life-cycle_955.html
// http://stackoverflow.com/questions/7652170/initcomponent-vs-constructor-when-defining-an-object

Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	customProperty1: "customProperty1",

	buttons: [
		{
			text: "Button# 1 (default)"
		}
	],

	constructor: function(config) {
		config = config || {};

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		this.tbar = {
			items: [
				{
					xtype: "button",
					text: "TBar Button #1 (Add) (default)",
					handler: function(btn, e) {
						this.add({ xtype: "button", text: "AddedButton" });
					},
					scope: this
				},
				{
					xtype: "button",
					text: "customProperty1",
					handler: function(btn, e) {
						this.showProperty(this.customProperty1);
					},
					scope: this
				},
				{
					xtype: "button",
					text: "customProperty2",
					handler: function(btn, e) {
						this.showProperty(this.customProperty2);
					},
					scope: this
				}
			]
		};

		Ext.applyIf(this, {
			fbar: {
				items: [
					{
						xtype: "button",
						text: "FBar Button #1 (Add) (default)",
						handler: function(btn, e) {
							this.add({ xtype: "button", text: "AddedButton" });
						},
						scope: this
					}
				]
			}
		});

		this.addListener("afterrender", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.afterrender(%o)", arguments);
		});

		if(window.console && console.log)
			console.log("CustomPanel.initComponent(%o)", arguments);

		if(window.console && console.log)
			console.log("CustomPanel.initComponent(): b4 callParent()", arguments);

		this.callParent(arguments);

		if(window.console && console.log)
			console.log("CustomPanel.initComponent(): after callParent()", arguments);

		this.addListener("beforerender", function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomPanel.beforerender(%o)", arguments);
		});
	},
	
	showProperty: function(prop) {
		Ext.Msg.alert(Ext.util.Format.format("typeof prop = \"{0}\"<br/>prop = \"{1}\"", typeof prop, typeof prop!=="undefined" ? prop : "undefined"));
	}
});

Ext.onReady(function() {
	var
		p = Ext.create("CustomPanel", {
			customProperty2: "customProperty2",
			border: 50,
			renderTo: Ext.getBody(),
			tbar: {
				items: [
					{
						xtype: "button",
						text: "TBar Button #1 (Add) (config)",
						handler: function(btn, e) {
							this.add({ xtype: "button", text: "AddedButton" });
						},
						scope: this
					}
				]
			},
			fbar: {
				items: [
					{
						xtype: "button",
						text: "FBar Button #1 (Add) (config)",
						handler: function(btn, e) {
							this.add({ xtype: "button", text: "AddedButton" });
						},
						scope: this
					}
				]
			},
			buttons: [
				{
					text: "Button# 1 (config)"
				}
			],
			listeners: {
				render: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.render(%o)", arguments);
				}
			}
		});
});
