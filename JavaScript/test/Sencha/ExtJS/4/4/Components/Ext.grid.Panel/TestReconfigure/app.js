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
	}
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("CustomGridPanel", {
		renderTo: Ext.getBody(),
		title: "Grid",
		store: {
			autoLoad: true,
			proxy: {
				type: "ajax",
				url: "griddata.json",
				reader: {
					type: "json",
					root: "rows"
				}
			}
		}
	});
});
