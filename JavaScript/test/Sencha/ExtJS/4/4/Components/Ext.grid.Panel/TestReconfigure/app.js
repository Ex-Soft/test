Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomGridPanel", {
	extend: "Ext.grid.Panel",
	alias : "widget.customgridpanel",

	columns: [],

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomGridPanel.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("CustomGridPanel.initComponent(%o)", arguments);

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
