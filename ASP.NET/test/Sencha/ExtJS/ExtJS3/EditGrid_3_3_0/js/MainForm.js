Ext.ns("App.Components");

Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function () {
	Ext.QuickTips.init();

	var 
		grid3 = new BaseGrid({
			title: "Grid #3",
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
				batch: true
			}),
			autoExpandColumn: "ColName",
			listeners: {
				render: function (grid) {
					if (Ext.isGecko && ("console" in window))
						console.info("Grid3.render");
				}
			}
		}),
		grid4 = new App.Components.EditorGridPanelWithPaging({
			title: "Grid #4",
			cookieName: ApplicationSettings.CookieName,
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
				batch: true
			}),
			autoExpandColumn: "ColName",
			listeners: {
				render: function (grid) {
					if (Ext.isGecko && ("console" in window))
						console.info("Grid4.render");

					grid.getBottomToolbar().doLoad(0);
				}
			}
		}),
		checkboxSel = new Ext.grid.CheckboxSelectionModel({
			checkOnly: true
		}),
		CheckBoxSilent = new Ext.form.Checkbox({
		}),
		CheckBoxRejectChanges = new Ext.form.Checkbox({
		}),
		CheckBoxRemoved = new Ext.form.Checkbox({
		}),
		grid5 = new Ext.grid.GridPanel({
			title: "Grid #5",
			colModel: new Ext.grid.ColumnModel({
				columns: [
					checkboxSel,
					{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
					{ id: "ColName", dataIndex: "Name", header: "Name", width: 180, sortable: true }
				]
			}),
			sm: checkboxSel,
			store: new Ext.data.JsonStore({
				url: "DataSource1.aspx",
				root: "rows",
				idProperty: "Id",
				successProperty: "success",
				totalProperty: "count",
				fields: [
					{ name: "Id", type: "int" },
					"Name"
				],
				writer: new Ext.data.JsonWriter(),
				autoSave: false,
				batch: true
			}),
			autoExpandColumn: "ColName",
			tbar: new Ext.Toolbar({
				items: [
					" ",
				{
					xtype: "button",
					text: "selectRecords()",
					handler: function () {
						var 
							rs = [],
							store = grid5.getStore();

						store.each(function (r) {
							rs.push(r);
						});

						grid5.getSelectionModel().selectRecords(rs, true);
					}
				},
					" silent ",
					CheckBoxSilent,
					" rejectChanges() ",
					CheckBoxRejectChanges,
					" removed = [] ",
					CheckBoxRemoved,
					" ",
				{
					text: "removeAll()",
					handler: function () {
						var 
							store = grid5.getStore();

						store.removeAll(CheckBoxSilent.getValue());

						if (CheckBoxRejectChanges.getValue())
							store.rejectChanges();

						if (CheckBoxRemoved.getValue())
							store.removed = [];
					}
				},
					" ",
				{
					text: "save()",
					handler: function () {
						grid5.getStore().save();
					}
				}]
			}),
			listeners: {
				render: function (grid) {
					grid.getStore().load();
				}
			}
		}),
		tp = new Ext.TabPanel({
			activeTab: 0,
			items: [
				new Grid1(),
				new Grid2(),
				grid3,
				grid4,
				grid5
			]
		}),
		viewport = new Ext.Viewport({
			layout: "fit",
			items: [tp]
		});
});
