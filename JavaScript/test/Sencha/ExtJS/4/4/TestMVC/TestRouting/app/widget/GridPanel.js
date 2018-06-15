Ext.define("TestRouting.widget.GridPanel", {
	extend: "Ext.grid.Panel",
    alias: "widget.gridpanel",

    config: {
        url: null,
    },

    //store: "TestRouting.store.GridStore",

    columns: [],

    initComponent: function() {
        this.store = new TestRouting.store.GridStore({ url: this.getUrl(), grid: this })
        this.callParent();
    },

    listeners: {
        afterrender: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("afterrender(%o)", arguments);
            grid.getStore().load();
        },
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("reconfigure(%o)", arguments);
        }
    }
});