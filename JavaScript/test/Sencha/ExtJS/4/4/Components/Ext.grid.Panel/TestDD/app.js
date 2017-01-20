Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
	]
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		storeSrc = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel",
			data: [
				[ 1, "Record# 1" ],
				[ 2, "Record# 2" ],
				[ 3, "Record# 3" ],
				[ 4, "Record# 4" ]
			]
		}),
		storeDest = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel"
		}),
		columns = [
			{ dataIndex: "id", text: "id" },
			{ dataIndex: "name", text: "name" },
		],
		gridSrc = Ext.create("Ext.grid.Panel", {
			title: "Source",
			store: storeSrc,
			columns: columns,
			viewConfig: {
				plugins: {
					ptype: "gridviewdragdrop",
					dragGroup: "GridSrc",
					dropGroup: "GridDest"
				},
				listeners: {
					beforedrop: function(node, data, overModel, dropPosition, dropHandlers, eOpts) {
						if(window.console && console.log)
							console.log("view.beforedrop(%o) (src)", arguments);
					},
					drop: function() {
						if(window.console && console.log)
							console.log("view.drop(%o) (src)", arguments);
					}
				}
			},
			flex: 1
		}),
		gridDest = Ext.create("Ext.grid.Panel", {
			title: "Destination",
			store: storeDest,
			columns: columns,
			viewConfig: {
				plugins: {
					ptype: "gridviewdragdrop",
					dragGroup: "GridDest",
					dropGroup: "GridSrc"
				},
				listeners: {
					beforedrop: function(node, data, overModel, dropPosition, dropHandlers, eOpts) {
						if(window.console && console.log)
							console.log("view.beforedrop(%o) (dest)", arguments);
					},
					drop: function() {
						if(window.console && console.log)
							console.log("view.drop(%o) (dest)", arguments);
					}
				}
			},
			flex: 1
		});

	Ext.create("Ext.panel.Panel", {
		layout: {
			type: "hbox",
			align: "stretch"
		},
		items: [
			gridSrc,
			gridDest
		],
		renderTo: Ext.getBody()
	});
});
