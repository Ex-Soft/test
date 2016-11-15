Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false,
    paths: {
        "Ext.ux": "ux"
    }
});

Ext.define("Staff", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        { name: "Name", type: "string" },
        { name: "Salary", type: "float" },
        { name: "Dep", type: "int" },
        { name: "BirthDate", type: "date", dateFormat: "MS" }
    ]
});

Ext.require([
    "Ext.ux.grid.plugin.PagingSelectionPersistence"
]);

Ext.onReady(function () {
    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
        store = Ext.create("Ext.data.JsonStore", {
            model: "Staff",
            pageSize: 2,
            autoLoad: true,
            autoSync: false,
            proxy: {
                type: "ajax",
                url: "staff.aspx",
                actionMethods: {
                    create: "POST",
                    read: "GET",
                    update: "PUT",
                    destroy: "DELETE"
                },
                listeners: {
                    exception: function (proxy, response, operation, eOpts) {
                        if (window.console && console.log)
                            console.log("proxy.exception(%o)", arguments);
                    }
                },
                reader: {
                    root: "staff"
                },
                writer: {
                    writeAllFields: false,
                    allowSingle: false
                }
            },
            listeners: {
                load: function (store, records, successful, eOpts) {
                    if (window.console && console.log)
                        console.log("store.load(%o)", arguments);
                },
                write: function (store, record, operation, modifiedFieldNames, eOpts) {
                    if (window.console && console.log)
                        console.log("store.write(%o)", arguments);
                },
                update: function (store, record, operation, modifiedFieldNames, eOpts) {
                    if (window.console && console.log)
                        console.log("store.update(%o)", arguments);
                }
            }
        }),
        cbAutoSync = Ext.create("Ext.form.field.Checkbox", {
            checked: false,
            listeners: {
                change: function (checkbox, newValue, oldValue, eOpts) {
                    btnSave.setDisabled(store.autoSync = checkbox.getValue());
                }
            }
        }),
        btnSave = Ext.create("Ext.button.Button", {
            text: "Save",
            iconCls: "btn-save",
            handler: function (btn, e) {
                var 
                    grid;

                if (!(grid = btn.up("grid")))
                    return;

                grid.editingPlugin.cancelEdit();
                grid.getStore().sync();
            }
        }),
        f = Ext.create("Ext.form.Panel", {
		    frame: true,
		    items: [{
                xtype: "textfield",
                name: "Name",
                fieldLabel: "Name"
            }, {
			    xtype: "datefield",
                name: "BirthDate",
			    fieldLabel: "BirthDate",
			    emptyText: "dd.mm.yyyy",
			    value: "dd.mm.yyyy"
		    }, {
                xtype: "numberfield",
                name: "Salary",
                fieldLabel: "Salary",
                allowDecimals: true,
                decimalPrecision: 4,
                hideTrigger: true
		    }],
		    dockedItems: [{
			    xtype: "toolbar",
			    dock: "bottom",
			    items: [{
				    text: "Apply",
				    handler: function(btn, e) {
					    var
						    form = f.getForm();

					    if(form && form.isValid())
                        {
                            form.updateRecord(f.activeRecord);
						    w.hide();
                        }
				    }
			    }]
		    }]
	    }),
	    w = Ext.create("Ext.window.Window", {
		    title: "Test Ext.form.Panel",
		    autoScrol: true,
		    layout: "fit",
		    autoDestroy: true,
		    border: 0, // !!!
		    buttons: [
			    {
				    text: "Close",
				    handler: function(btn, e) {
					    w.hide();
				    }
			    }
		    ],
		    items: [f]
	    }),
        btnEditByForm = Ext.create("Ext.button.Button", {
            text: "Edit",
            iconCls: "btn-edit-by-form",
            handler: function (btn, e) {
                var 
                    grid,
                    sm,
                    sel;

                if (!(grid = btn.up("grid")))
                    return;

                sm = grid.getSelectionModel();
                sel = sm.selected;

                if (sm.hasSelection())
                {
                    f.getForm().loadRecord(sel.items[0]);
                    f.activeRecord=sel.items[0];
                    w.show();
                }
            }
        }),
        grid = Ext.create("Ext.grid.Panel", {
            store: store,
            columns: [
                { header: "Name", dataIndex: "Name", flex: 1, editor: { xtype: "textfield"} },
                { header: "Salary", dataIndex: "Salary", flex: 1, editor: { xtype: "numberfield"} },
                { header: "Department", dataIndex: "Dep", flex: 1, editor: { xtype: "numberfield"} },
                { header: "BirthDate", dataIndex: "BirthDate", renderer: Ext.util.Format.dateRenderer(Ext.util.Format.dateFormat), flex: 1, editor: { xtype: "datefield", format: Ext.util.Format.dateFormat} }
            ],
            selModel: {
                selType: "checkboxmodel",
                listeners: {
                    deselect: function (selModel, record, index, eOpts) {
                        if (window.console && console.log)
                            console.log("deselect(%o)", arguments);
                    },
                    select: function (selModel, record, index, eOpts) {
                        if (window.console && console.log)
                            console.log("select(%o)", arguments);
                    },
                    selectionchange: function (selModel, selected, eOpts) {
                        if (window.console && console.log)
                            console.log("selectionchange(%o)", arguments);
                    }
                }
            },
            plugins: [{
                ptype: 'pagingselectpersist'
            }],
            dockedItems: [{
                xtype: "toolbar",
                items: [{
                    text: "Add",
                    iconCls: "btn-add",
                    handler: function (btn, e) {
                        var 
                            grid,
                            store;

                        if (!(grid = btn.up("grid")))
                            return;

                        grid.editingPlugin.cancelEdit();
                        (store = grid.getStore()).insert(0, Ext.create("Staff", {
                            Name: "Васильев Василий Василиевич",
                            Salary: 999,
                            Dep: 4,
                            BirthDate: new Date()
                        }));
                        if (!store.autoSync)
                            grid.editingPlugin.startEditByPosition({
                                row: 0,
                                column: 0
                            });
                    }
                }, {
                    text: "Delete",
                    iconCls: "btn-delete",
                    handler: function (btn, e) {
                        var 
                            grid,
                            sm,
                            sel;

                        if (!(grid = btn.up("grid")))
                            return;

                        sm = grid.getSelectionModel();
                        sel = sm.selected;

                        if (sm.hasSelection())
                            grid.getStore().remove(sel.items);
                    }
                },
                    btnSave,
                    btnEditByForm,
                    "-",
                    "autoSync",
                    cbAutoSync
                ]
            }, {
                xtype: "pagingtoolbar",
                dock: "bottom",
                store: store,
                displayInfo: true
            }]
        });

    Ext.create("Ext.container.Viewport", {
        layout: "fit",
        items: [grid],
        renderTo: Ext.getBody()
    });
});