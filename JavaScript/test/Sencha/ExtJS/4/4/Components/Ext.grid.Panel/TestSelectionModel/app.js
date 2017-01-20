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
		store = Ext.create("Ext.data.Store", {
			fields: [ "one", "two",	"three"	],
			data: {
				items: [
					{ one: "1", two: "2", three: "3" },
					{ one: "1", two: "2", three: "3" },
					{ one: "1", two: "2", three: "3" },
					{ one: "1", two: "2", three: "3" },
					{ one: "1", two: "2", three: "3" }
				]
			},
			proxy: {
				type: "memory",
				reader: {
					type: "json",
					root: "items"
				}
			}
		}),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			columns: [
				{ dataIndex: "one", header: "one", editor: "textfield" },
				{ dataIndex: "two", header: "two", editor: { xtype: "textfield", allowBlank: false} },
				{ dataIndex: "three", header: "three", editor: "textfield" }
			],
			selModel: {
				selType: "cellmodel",
				mode: "MULTI"
			},
			plugins: [Ext.create("Ext.grid.plugin.CellEditing", {
				clicksToEdit: 2
			})],
			renderTo: Ext.getBody()
		});
});