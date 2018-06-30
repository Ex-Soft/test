Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("SimplePlugin", {
	extend: "Ext.AbstractPlugin",
	alias: "plugin.simpleplugin",

    ptype: "simpleplugin",

	p1: "p1",
	p2: "p2",
	p3: "p3",

	constructor: function (config) {
		if(window.console && console.log)
			console.log("SimplePlugin.constructor(%o)", arguments);

		var me = this;

		me.callParent([config]);

		return me;
	},

	init: function (cmp) {
		if(window.console && console.log)
			console.log("SimplePlugin.init(%o)", arguments);

		var me = this;

		me.setCmp(cmp);

		cmp.addEvents({
			"testEvent1": true,
			"testEvent2": true,
			"testEvent3": true
		});

		cmp.on("testEvent1", me.onTestEvent1, me);
		cmp.on({
			testEvent2: me.onTestEvent2,
			scope: me
		});
		cmp.on({
			testEvent3: me.onTestEvent3,
			single: true,
			scope: me
		});
	},

	destroy: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.destroy(%o)", arguments);

		var
			me = this,
			cmp = me.getCmp();

		cmp.un("testEvent1", me.onTestEvent1, me);
		cmp.un({
			testEvent2: me.onTestEvent2,
			scope: me
		});
		cmp.un({
			testEvent3: me.onTestEvent3,
			single: true,
			scope: me
		});
	},

	onTestEvent1: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.onTestEvent1(%o)", arguments);

		if(window.console && console.log)
			console.log("SimplePlugin {p1:\"%s\",p2:\"%s\",p3:\"%s\"}", this.p1, this.p2, this.p3);
	},

	onTestEvent2: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.onTestEvent2(%o)", arguments);
	},

	onTestEvent3: function () {
		if(window.console && console.log)
			console.log("SimplePlugin.onTestEvent3(%o)", arguments);
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
			//plugins: ["simpleplugin"]
			plugins: [{
				ptype: "simpleplugin",
				p1: "p1fromConfig",
				p2: "p2fromConfig"
			}]
		});

		this.callParent();
	}
});

Ext.onReady(function() {
	//if(window.console && console.clear)
	//	console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		p = Ext.create("CustomPanel", {
			tbar: [{
				xtype: "button",
				text: "testEvent1",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent1");
				}
			}, {
				xtype: "button",
				text: "testEvent2",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent2");
				}
			}, {
				xtype: "button",
				text: "testEvent3",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent3");
				}
			}, {
				xtype: "button",
				text: "destroy",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.destroy();
				}
			}],
			renderTo: Ext.getBody(),
			listeners: {
				render: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.render(%o)", arguments);
				}
			}
		});
});
