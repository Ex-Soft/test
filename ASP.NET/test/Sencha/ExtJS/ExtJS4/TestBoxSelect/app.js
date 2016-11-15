Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("Staff", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        "Name",
        { name: "Dep", type: "int" }
    ]
});

Ext.define("StaffReader", {
    extend: "Ext.data.reader.Json",
    alias: "reader.StaffReader",
    idProperty: "Id",
    root: "staffs",
    successProperty: "success",
    totalProperty: "total",
    messageProperty: "message"
});

Ext.define("StaffStore", {
    extend: "Ext.data.Store",
    alias: "store.StaffStore",

    constructor: function(config) {
        config = config || {};

        Ext.applyIf(config, {
            model: "Staff",
            proxy: {
                type: "ajax",
                url: "Staff.aspx",
                reader: "StaffReader"
            }
        });

        this.listeners = config.listeners;

        this.callParent([config]);
    }
});

Ext.define("StaffCombobox", {
    extend: "Ext.ux.form.field.BoxSelect",

    constructor: function (config) {
        config = config || {};
        this.listeners = config.listeners;

        this.callParent([config]);
    }
});

Ext.onReady(function () {
    Ext.QuickTips.init();

    var
        staffStoreLocal1 = Ext.create("StaffStore", {
            autoLoad: true,
            listeners: {
                load: function (store, records, successful, operation, eOpts) {
                    var
                        staffStoreLocal2 = Ext.create("StaffStore", {
                            autoLoad: true,
                            listeners: {
                                load: function (store, records, successful, operation, eOpts) {
                                    staffComboboxLocal2.setValue([-1, -2]);
                                }
                            }
                        }),
                        staffStoreLocal3 = Ext.create("StaffStore", {
                            autoLoad: true
                        }),
                        staffStoreRemote1 = Ext.create("StaffStore", {
                            autoLoad: false
                        }),
                        staffComboboxLocal1 = Ext.create("StaffCombobox", {
                            fieldLabel: "Local1",
                            store: staffStoreLocal1,
                            queryMode: "local",
                            displayField: "Name",
                            valueField: "Id",
                            emptyText: "EmptyText",
                            width: 500,
                            value: [-1, -2]
                        }),
                        staffComboboxLocal2 = Ext.create("StaffCombobox", {
                            fieldLabel: "Local2",
                            store: staffStoreLocal2,
                            queryMode: "local",
                            displayField: "Name",
                            valueField: "Id",
                            emptyText: "EmptyText",
                            width: 500
                            //, pinList: false
                            //, stacked: true
                            , grow: false
                        }),
                        staffComboboxLocal3 = Ext.create("StaffCombobox", {
                            fieldLabel: "Local3 (singleSelect)",
                            store: staffStoreLocal3,
                            queryMode: "local",
                            displayField: "Name",
                            valueField: "Id",
                            emptyText: "EmptyText",
                            width: 500,
                            multiSelect: false
                        }),
                        staffComboboxRemote1 = Ext.create("StaffCombobox", {
                            fieldLabel: "Remote1",
                            store: staffStoreRemote1,
                            pageSize: 20,
                            queryMode: "remote",
                            displayField: "Name",
                            valueField: "Id",
                            emptyText: "EmptyText",
                            width: 500,
                            triggerOnClick: false,
                            labelTpl: "{Name} ({Id})",
                            tpl: Ext.create("Ext.XTemplate",
                                "<ul><tpl for=\".\">",
                                "<li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\">{Name}: {Dep}</li>",
                                "</tpl></ul>"
                            ),
                            delimiter: "|",
                            value: "-1|-2"
                        });

                    Ext.create("Ext.panel.Panel", {
                        layout: "fit",
                        items: [
                            staffComboboxLocal1,
                            staffComboboxLocal2,
                            staffComboboxLocal3,
                            staffComboboxRemote1
                        ],
                        tbar: [
                            {
                                xtype: "button",
                                text: "Check Store",
                                handler: function (btn, e) {
                                    var 
                                        count = staffStoreLocal1;
                                }
                            }
                        ],
                        renderTo: Ext.getBody(),
                        listeners: {
                            render: function (container, eOpts) {
                                //alert(1);
                            }
                        }
                    });
                }
            }
        });
});