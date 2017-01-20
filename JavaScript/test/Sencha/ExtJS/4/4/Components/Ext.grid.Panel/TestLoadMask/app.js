Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);


	var
		grid = Ext.create("Ext.grid.Panel", {
			store: Ext.create("Ext.data.Store", {
				fields: [
					{ name: "id", type: "int" },
					"name"
				],
				autoLoad: false,
				proxy: {
					type: "ajax",
					url: "data.json",
					reader: {
						type: "array",
						root: "data",
						listeners: {
							exception: function(reader, response, error, eOpts) {
								if(window.console && console.log)
									console.log("Ext.data.reader.Array.exception(%o)", arguments);
							}
						}
					},
					listeners: {
						exception: function(proxy, response, operation, eOpts) {
							if(window.console && console.log)
								console.log("Ext.data.proxy.Ajax.exception(%o)", arguments);
						}
					}
				},
				listeners: {
					load: function(store, records, successful, eOpts) {
						if(window.console && console.log)
							console.log("Ext.data.Store.load(%o)", arguments);
					}
				}
			}),
			columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "name", header: "name" }
			],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "load",
					handler: function(btn, e) {
						btn.up("grid").getStore().load();
					}
				}]
			}]
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		layout: "fit",
		height: 200,
		width: 300,
		items: [grid]
	});
});