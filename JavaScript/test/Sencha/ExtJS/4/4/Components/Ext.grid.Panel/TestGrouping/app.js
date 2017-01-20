Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.grid.Panel", {
		store: Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				{ name: "groupId", type: "int" },
				"name",
				{ name: "fint", type: "int" }
			],
			data: [
				{ id: 1, groupId: 1, name: "1.1", fint: 11 },
				{ id: 2, groupId: 1, name: "1.2", fint: 12 },
				{ id: 3, groupId: 1, name: "1.3", fint: 13 },
				{ id: 4, groupId: 2, name: "2.1", fint: 21 },
				{ id: 5, groupId: 2, name: "2.2", fint: 22 },
				{ id: 6, groupId: 2, name: "2.3", fint: 23 },
			],
			groupField: "groupId"
		}),
		columns: [
			{ dataIndex: "groupId", header: "groupId" },
			{ dataIndex: "id", header: "id" },
			{ dataIndex: "name", header: "name" },
			{ dataIndex: "fint", header: "fint", summaryType: "sum" }
		],
		features: [{
			//ftype: "groupingsummary",
			ftype: "grouping",
			groupHeaderTpl: "{columnName}: {name} ({rows.length} Item{[values.rows.length > 1 ? \"s\" : \"\"]})"
			//groupHeaderTpl: "{[readOut(values)]}"
		}],
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "clearGrouping()",
				handler: function(btn, e) {
					var
						grid;

					if(!(grid=btn.up("grid")))
						return;

					grid.getStore().clearGrouping();
				}
			}, {
				text: "group()",
				handler: function(btn, e) {
					var
						grid;

					if(!(grid=btn.up("grid")))
						return;

					grid.getStore().group("groupId");
				}
			}]
		}],
		renderTo: Ext.getBody()
	});
});

function readOut(values) {
	if(window.console && console.log)
		console.log("%o", values)
}