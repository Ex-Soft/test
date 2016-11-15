Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestArrayModel1", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int", mapping: 1 },
        { name: "name", mapping: 0 }
    ]
});

Ext.define("TestArrayReader1", {
    extend: "Ext.data.reader.Array",
    alias: "reader.TestArrayReader1",
    root: "data.data",
    read: function (response) {
        if (window.console && console.log)
            console.log("TestArrayReader1.read()");

        var 
            responseObj = Ext.decode(response.responseText),
			data = [];

        data = this.getRoot(responseObj);
        data.push(["Record# 5", 5]);

        return this.callParent([data]);
    },
    readRecords: function (data) {
        if (window.console && console.log)
            console.log("TestArrayReader1.readRecords()");

        return this.callParent([data]); 
    },
    buildExtractors: function () {
        if (window.console && console.log)
            console.log("TestArrayReader1.buildExtractors()");

        this.callParent(arguments);
    }
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
        store = new Ext.data.Store({
            model: "TestArrayModel1",
            proxy: {
                type: "ajax",
                url: "DataArray.aspx",
                reader: "TestArrayReader1" // { type: "array", root: "data.data" }
            },
            listeners: {
                load: function (store, records, successful, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.data.Store.load(%o)", arguments);

                    if (successful) {
                        store.each(function (r) {
                            if (window.console && console.log)
                                console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
                        });

                        tmpRec = store.getById(1);
                        if (tmpRec) {
                            if (window.console && console.log)
                                console.log("Store.getById(): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
                        }

                        tmpRec = store.findRecord("name", "Record# 3");
                        if (tmpRec) {
                            if (window.console && console.log)
                                console.log("Store.findRecord(): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
                        }
                    }
                }
            }
        });

    store.load();
});