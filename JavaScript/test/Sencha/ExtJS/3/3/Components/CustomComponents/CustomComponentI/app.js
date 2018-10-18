Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("App");

App.CustomPanel = Ext.extend(Ext.Panel, {
	constructor: function (config) {
		if (window.console && console.log)
			console.log("CustomPanel.constructor(%o)", arguments);

		config = config || {};
		config.listeners = config.listeners || {};

		Ext.applyIf(config.listeners, {
			beforerender: function () {
				if (window.console && console.log)
					console.log("CustomPanel.beforerender(%o)", arguments);
			}
		});

		App.CustomPanel.superclass.constructor.call(this, config);

		this.addListener("titlechange", function (panel, title) {
			if (window.console && console.log)
					console.log("CustomPanel.titlechange(%o)", arguments);
		}, this);

		return this;
	},

	initComponent: function () {
		if (window.console && console.log)
			console.log("CustomPanel.initComponent(%o)", arguments);

		var
			bbar = new Ext.Toolbar({
				items: [{
					text: "Button# 1",
					handler: function (btn, e) {
						if (window.console && console.log)
							console.log("Button1.handler(%o)", arguments);

						var panel;

						if (!(panel = btn.ownerCt ? btn.ownerCt.ownerCt : null))
							return;

						panel.setTitle("title");
					}
				}]
			});

		Ext.apply(this, {
			bbar: bbar
		});

		App.CustomPanel.superclass.initComponent.apply(this, arguments);

		this.addListener("afterrender", function () {
			if (window.console && console.log)
					console.log("CustomPanel.afterrender(%o)", arguments);
			},
		this);
	},

	initEvents: function () {
		if (window.console && console.log)
			console.log("CustomPanel.initEvents(%o)", arguments);

		App.CustomPanel.superclass.initEvents.apply(this, arguments);
	},

	onRender: function (ct, position) {
		if (window.console && console.log)
			console.log("CustomPanel.onRender(%o)", arguments);

		App.CustomPanel.superclass.onRender.call(this, ct, position);
	}
});

Ext.reg("custompanel", App.CustomPanel);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		p = new App.CustomPanel({
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
