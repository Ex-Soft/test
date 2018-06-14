Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestTreeModel", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
		{ name: "id", type: "int" },
		{ name: "parentId", type: "int" },
		{ name: "leaf", type: "boolean" },
        "text",
        "cls"
	]
});

Ext.define("TestTreeStore", {
    extend: "Ext.data.TreeStore",
    model: "TestTreeModel",
    autoLoad: true,
    root: {
        id: 0,
        text: "RootRoot"
    },
    proxy: {
        type: "ajax",
        url: "api/tree",
        listeners: {
            exception: function (proxy, response, operation, eOpts) {
                if (window.console && console.log)
                    console.log("proxy.exception(%o)", arguments);
            }
        },
        reader: {
            root: "children",
            type: "json",
            idProperty: "id",
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
});

Ext.define("TestTreePanel", {
	extend: "Ext.tree.Panel",
    alias: "widget.testtreepanel",

	requires: [
		"Ext.data.TreeStore"
	],
    
    store: Ext.create("TestTreeStore")
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    Ext.create("TestTreePanel", {
        width: 200,
        height: 200,
        //rootVisible: false,
        renderTo: Ext.getBody()
    });
});
