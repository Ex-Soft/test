Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function () {
    if(window.console && console.clear)
        console.clear();

    if(window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var
		extraParamField = Ext.create("Ext.form.field.Text", {
            value: "extraParamValue"
        }),
		store = Ext.create("Ext.data.Store", {
		    autoSync: false,
            remoteGroup: true,
		    fields: [
				{ name: "id", type: "int" },
				"name",
                { name: "smthfield", type: "int" }
			],
		    proxy: {
		        type: "ajax",
		        url: "handler.ashx",
                simpleGroupMode: true
		    },
		    listeners: {
		        beforesync: function (options, eOpts) {
		            /* this.getProxy().extraParams = {
		                extraParamValue: extraParamField.getValue()
		            }; */
		        }
		    },
		    data: [
				{ id: 1, name: "Record# 1", smthfield: 1 },
				{ id: 2, name: "Record# 2", smthfield: 1 },
				{ id: 3, name: "Record# 3", smthfield: 2 },
				{ id: 4, name: "Record# 4", smthfield: 2 }
			]
		}),
		grid = Ext.create("Ext.grid.Panel", {
		    store: store,
		    columns: [
				{ dataIndex: "id", header: "id", editor: { xtype: "numberfield" }, flex: 1 },
				{ dataIndex: "name", header: "name", editor: { xtype: "textfield" }, flex: 1 },
                { dataIndex: "smthfield", header: "smthfield", editor: { xtype: "numberfield" }, flex: 1 }
			],
		    plugins: [
				Ext.create("Ext.grid.plugin.CellEditing", {
				    clicksToEdit: 2
				})
			],
            features: [{
                //ftype: "groupingsummary",
                ftype: "grouping",
                groupHeaderTpl: "{columnName}: {name} ({rows.length} Item{[values.rows.length > 1 ? \"s\" : \"\"]})"
            }],
		    dockedItems: [{
                xtype: "toolbar",
                dock: "top",
                items: [{
		            text: "Add",
		            handler: function (btn, e) {
		                store.add(Ext.create(store.getProxy().getModel(), { name: "blah-blah-blah" }));
		            }
		        }, {
		            text: "Del",
		            handler: function (btn, e) {
		                var 
						    grid,
						    sm,
						    sel;

    		            if(!(grid=btn.up("grid"))
	    					|| !(sm=grid.getSelectionModel())
		    				|| !(sel=sm.selected)
			    			|| !sm.hasSelection())
		                    return;

    		            grid.getStore().remove(sel.items);
	    	        }
		        }, {
		            text: "Save",
		            handler: function (btn, t) {
		                store.sync();
		            }
		        },
				    extraParamField
			    ]
            }],
		    renderTo: Ext.getBody()
		});
});