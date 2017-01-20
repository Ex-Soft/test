Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	fields: [
		{ name: "id", type: "int" },
		"one",
		"two",
		"three"
	]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestModel",
			data: {
				items: [
					{ id: 0, one: "0", two: "2", three: "3" },
					{ id: 1, one: "1", two: "2", three: "3" },
					{ id: 2, one: "2", two: "2", three: "3" },
					{ id: 3, one: "3", two: "2", three: "3" },
					{ id: 4, one: "4", two: "2", three: "3" },
					{ id: 5, one: "5", two: "2", three: "3" },
					{ id: 6, one: "6", two: "2", three: "3" },
					{ id: 7, one: "7", two: "2", three: "3" },
					{ id: 8, one: "8", two: "2", three: "3" },
					{ id: 9, one: "9", two: "2", three: "3" },
					{ id: 10, one: "10", two: "2", three: "3" },
					{ id: 11, one: "11", two: "2", three: "3" },
					{ id: 12, one: "12", two: "2", three: "3" },
					{ id: 13, one: "13", two: "2", three: "3" },
					{ id: 14, one: "14", two: "2", three: "3" },
					{ id: 15, one: "15", two: "2", three: "3" },
					{ id: 16, one: "16", two: "2", three: "3" },
					{ id: 17, one: "17", two: "2", three: "3" },
					{ id: 18, one: "18", two: "2", three: "3" },
					{ id: 19, one: "19", two: "2", three: "3" }
				]
			},
			proxy: {
				type: "memory",
				reader: {
					type: "json",
					root: "items"
				}
			},
			autoDestroy: true,
			listeners: {
				load: function(store, records, successful, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.load(%o)", arguments);
				}
			}
		}),
		numberFieldRecNo = Ext.create("Ext.form.field.Number", {
			allowDecimals: false,
			minValue: 0,
			hideTrigger: true,
			value: 18
		}),
		checkBoxWithView = Ext.create("Ext.form.field.Checkbox"),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			autoScroll: true,
			columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "one", header: "one", editor: "textfield" },
				{ dataIndex: "two", header: "two", editor: { xtype: "textfield", allowBlank: false} },
				{ dataIndex: "three", header: "three", editor: "textfield" }
			],
			dockedItems:[{
				xtype: "toolbar",
				dock: "top",
				items: [
					"Record#",
					numberFieldRecNo,
					"with View",
					checkBoxWithView,
				{
					text: "select()",
					handler: function(btn, e) {
						var
							grid = btn.up("grid"),
							recNo = numberFieldRecNo.getValue();

						(checkBoxWithView.getValue() ? grid.getView() : grid.getSelectionModel()).select(recNo);
					}
				}, {
					text: "focusRow()",
					handler: function(btn, e) {
						var
							grid = btn.up("grid"),
							recNo = numberFieldRecNo.getValue();

						grid.getView().focusRow(recNo);
					}
				}, {
					text: "add",
					handler: function(btn, e) {
						var
							grid = btn.up("grid"),
							view = grid.getView(),
							store = grid.getStore(),
							record = Ext.create(store.getProxy().getModel());

						record.set("id", store.getCount());
						record.set("one", store.getCount());
						record.set("two", "2");
						record.set("three", "3");

						//view.onAdd(store, [record], store.getCount());

						store.add(record);

						record.commit();
					}
				}, {
					text: "edit",
					handler: function(btn, e) {
						var
							grid = btn.up("grid"),
							sm = grid.getSelectionModel(),
							view = grid.getView(),
							store = grid.getStore(),
							record;

						if(!sm.hasSelection())
							return;

						record = sm.getSelection()[0];

						record.set("one", record.get("one")+record.get("one"));
						record.set("two", record.get("two")+record.get("two"));
						record.set("three", record.get("three")+record.get("three"));

						//view.onUpdate(store, record);

						record.commit();
					}
				}]
			}],
			listeners: {
				afterrender: function(grid, eOpts) {
					if(window.console && console.log)
						console.log("Ext.grid.Panel.afterrender(%o)", arguments);
				},
				boxready: function(grid, width, height, eOpts) {
					if(window.console && console.log)
						console.log("Ext.grid.Panel.boxready(%o)", arguments);

					if(grid)
						;
				},
				selectionchange: function(selectionModel, selected, eOpts) {
					if(window.console && console.log)
						console.log("Ext.grid.Panel.selectionchange(%o)", arguments);
				},
				beforedestroy: function(grid, eOpts) {
					if(window.console && console.log)
						console.log("Ext.grid.Panel.beforedestroy(%o)", arguments);
				},
				viewready: function(grid, eOpts) {
					if(window.console && console.log)
						console.log("Ext.grid.Panel.viewready(%o)", arguments);

					var
						store = grid.getStore(),
						record = store.getById(0);

					if(store.getCount())
						(checkBoxWithView.getValue() ? grid.getView() : grid.getSelectionModel()).select(0);

					//Ext.Function.interceptAfter(grid.getView(), "onAdd", grid.onAddRecord, grid);
					//Ext.Function.interceptAfter(grid.getView(), "onUpdate", grid.onUpdateRecord, grid);
				}
			},
			onAddRecord: function() {
				if(window.console && console.log)
					console.log("onAddRecord(%o)", arguments);
			},
			onUpdateRecord: function() {
				if(window.console && console.log)
					console.log("onUpdateRecord(%o)", arguments);
			}
		});

	Ext.data.AbstractStore.prototype.destroyStore = Ext.Function.createSequence(Ext.data.AbstractStore.prototype.destroyStore, function() {
		if(window.console && console.log)
			console.log("Ext.data.AbstractStore.prototype.destroyStore(%o)", arguments);
	});

	Ext.create("Ext.window.Window", {
		title: "title",
		layout: "fit",
		autoShow: true,
		height: 350,
		width: 500,
		items: [grid],
		listeners: {
			afterrender: function(grid, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.afterrender(%o)", arguments);
			},
			boxready: function(grid, width, height, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.boxready(%o)", arguments);
			},
			close: function(panel, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.close(%o)", arguments);
				//store.destroyStore();
			},
			show: function(panel, eOpts) {
				if(window.console && console.log)
					console.log("Ext.window.Window.show(%o)", arguments);
			}
		}
	});
});