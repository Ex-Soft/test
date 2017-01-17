Grid1 = Ext.extend(BaseGrid, {
	initComponent: function() {

		Ext.apply(this, Ext.apply(this.initialConfig, {
			title: "Grid# 1",
			colModel: new Ext.grid.ColumnModel({
				columns: [
					{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
					{ id: "ColName", dataIndex: "Name", header: "Name", editor: new Ext.form.TextField(), width: 180, sortable: true },
					{ dataIndex: "Salary", header: "Salary", editor: new Ext.form.NumberField(), width: 75, sortable: true, align: "center" },
					{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer(ApplicationSettings.DateFormat), editor: new Ext.form.DateField({ format: ApplicationSettings.DateFormat }), width: 100, sortable: true, align: "center" },
					{ xtype: "checkcolumn", dataIndex: "Checked", header: "Checked", width: 100 }
				]
			}),
			store: new Ext.data.JsonStore({
				url: "DataSource1.aspx",
				root: "rows",
				idProperty: "Id",
				successProperty: "success",
				totalProperty: "count",
				fields: [
					{ name: "Id", type: "int" },
					"Name",
					{ name: "Salary", type: "float" },
					{ name: "BirthDate", type: "date", dateFormat: "c" },
					{ name: "Checked", type: "boolean" }
				],
				writer: new Ext.data.JsonWriter(),
				autoSave: false,
				batch: true,
				listeners: {
					write: function(store, action, result, res,  rs) {
						if(Ext.isGecko && window.console)
							console.info("Grid1.store.write: arguments.length=%i", arguments.length);
					},
					save: function(store, batch, data) {
						if(Ext.isGecko && window.console)
							console.info("Grid1.store.save: arguments.length=%i", arguments.length);
					}
				}
			}),
			autoExpandColumn: "ColName",
			listeners: {
				render: function(grid) {
					if(Ext.isGecko && window.console)
						console.info("Grid1.render");
				}
			}
		}));

		Grid1.superclass.initComponent.apply(this, arguments);
	}
});