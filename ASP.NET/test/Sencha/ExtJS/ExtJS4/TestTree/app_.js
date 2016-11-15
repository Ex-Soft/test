Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestTreeModel", {
    extend: "Ext.data.Model",
    fields: ['CatalogueID', 'Code', 'Classificator', 'Name', 'ObjCount']
    /*idProperty: "id",
    fields: [
			{ name: "id", type: "int" },
			{ name: "parentId", type: "int" },
			{ name: "isFolder", type: "boolean" },
			"caption"
		]*/
});

Ext.define("TestTreeStore", {
    extend: "Ext.data.TreeStore",
    model: "TestTreeModel",
    autoLoad: true,
    nodeParam: "ParentID",
    defaultRootId: 1,
    proxy: {
        type: "ajax",
        url: "data.aspx",
        listeners: {
            exception: function (proxy, response, operation, eOpts) {
                if (window.console && console.log)
                    console.log("proxy.exception(%o)", arguments);
            }
        },
        reader: {
            root: "staff",
            type: 'json',
            idProperty: "CatalogueID",
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
    
	width: 200,
	height: 200,
    store: Ext.create("TestTreeStore"),
    rootVisible: false
    //renderTo: Ext.getBody()
	/*initComponent: function() {
		Ext.apply(this, {
        	width: 200,
	        height: 200,
            store: Ext.create("TestTreeStore"),
            rootVisible: false,
            renderTo: Ext.getBody()
		});

		this.callParent(arguments);
	}*/
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    /*var 
        store = Ext.create("Ext.data.TreeStore", {
            model: "TestTreeModel",
            autoLoad: true,
            proxy: {
                type: "ajax",
                url: "data.aspx",
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
        t = Ext.create("Ext.tree.Panel", {
            width: 200,
            height: 200,
            store: store,
            rootVisible: false,
            renderTo: Ext.getBody()
        });*/

    Ext.create("TestTreePanel");
});