Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false,
    paths: {
        "Ext.ux": "ext4.2.1/examples/ux"
    }
});

Ext.require([
    "Ext.ux.grid.FiltersFeature",
    "Ext.grid.plugin.BufferedRenderer"
]);

Ext.define("TestModel", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        { name: "fstring", type: "string" },
        { name: "ffloat", type: "float" },
        { name: "fdate", type: "date", dateFormat: "MS" },
        { name: "fboolean", type: "boolean" },
        { name: "fint", type: "int" }
    ]
});

Ext.define("ListModel", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        { name: "fstring", type: "string" }
    ]
});

Ext.onReady(function () {
    Ext.QuickTips.init();

    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
        list = [
            [1, "Record# 1"],
            [2, "Record# 2"],
            [3, "Record# 3"]
        ],
        storeList = Ext.create("Ext.data.ArrayStore", {
            model: "ListModel",
            data: list
        }),
        listRenderer = function (value, metaData, record, rowIndex, colIndex, store, view) {
            var 
                listRecord;

            return (listRecord = storeList.getById(value)) ? listRecord.get("fstring") : "!storeList.getById(name)";
        },
        store = Ext.create("Ext.data.JsonStore", {
            model: "TestModel",
            remoteFilter: true,
            buffered: true,
            leadingBufferZone: 100,
            autoLoad: true,
            pageSize: 25,
            proxy: {
                type: "ajax",
                url: "data.aspx",
                reader: {
                    root: "data"
                }
            }
        });

    Ext.create("Ext.grid.Panel", {
        title: "Ext.grid.Panel with Ext.ux.grid.FiltersFeature",
        store: store,
        selModel: {
            pruneRemoved: false
        },
        viewConfig: {
            trackOver: false
        },
        columns: [
            { dataIndex: "id", header: "id", filterable: true },
            { dataIndex: "fstring", header: "fstring", filterable: true, flex: 1 },
            { dataIndex: "ffloat", header: "ffloat", filterable: true },
            { dataIndex: "fdate", header: "fdate", renderer: Ext.util.Format.dateRenderer("d.m.Y"), filter: { type: "date", dateFormat: "d.m.Y", afterText: "afterText", beforeText: "beforeText", onText: "onText"} },
            { dataIndex: "fboolean", header: "fboolean", filterable: true },
            { dataIndex: "fint", header: "fint", renderer: listRenderer, filter: { type: "list", dataIndex: "fint", options: list} }
        ],
        features: [{
            ftype: "filters",
            encode: true,
            local: !store.remoteFilter
        }],
        dockedItems: [{
            xtype: "toolbar",
            dock: "top",
            items: [{
                text: "watch",
                handler: function (btn, e) {
                    var 
                        grid = btn.up("grid"),
                        store = grid.getStore();

                    if (store)
                        ;
                }
            }]
        }/*, {
            xtype: "pagingtoolbar",
            dock: "bottom",
            store: store,
            displayInfo: true
        }*/]
        //, plugins: "bufferedrenderer"
        , renderTo: Ext.getBody()
    });
});