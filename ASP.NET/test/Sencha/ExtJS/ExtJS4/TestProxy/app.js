Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestModel", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        "Name"
    ]
});

Ext.define("Custom.data.proxy.Server", {
    override: "Ext.data.proxy.Server",
    buildRequest: function (operation) {
        var 
            request = this.callParent(arguments);

        if (operation.jsonData)
            request.jsonData = operation.jsonData;

        if (operation.urlParams)
            request.urlParams = operation.urlParams;

        request.params.fromBuildRequest = "fromBuildRequest";

        return request;
    }
});

Ext.define("Custom.data.reader.Array", {
    extend: "Ext.data.reader.Array",
    alias: "reader.customarray",
    readRecords: function (data) {
        if (window.console && console.log)
            console.log("reader.readRecords(%o)", arguments);

        return this.callParent([data]);
    }
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
        pageSize = 150,
        createDataJSON = function (max) {
            var 
                data = [];

            for (var i = 1; i <= pageSize; ++i)
                data.push({ Id: -i, Name: "Record# " + i });

            return data;
        },
        createDataArray = function (max) {
            var 
                data = [];

            for (var i = 1; i <= pageSize; ++i)
                data.push([-i, "Record# " + i]);

            return data;
        },
        createRecords = function (data) {
            var 
                records = [];

            for (var i = 0, len = data.length; i < len; ++i)
                records.push(Ext.create("TestModel", data[i]));

            return records;
        },
        store = Ext.create("Ext.data.ArrayStore", {
            model: "TestModel",
            autoLoad: false,
            pageSize: pageSize,
            buffered: true,
            proxy: {
                type: "ajax",
                url: "test.aspx",
                actionMethods: {
                    read: "POST"
                },
                reader: {
                    type: "customarray",
                    root: "data",
                    totalProperty: "total"
                }
            },
            listeners: {
                beforeload: function (store, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("beforeload(%o)", arguments);

                    store.getProxy().extraParams = {
                        extraParam1: "extraParam1",
                        extraParam2: "extraParam2"
                    };

                    //return false; // If the beforeload handler returns false the load action will be canceled.
                },
                beforeprefetch: function (store, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("beforeprefetch(%o)", arguments);

                    operation.url = Ext.String.urlAppend(store.getProxy().url, "urlParams=urlParams");
                    operation.urlParams = "urlParamsII=urlParamsII";
                    operation.jsonData = "jsonData";

                    //return false; // Return false to cancel.
                },
                load: function (store, records, successful, eOpts) {
                    if (window.console && console.log)
                        console.log("load(%o)", arguments);
                },
                prefetch: function (store, records, successful, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("prefetch(%o)", arguments);
                }
            }
        }),
        grid = Ext.create("Ext.grid.Panel", {
            region: "center",
            store: store,
            columns: [
                { dataIndex: "Id", header: "Id" },
                { dataIndex: "Name", header: "Name" }
            ]
        });

    Ext.create("Ext.container.Viewport", {
        items: [{
            region: "north",
            xtype: "toolbar",
            height: 28,
            items: [{
                text: "status",
                handler: function (btn, e) {
                    var 
                        map,
                        lastIdx,
                        proxy = store.getProxy(),
                        reader = proxy.getReader();

                    if (window.console && console.log) {
                        console.log("%i", store.getCount());

                        if (store.pageMap) {
                            console.log("store.pageMap.length = %i", store.pageMap.length);
                            for (var i = 1, len = store.pageMap.length; i <= len; ++i) {
                                if (map = store.pageMap.map[i]) {
                                    console.log("map[%i].value.length = %i", i, map.value.length);
                                    console.log("map[%i].value[0] = { Id=%i Name=\"%s\" }", i, map.value[0].get("Id"), map.value[0].get("Name"));
                                    lastIdx = map.value.length - 1;
                                    console.log("map[%i].value[%i] = { Id=%i Name=\"%s\" }", i, lastIdx, map.value[lastIdx].get("Id"), map.value[lastIdx].get("Name"));
                                }
                            }
                        }
                    }
                }
            }, {
                text: "store.removeAll()",
                handler: function (btn, e) {
                    store.removeAll();
                }
            }, {
                text: "store.cachePage()",
                handler: function (btn, e) {
                    var 
                        records = createRecords(createDataJSON(pageSize * 3));

                    store.cachePage(records, 1);
                }
            }, {
                text: "store.load()",
                handler: function (btn, e) {
                    store.load();
                }
            }, {
                text: "store.loadData(Array)",
                handler: function (btn, e) {
                    var 
                        data = createDataArray(pageSize * 3);

                    store.loadData(data);
                }
            }, {
                text: "store.loadData(JSON)",
                handler: function (btn, e) {
                    var 
                        data = createDataJSON(pageSize * 3);

                    store.loadData(data);
                }

            }, {
                text: "store.loadPage()",
                handler: function (btn, e) {
                    store.loadPage(1);
                }
            }, {
                text: "store.loadRawData(Array)",
                handler: function (btn, e) {
                    var 
                        data = { total: 1000, data: createDataArray(pageSize * 3) };

                    store.loadRawData(data);
                }
            }, {
                text: "store.loadRecords()",
                handler: function (btn, e) {
                    var 
                        records = createRecords(createDataJSON(pageSize * 3));

                    store.loadRecords(records);
                }
            }]
        },
            grid
        ],
        layout: "border",
        renderTo: Ext.getBody()
    });
});