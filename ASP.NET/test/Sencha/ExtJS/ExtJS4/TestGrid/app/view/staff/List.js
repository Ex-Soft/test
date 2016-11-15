Ext.define("TG.view.staff.List", {
    extend: "Ext.grid.Panel",
    alias: "widget.stafflist",

    initComponent: function () {
        var 
            storeCountries = Ext.create("TG.store.Countries"),
            countriesRenderer = function (value, metaData, record, rowIndex, colIndex, store, view) {
                var 
                    countryRecord;

                if (window.console && console.log)
                    console.log("storeCountries.count(): %d (countriesRenderer)", storeCountries.count());

                return (countryRecord = storeCountries.getById(value)) ? countryRecord.get("Value") : "!storeCountries.getById(value)";
            };

        Ext.apply(this, {
            title: "All Staffs",
            store: "Staffs",

            columns: [
                    { header: "Name", dataIndex: "Name", flex: 1, editor: { xtype: "textfield"} },
                    { header: "Salary", dataIndex: "Salary", flex: 1, editor: { xtype: "numberfield"} },
                    { header: "Country", dataIndex: "Dep", flex: 1, renderer: countriesRenderer, editor: {
                        xtype: "combobox",
                        store: storeCountries,
                        valueField: "Id",
                        displayField: "Value",
                        emptyText: "Select...",
                        loadingText: "Loading...",
                        allowBlank: true,
                        triggerAction: "all",
                        editable: false,
                        queryMode: "local",
                        forceSelection: true,
                        selectOnFocus: true,
                        lazyRender: false,
                        listClass: "x-combo-list-small"
                    }
                    },
                    { header: "BirthDate", dataIndex: "BirthDate", renderer: Ext.util.Format.dateRenderer("d.m.Y"), flex: 1, editor: { xtype: "datefield", format: "d.m.Y"} }
            ],

            dockedItems: [{
                xtype: "toolbar",
                dock: "top",
                items: [{
                    xtype: "button",
                    text: "Add",
                    iconCls: "btn-add",
                    scope: this,
                    handler: this.onAddClick
                }, {
                    xtype: "button",
                    text: "Delete",
                    iconCls: "btn-delete",
                    scope: this,
                    handler: this.onDeleteClick
                }, {
                    xtype: "button",
                    text: "Save",
                    iconCls: "btn-save",
                    scope: this,
                    handler: this.onSaveClick
                }]
            }, {
                xtype: "pagingtoolbar",
                store: "Staffs",
                dock: "bottom",
                displayInfo: true
            }],

            selType: "rowmodel",
            plugins: [
                Ext.create("Ext.grid.plugin.CellEditing", {
                    clicksToEdit: 2
                })
            ],

            menu: Ext.create("Ext.menu.Menu", {
                items: [{
                    text: "Delete",
                    iconCls: "btn-delete",
                    scope: this,
                    handler: this.onDeleteClick
                }]
            }),

            viewConfig: {
                listeners: {
                    itemcontextmenu: { fn: this.onItemContextMenu, scope: this }
                }
            }
        });

        this.callParent();

        //this.addListener("itemcontextmenu", this.onItemContextMenu, this);
    },

    onItemContextMenu: function (grid, record, item, index, event, eOpts) {
        event.stopEvent();
        this.menu.showAt(event.xy);
    },

    onAddClick: function () {
        this.editingPlugin.cancelEdit();
        this.getStore().insert(0, Ext.create("TG.model.Staff", {
            Name: "Иванов Иван Иванович",
            Salary: 999,
            Dep: 4,
            BirthDate: new Date()
        }));
        this.editingPlugin.startEditByPosition({
            row: 0,
            column: 0
        });
    },

    onDeleteClick: function () {
        var 
            sm = this.getSelectionModel(),
            sel = sm.selected;

        if (sm.hasSelection()) {
            this.getStore().remove(sel.items);
        }
    },

    onSaveClick: function () {
        this.editingPlugin.cancelEdit();
        this.getStore().sync({
            success: function (batch, batchOptions) {
                if (window.console && console.log)
                    console.log("Ext.data.Store.sync({success})");
            },
            failure: function (batch, batchOptions) {
                if (window.console && console.log)
                    console.log("Ext.data.Store.sync({failure})");
            }
        });
    }
});