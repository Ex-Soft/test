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
        { name: "Salary", type: "float" },
        { name: "Dep", type: "int" },
        { name: "BirthDate", type: "date", dateFormat: "MS" }
    ]
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var
        grid1 = Ext.create("Ext.grid.Panel", {
            title: "grid# 1",
            store: Ext.create("Ext.data.JsonStore", {
                model: "Staff",
                autoLoad: true,
                proxy: {
                    type: "ajax",
                    url: "staff.aspx",
                    reader: {
                        root: "staff"
                    }
                },
                listeners: {
                    beforeload: function (store, operation, eOpts) {
                        if (window.console && console.log)
                            console.log("store.beforeload(%o)", arguments);
                    },
                    load: function (store, records, successful, eOpts) {
                        if (window.console && console.log)
                            console.log("store.load(%o)", arguments);
                    }
                }
            }),
            columns: [
                { header: "Name", dataIndex: "Name", flex: 1, editor: { xtype: "textfield"} },
                { header: "Salary", dataIndex: "Salary", flex: 1, editor: { xtype: "numberfield"} },
                { header: "Department", dataIndex: "Dep", flex: 1, editor: { xtype: "numberfield"} },
                { header: "BirthDate", dataIndex: "BirthDate", renderer: Ext.util.Format.dateRenderer(Ext.util.Format.dateFormat), flex: 1, editor: { xtype: "datefield", format: Ext.util.Format.dateFormat} }
            ],
            listeners: {
                beforerender: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.beforerender(%o)", arguments);
                },
                render: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.render(%o)", arguments);
                },
                afterrender: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.afterrender(%o)", arguments);
                }
            }
        }),
        grid2 = Ext.create("Ext.grid.Panel", {
            title: "grid# 2",
            store: Ext.create("Ext.data.JsonStore", {
                model: "Staff",
                autoLoad: true,
                proxy: {
                    type: "ajax",
                    url: "staff.aspx",
                    reader: {
                        root: "staff"
                    }
                },
                listeners: {
                    beforeload: function (store, operation, eOpts) {
                        if (window.console && console.log)
                            console.log("store.beforeload(%o)", arguments);
                    },
                    load: function (store, records, successful, eOpts) {
                        if (window.console && console.log)
                            console.log("store.load(%o)", arguments);
                    }
                }
            }),
            columns: [
                { header: "Name", dataIndex: "Name", flex: 1, editor: { xtype: "textfield"} },
                { header: "Salary", dataIndex: "Salary", flex: 1, editor: { xtype: "numberfield"} },
                { header: "Department", dataIndex: "Dep", flex: 1, editor: { xtype: "numberfield"} },
                { header: "BirthDate", dataIndex: "BirthDate", renderer: Ext.util.Format.dateRenderer(Ext.util.Format.dateFormat), flex: 1, editor: { xtype: "datefield", format: Ext.util.Format.dateFormat} }
            ],
            listeners: {
                beforerender: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.beforerender(%o)", arguments);
                },
                render: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.render(%o)", arguments);
                },
                afterrender: function (grid, eOpts) {
                    if (window.console && console.log)
                        console.log("grid.afterrender(%o)", arguments);
                }
            }
        });

    Ext.create("Ext.tab.Panel", {
        layout: "fit",
        items: [
            grid1,
            grid2
        ],
        renderTo: Ext.getBody()
    });
});