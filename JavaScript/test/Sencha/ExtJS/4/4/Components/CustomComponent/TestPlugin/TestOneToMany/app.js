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

		cmp.getStore().on({
			load: { fn: me.onStoreLoad, scope: me }
		});

		cmp.on({
			select: { fn: me.onGridSelect, scope: me }
		})
	},

	onStoreLoad: function (store, records, successful, eOpts) {
		if(window.console && console.log)
			console.log("SimplePlugin.onStoreLoad(%o) cmp.title: \"%s\" url: \"%s\" this %s= fn.scope", arguments, this.getCmp().title, store.getProxy().url, this === eOpts.scope ? "=" : "!");
	},

	onGridSelect: function (selectionRowModel, record, index, eOpts) {
		if(window.console && console.log)
			console.log("SimplePlugin.onGridSelect(%o) cmp.title: \"%s\" id: ", arguments, this.getCmp().title, record.getId());
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
			console.log("SimplePlugin {p1:\"%s\",p2:\"%s\",p3:\"%s\"} cmp.title: \"%s\"", this.p1, this.p2, this.p3, this.getCmp().title);
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

Ext.define("CustomGridPanel", {
	extend: "Ext.grid.Panel",
	alias : "widget.customgridpanel",

	columns: [],

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
	}],

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomGridPanel.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("CustomGridPanel.initComponent(%o)", arguments);

		Ext.apply(this, {
			plugins: [{
				ptype: "simpleplugin",
				p1: "p1fromConfig",
				p2: "p2fromConfig"
			}]
		});

		this.callParent();

		this.getStore().on({
			metachange: { fn: function (store, meta) {
				this.reconfigure(store, meta.columns);
			}, scope: this }
		});
	},

	listeners: {
		render: function(panel, eOpts) {
			if(window.console && console.log)
				console.log("CustomGridPanel.render(%o)", arguments);
		}
	}
});

Ext.onReady(function() {
	//if(window.console && console.clear)
	//	console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = new Ext.data.Store({
			autoLoad: true,
			proxy: {
				type: "ajax",
				url: "griddata.json",
				reader: {
					type: "json",
					root: "rows"
				}
			}
		});

	Ext.create("Ext.Panel", {
		renderTo: Ext.getBody(),
		layout: {
			type: "table",
			column: 2
		},
		defaults: {frame:true, width:400, height: 400},
		items: [{
			xtype: "customgridpanel",
			title: "Grid# 1",
			store: {
				autoLoad: true,
				proxy: {
					type: "ajax",
					url: "grid1data.json",
					reader: {
						type: "json",
						root: "rows"
					}
				}
			}
		}, {
			xtype: "customgridpanel",
			title: "Grid# 2",
			store: {
				autoLoad: true,
				proxy: {
					type: "ajax",
					url: "grid2data.json",
					reader: {
						type: "json",
						root: "rows"
					}
				}
			}
		}, {
			xtype: "customgridpanel",
			title: "Grid# 3.1",
			store: store
		}, {
			xtype: "customgridpanel",
			title: "Grid# 3.2",
			store: store
		}]
	});
});
