Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("TestStore", {
    extend: "Ext.data.Store",
    alias: "store.teststore",

    autoLoad: true,

    proxy: {
        type: "ajax",
        url: "data.json",
        reader: {
            type: "json"
        }
    },

    constructor: function (config) {
        if (window.console && console.log)
            console.log("Store.constructor(%o)", arguments);

        this.callParent(arguments);

        return this;
    },

    listeners: {
        beforeload: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload(%o)", arguments);

            // return false;
        },
        load: function (store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load(%o)", arguments);
        },
        metachange: function(store, meta) {
            if (window.console && console.log)
				console.log("Store.metachange(%o)", arguments);
        }
    }
});

Ext.define("TestGrid", {
    extend: "Ext.grid.Panel",
    alias: "widget.testgrid",

    columns: [],

    store: {
        type: "teststore"
    },

    constructor: function (config) {
        if (window.console && console.log)
            console.log("Grid.constructor(%o)", arguments);

        this.callParent(arguments);

        return this;
    },

    initComponent: function () {
        if (window.console && console.log)
            console.log("Grid.initComponent(%o) starting...", arguments);

        if (window.console && console.log)
            console.log("Grid.initComponent b4 callParent()");

        this.callParent();

        if (window.console && console.log)
            console.log("Grid.initComponent after callParent()");

        this.getStore().on("metachange", this.onMetaChange, this);

        if (window.console && console.log)
            console.log("Grid.initComponent(%o) finished", arguments);
    },

    listeners: {
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("Grid.reconfigure(%o)", arguments);
        }
    },

    onMetaChange: function (store, meta) {
        if (window.console && console.log)
                console.log("Grid.onMetaChange(%o)", arguments);

        this.reconfigure(store, meta.columns);
    }
});

Ext.onReady(function() {
    if(window.console && console.clear)
        console.clear();

    if(window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.QuickTips.init();

	var
		grid1 = Ext.create("TestGrid", {
            renderTo: Ext.getBody()
        }),
        grid2 = Ext.create("TestGrid", {
            renderTo: Ext.getBody()
        });
});
