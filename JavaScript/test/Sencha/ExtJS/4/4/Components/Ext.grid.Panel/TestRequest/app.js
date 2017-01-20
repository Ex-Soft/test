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
		extraParamField = Ext.create("Ext.form.field.Text", {
			value: "extraParamValue"
		}),
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			proxy: {
				type: "ajax",
				url: "handler.ashx"
			},
			listeners: {
				beforesync: function(options, eOpts) {
					this.getProxy().extraParams = {
						extraParamValue: extraParamField.getValue()
					};
				}
			},
			data: [
				{ id: 1, name: "Record# 1" },
				{ id: 2, name: "Record# 2" },
				{ id: 3, name: "Record# 3" },
				{ id: 4, name: "Record# 4" }
			]
		}),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			columns: [
				{ dataIndex: "id", header: "id", editor: { xtype: "numberfield" }, flex: 1 },
				{ dataIndex: "name", header: "name", editor: { xtype: "textfield" }, flex: 1 }
			],
			plugins: [
				Ext.create("Ext.grid.plugin.CellEditing", {
					clicksToEdit: 2
				})
			],
			tbar: [{
				text: "Add",
				handler: function(btn, e) {
					store.add(Ext.create(store.getProxy().getModel(), { name: "blah-blah-blah" }));
				}
			}, {
				text: "Del",
				handler: function(btn, e) {
					var
						grid,
						sm,
						sel;

					if(!(grid=btn.up("grid"))
						|| !(sm=grid.getSelectionModel())
						|| !(sel=sm.selected)
						|| !sm.hasSelection())
						return;

					store.remove(sel.items);
				}
			}, {
				text: "Save",
				handler: function(btn, t) {
					store.sync();
				}
			},
				extraParamField
			],
			renderTo: Ext.getBody()
		});
});