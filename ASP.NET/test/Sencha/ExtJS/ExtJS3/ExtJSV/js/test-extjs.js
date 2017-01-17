Ext.onReady(function() {
	Ext.QuickTips.init();

	var 
	    store = new Ext.data.JsonStore({
	    	url: "DataSource.aspx",
	    	root: "rows",
	    	idProperty: "Id",
	    	totalProperty: "count",
	    	fields: [{ name: "Id", type: "int" }, "Name", { name: "Salary", type: "float"}]
	    }),
        NameEdit = new Ext.form.TextField(),
        SalaryEdit = new Ext.form.NumberField(),
        ds_model = Ext.data.Record.create([
			"Id",
			"Name",
			{ name: "Salary", type: "float" }
		]),
        grid = new Ext.grid.EditorGridPanel({
        	id: "TestGrid",
        	title: "TestGrid",
        	clickstoEdit: 1,
        	store: store,
        	columns: [
                { dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
                { id: "NameCol", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true },
                { dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" }
            ],
        	autoExpandColumn: "NameCol",
        	width: 600,
        	height: 200,
        	selModel: new Ext.grid.RowSelectionModel(),
        	tbar: [{
        		text: "Add (First)",
        		icon: "images/table_add.png",
        		cls: "x-btn-text-icon",
        		handler: function() {
        			var
        				conn = new Ext.data.Connection();
        				
        			conn.request({
        				url: "DataSourceUpdate.aspx",
        				params: {
        					action: "insert",
        					Name: "New Name"
        				},
        				success: function(resp, opt) {
        					var
								insert_id = Ext.util.JSON.decode(resp.responseText).Id;
								
        					grid.getStore().insert(0,
								new ds_model({
           							Id: insert_id,
           							Name: "New Name",
           							Salary: 0
								})
							);
        					grid.startEditing(0, 0);
        				},
        				failure: function(resp, opt) {
        					Ext.Msg.alert('Error', 'Unable to add movie');
        				}
        			});
        		}
        	}, {
        		text: "Add (Last)",
        		icon: "images/table_add.png",
        		cls: "x-btn-text-icon",
        		handler: function() {
        			var 
        				conn = new Ext.data.Connection();

        			conn.request({
        				url: "DataSourceUpdate.aspx",
        				params: {
        					action: "insert",
        					Name: "New Name"
        				},
        				success: function(resp, opt) {
        					var 
								insert_id = Ext.util.JSON.decode(resp.responseText).Id;

        					grid.getStore().insert(grid.getStore().getCount(),
								new ds_model({
									Id: insert_id,
									Name: "New Name",
									Salary: 0
								})
							);
							grid.startEditing(grid.getStore().getCount() - 1, 0);
        				},
        				failure: function(resp, opt) {
        					Ext.Msg.alert('Error', 'Unable to add movie');
        				}
        			});
        		}
        	}, {
        		text: "Remove",
        		icon: "images/table_delete.png",
        		cls: "x-btn-text-icon",
        		handler: function() {
        			var
        				sm = grid.getSelectionModel(),
        				sel = sm.getSelected();
        				
        			if (sm.hasSelection()) {
        				Ext.Msg.show({
        					title: "Remove",
        					buttons: Ext.MessageBox.YESNOCANCEL,
        					msg: "Remove " + sel.data.Name + "?",
        					fn: function(btn) {
        						if (btn == "yes") {
        							var
        								conn = new Ext.data.Connection();
        								
        							conn.request({
        							url: "DataSourceUpdate.aspx",
        								params: {
        									action: "delete",
        									id: sel.data.Id
        								},
        								success: function(resp, opt) {
        									grid.getStore().remove(sel);
        								},
        								failure: function(resp, opt) {
        									Ext.Msg.alert('Error', 'Unable to delete row');
        								}
        							});
        						}
        					}
        				});
        			};
        		}
			}],
			listeners: {
					afteredit: function(e) {
						var conn = new Ext.data.Connection();
						conn.request({
							url: "DataSourceUpdate.aspx",
							params: {
								action: "update",
								id: e.record.data.Id,
								field: e.field,
								value: e.value
							},
							success: function(resp, opt) {
								e.record.commit();
							},
							failure: function(resp, opt) {
								e.record.reject();
							}
						});
					}
			}
		}),
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [{
				region: 'north',
				xtype: 'panel'
			}, {
				region: 'center',
				xtype: 'panel',
				items: grid
}]
			});

	store.load();
});
