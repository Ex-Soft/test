Ext.onReady(function() {
	Ext.QuickTips.init();
	
	var 
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
	    		{ name: "IsChecked", type: "boolean" },
	    		{ name: "newRecordId", type: "string" }
	    	],
	    	writer: new Ext.data.JsonWriter(),
	    	autoSave: false,
	    	batch: true,
			listeners: {
				write: function(store, action, result, res,  rs) {
					if(Ext.isGecko && window.console)
						console.info("store.write: arguments.length=%i", arguments.length);
				},
				update: function(store, record, operation) {
					if(Ext.isGecko && window.console)
						console.info("store.update: arguments.length=%i", arguments.length);
				},
				save: function(store, batch, data) {
					if(Ext.isGecko && window.console)
						console.info("store.save: arguments.length=%i", arguments.length);

					//store.filter("IsChecked", "false", true, false);
					//return;

					if(data && data.update)
						Ext.each(data.update, function(r) {
							var
								rtd;

							if(r.IsChecked && (rtd=this.getById(r.Id)))
								this.remove(rtd);
						}, this);

					var
						r;

					if(r=store.getModifiedRecords())
						;

					//store.load();
				}
			}
	    }),
	    rec = Ext.data.Record.create([
			{ name: "Id", type: "int" },
			{ name: "Name", type: "string" },
			{ name: "Salary", type: "float" },
    		{ name: "BirthDate", type: "date" },
    		{ name: "IsChecked", type: "boolean" },
    		{ name: "newRecordId", type: "string" }
		]),
	    checkColumn = new Ext.grid.CheckColumn({
			header: "IsChecked",
			dataIndex: "IsChecked",
			width: 50
		}),
		NameEdit = new Ext.form.TextField(),
        SalaryEdit = new Ext.form.NumberField(),
        BirthDateEdit = new Ext.form.DateField({ format: "d/m/Y" }),
		grid = new Ext.grid.EditorGridPanel({
        	id: "TestGrid",
        	title: "TestGrid",
        	clickstoEdit: 1,
        	selModel: new Ext.grid.RowSelectionModel(),
        	store: store,
        	plugins: checkColumn,
        	columns: [
        		new Ext.grid.RowNumberer(),
				{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" },
				checkColumn
			],
        	autoExpandColumn: "ColName",
        	width: 600,
        	height: 600,
        	tbar: {
        		items: [{
        			text: "Фильтр",
        			iconCls: "btn-filter",
        			enableToggle: true,
        			pressed: false,
        			handler: function(btn)
        			{
        				if(btn.pressed)
        					//store.filter("Name", "Хрущев", true, false);
        					store.filter("IsChecked", "false", true, false);
        				else
        					store.clearFilter();
        			}
        		}, {
        			text: "Add Record",
        			iconCls: "btn-add",
        			handler: function()
        			{
        				store.insert(0, new rec({
        					newRecordId: Ext.id(),
        					Name: "Иванов Иван Иванович",
        					Salary: 0,
        					BirthDate: new Date(1913,11,31),
        					IsChecked: false
        				}));
        			}
        		}, {
        			text: "Delete Record",
        			iconCls: "btn-delete",
        			handler: function()
        			{
						var
							sm = grid.getSelectionModel(),
							sel = sm.getSelected();

						if (sm.hasSelection())
						{
							Ext.Msg.show({
								title: "Remove record",
								buttons: Ext.MessageBox.YESNOCANCEL,
								msg: "Remove "+sel.data.Name+"?",
								fn: function(btn){
									if (btn == "yes"){
										grid.getStore().remove(sel);
									}
								}
							});
						}
        			}
        		}, {
        			text: "Save Changes",
					iconCls: "btn-save",
					handler: function()
					{
						store.save();
					}
				}]
        	}
        }),
        viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				region: "center",
				xtype: "panel",
				items: grid
			}]
		});

	store.load();
	//store.filter("IsChecked", "false", true, false); // Doesn't work
	//store.filter("Name", "Хрущев", true, false); // Doesn't work
});
