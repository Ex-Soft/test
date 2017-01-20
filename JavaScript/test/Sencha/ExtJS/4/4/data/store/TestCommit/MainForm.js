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
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.grid.Panel", {
		layout: "fit",
		store: new Ext.data.Store({
			model: "TestModel",
			data: [
				{ id: 1, name: "Record# 1" },
				{ id: 2, name: "Record# 2" },
				{ id: 3, name: "Record# 3" },
				{ id: 4, name: "Record# 4" },
				{ id: 5, name: "Record# 5" }
			]
		}),
		columns: [
			{ dataIndex: "id", header: "id", width: 100, locked: false },
			{ dataIndex: "name", header: "name", width: 100 /*, locked: false */ }
		],
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "add",
				handler: function(btn, e) {
					var
						grid = btn.up("grid"),
						store = grid.getStore(),
						next = store.getCount() + 1,
						tmpRec = Ext.create(store.getProxy().getModel(), {
							id: next
						});

					tmpRec.set("name", "Record# " + next);
					store.add(tmpRec);
					tmpRec.commit();
				}
			}, {
				text: "getNewRecords",
				handler: function(btn, e) {
					var
						grid = btn.up("grid"),
						store = grid.getStore(),
						newRecords = store.getNewRecords();

					if(newRecords)
						;
				}
			}]
		}],
		renderTo: Ext.getBody()
	});
});