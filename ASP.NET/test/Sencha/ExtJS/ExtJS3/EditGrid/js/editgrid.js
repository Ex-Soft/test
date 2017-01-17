Ext.BLANK_IMAGE_URL = "../resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		store2 = new Ext.data.JsonStore({
			url: "DataSource.aspx",
			root: "rows",
			idProperty: "Id",
			successProperty: "success",
			totalProperty: "count",
			fields: [
				{ name: "Id", type: "int" },
				"Name",
				{ name: "Salary", type: "float" },
				{ name: "BirthDate", type: "date", dateFormat: "c" },
				{ name: "Checked", type: "boolean" },
				"Country",
				{ name: "CountryII", type: "int" }
			],
			writer: new Ext.data.JsonWriter(),
			autoSave: false,
			batch: true,
			listeners: {
				save: function(store, batch, data) {
					if(store)
						;
				},
				update: function(store, record, operation) {
					var
						tmp=record.get("Country");
				},
				write: function(store, action, result, res, rs) {
					if(store)
						;
				}
			}
		}),
		store2Options = new Ext.data.XmlStore({
			url: "Country.xml",
			record: "row",
			idPath: "Id",
			fields: [
				{ name: "Id", type: "int" },
				"Value"
			]
		}),
		NameEdit2 = new Ext.form.TextField(),
		SalaryEdit2 = new Ext.form.NumberField({
			allowBlank: false
		}),
		BirthDateEdit2 = new Ext.form.DateField({
			format: "d/m/Y"
		}),
		checkColumn2 = new Ext.grid.CheckColumn({
			header: "Checked",
			dataIndex: "Checked",
			width: 50
		}),
		ComboBox2Country = new Ext.form.ComboBox({
			store: store2Options,
			valueField: "Id",
			displayField: "Value",
			emptyText: "Select...",
			loadingText: "Loading...",
			allowBlank: true,
			triggerAction: "all",
			editable: false,
			mode: "local",
			forceSelection: true,
			selectOnFocus: true
		}),
		OptionsShower = function(value, metadata, record, rowIndex, colIndex, store)
		{
			return store2Options.getById(value).get("Value");
		},
		colModel2 = new Ext.grid.ColumnModel({
            columns: [
            	{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", editor: NameEdit2, width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", editor: SalaryEdit2, width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit2, width: 100, sortable: true, align: "center" },
				{ dataIndex: "Country", header: "Country", width: 100, sortable: false, align: "center", editor: ComboBox2Country },
				{ dataIndex: "CountryII", header: "CountryII", width: 100, sortable: false, align: "center", renderer: OptionsShower, editor: ComboBox2Country },
				checkColumn2
			]
        }),
		grid2 = new Ext.grid.EditorGridPanel({
			title: "Grid# 2",
			store: store2,
			clicksToEdit: 1,
			colModel: colModel2,
			autoExpandColumn: "ColName",
			plugins: checkColumn2,
			loadMask: true,
			buttons: [{
				text: "Save Changes",
				handler: function() {
					store2.save();
				}
			}],
			listeners: {
				afteredit: function(e) {
					if(e)
						;
					//e.record.commit();
				}
			}
		}),
		store = new Ext.data.JsonStore({
			url: "DataSource.aspx",
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
				load: function(s, r, o) { OnLoad(grid, checkColumn, store, cm) }
			}
		}),
		combo = new Ext.form.ComboBox({
			id: "perpage",
			name: 'perpage',
			width: 40,
			store: new Ext.data.ArrayStore({
				fields: ['id'],
				data: [
					['2'],
					['4'],
					['6']
				]
			}),
			mode: 'local',
			value: '2',
			listWidth: 40,
			triggerAction: 'all',
			displayField: 'id',
			valueField: 'id',
			editable: false,
			forceSelection: true
		}),
		bbar = new Ext.PagingToolbar({
			pageSize: 2,
			store: store,
			displayInfo: true,
			items: [
				"-",
				"Per page: ",
				combo
			],
			displayMsg: 'Displaying items {0} - {1} of {2}',
			emptyMsg: "No items found"
		}),
		NameEdit = new Ext.form.TextField(),
		SalaryEdit = new Ext.form.NumberField(),
		BirthDateEdit = new Ext.form.DateField({
			format: "d/m/Y"
		}),
		checkColumn = new Ext.grid.CheckColumn({
			header: "Checked",
			dataIndex: "Checked",
			width: 50
		}),
		cm = new Ext.grid.ColumnModel({
			columns: [
				{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" },
				checkColumn
				//{ dataIndex: "Checked", header: "Checked", xtype: "booleancolumn", width: 50, sortable: true, align: "center" }
			]
		}),
		grid = new Ext.grid.EditorGridPanel({
			title: "Grid# 1",
			clicksToEdit: 1,
			store: store,
			columns: [], // without it error "cm is undefined"
			width: 600,
			height: 200,
			tbar: {
				items: [
					{ text: 'Save Changes',
						handler: function() {
							store.save();
						}
					}
				]
			},
			bbar: bbar
		}),
		tp = new Ext.TabPanel({
			activeTab: 0,
			items: [ grid, grid2 ]
		}),
		viewport = new Ext.Viewport({
			layout: "fit",
			items: [ tp ]
		});

	combo.on('select', function(combo, record) {
		bbar.pageSize = parseInt(record.get('id'), 10);
		bbar.doLoad(bbar.cursor);
	}, this);
	
	store.load({ params: { start: 0, limit: parseInt(Ext.getCmp("perpage").getValue(), 10) } });
	grid2.getStore().load();
	store2Options.load();
});

function OnLoad(grid, checkColumn, store, cm) {
	grid.plugins=grid.initPlugin(checkColumn);
	
	var
		view=grid.getView();
	
	view.mainBody.on("mousedown",checkColumn.onMouseDown,checkColumn);

	grid.reconfigure(store, cm);
}