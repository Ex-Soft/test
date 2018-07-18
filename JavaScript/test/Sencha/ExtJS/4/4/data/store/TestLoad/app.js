Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestModel", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        { name: "value" }
    ]
});

Ext.define("TestStore", {
    extend: "Ext.data.Store",
    model: "TestModel",
    //autoLoad: true,
    proxy: {
        type: "ajax",
        url: "Data.xml",
        reader: {
            type: "xml",
            record: "row",
            idProperty: "id",
            totalProperty: "total",
            successProperty: "success",
            messageProperty: "message"
        }
    },
    listeners: {
        beforeload: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload");

            // return false;
        },
        load: function (store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load: successful=%s records=%o", successful, records);
        }
    }
});

Ext.onReady(function() {
    if(window.console && console.clear)
        console.clear();

    if(window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.QuickTips.init();

	var
		testStore = Ext.create("TestStore");

	if(window.console && console.log)
		console.log("%o", testStore);

	testStore.load();
});
