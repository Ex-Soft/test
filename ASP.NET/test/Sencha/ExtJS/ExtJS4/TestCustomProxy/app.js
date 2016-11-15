Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false,
    paths: {
        "Custom": "."
    }
});

Ext.define("TestModel", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        { name: "Name", type: "string" }
    ]
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    Ext.data.AbstractStore.prototype.destroyStore = Ext.Function.createSequence(Ext.data.AbstractStore.prototype.destroyStore, function () {
        if (window.console && console.log)
            console.log("Ext.data.AbstractStore.prototype.destroyStore(%o)", arguments);
    });

    var 
        grid = Ext.create("Ext.grid.Panel", {
            store: Ext.create("Custom.ux.data.CustomStore", {
                model: "TestModel"
                //, buffered: true
                , pageSize: 150
                , purgePageCount: 1 + Math.floor((1000 - 1) / 150)
                //, remoteFilter: true
                //, remoteSort: true
                //, remoteGroup: true
            }),
            columns: [
                { dataIndex: "Id", header: "Id" },
                { dataIndex: "Name", header: "Name" }
            ],
            plugins: "bufferedrenderer",
            dockedItems: [{
                xtype: "toolbar",
                dock: "top",
                items: [{
                    text: "load()",
                    handler: function (btn, e) {
                        var 
                            grid = btn.up("grid"),
                            store = grid.getStore();

                        store.load();
                    }
                }, {
                    text: "reload()",
                    handler: function (btn, e) {
                        var 
                            grid = btn.up("grid"),
                            store = grid.getStore();

                        store.reload();
                    }
                }, {
                    text: "set filter",
                    handler: function (btn, e) {
                        var 
                            grid = btn.up("grid"),
                            store = grid.getStore();

                        store.filter([
                            { property: "Id", value: -1 }
                        ]);
                    }
                }, {
                    text: "reset filter",
                    handler: function (btn, e) {
                        var 
                            grid = btn.up("grid"),
                            store = grid.getStore();

                        store.clearFilter();
                    }
                }, {
                    text: "watch",
                    handler: function (btn, e) {
                        var 
                            grid = btn.up("grid"),
                            store = grid.getStore();

                        if (store)
                            ;
                    }
                }]
            }]
        });

    Ext.create("Ext.window.Window", {
        autoShow: true,
        autoDestroy: true,
        height: 300,
        width: 300,
        layout: "fit",
        items: [grid]
    });
});