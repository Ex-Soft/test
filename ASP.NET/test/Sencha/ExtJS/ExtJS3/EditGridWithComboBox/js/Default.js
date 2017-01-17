Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

    var 
        store = new Ext.data.Store({
			reader: new Ext.data.XmlReader({
				record: "row",
				idPath: "Id",
				successProperty: "success",
				totalProperty: "total",
				fields: [
					{ name: "Id", type: "int" },
					"Name",
					{ name: "Salary", type: "float" },
					{ name: "BirthDate", type: "date", dateFormat: "c" }
				]
			}),
			proxy: new Ext.data.HttpProxy({
				url: "Staff.xml",
				listeners: {
					exception: function(proxy, type, action, options, response, arg) {
						if(Ext.isGecko && window.console)
							console.info("HttpProxy.listeners.exception: response.status=", response.status, " response.isAbort=", response.isAbort, " response.isTimeout=", response.isTimeout, "response.statusText=\"", response.statusText, "\" response.responseText=\"", response.responseText, "\"");
					}
				}
			}),
			listeners: {
				load: function(s, records, options) {
					if(records.length!=0)
						;
				}
			}
		}),
		storeXml = new Ext.data.XmlStore({
			url: "Staff.xml",
			record: "row",
			idPath: "Id",
			fields: [
				{ name: "Id", type: "int" },
				"Name",
				{ name: "Salary", type: "float" },
				{ name: "BirthDate", type: "date", dateFormat: "c" }
			],
			listeners: {
				load: function(s, records, options) {
					if(records.length!=0)
						;
				}
			}
		}),
		store1 = new Ext.data.XmlStore({
			url: "Grid1.xml",
			record: "row",
			idPath: "Id",
			fields: [
				{ name: "Id", type: "int" },
				"Field1",
				"Field2"
			]
		}),
		store2 = new Ext.data.XmlStore({
			url: "Grid2.xml",
			record: "row",
			idPath: "Id",
			fields: [
				{ name: "Id", type: "int" },
				"Field1",
				{ name: "Field2", type: "int" }
			]
		}),
		store1Options = new Ext.data.XmlStore({
			url: "Grid1Options.xml",
			record: "row",
			idPath: "Id",
			fields: [
				{ name: "Id", type: "int" },
				"Value"
			]
		}),
		ComboBoxField21 = new Ext.form.ComboBox({
			store: store1Options,
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
		ComboBoxField22 = new Ext.form.ComboBox({
			store: store1Options,
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
		colModel1 = new Ext.grid.ColumnModel({
            columns: [
				{ dataIndex: "Field1", header: "Field1", width: 100, sortable: false, align: "left" },
				{ dataIndex: "Field2", header: "Field2", width: 100, sortable: false, align: "center", editor: ComboBoxField21 }
			]
        }),
		OptionsShower = function(value, metadata, record, rowIndex, colIndex, store)
		{
			if(!record.dirty)
				metadata.attr="style=\"border-style: inset; border-width: 2px;\"";
			return store1Options.getById(value).get("Value");
		},
		colModel2 = new Ext.grid.ColumnModel({
            columns: [
				{ dataIndex: "Field1", header: "Field1", width: 100, sortable: false, align: "left" },
				{ dataIndex: "Field2", header: "Field2", width: 100, sortable: false, align: "center", renderer: OptionsShower, editor: ComboBoxField22 }
			]
        }),
		grid1 = new Ext.grid.EditorGridPanel({
			title: "Grid# 1",
			store: store1,
			clicksToEdit: 1,
			colModel: colModel1
		}),
		grid2 = new Ext.grid.EditorGridPanel({
			title: "Grid# 2",
			store: store2,
			clicksToEdit: 1,
			colModel: colModel2
		}),
		tp = new Ext.TabPanel({
			activeTab: 0,
			items: [
				grid1,
				grid2
			]
		}),
		viewport = new Ext.Viewport({
			layout: "fit",
			items: [tp]
		});

	store.load();
	storeXml.load();
	store1.load();
	store1Options.load();
	store2.load();
});