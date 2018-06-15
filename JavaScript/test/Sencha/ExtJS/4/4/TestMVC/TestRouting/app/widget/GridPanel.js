Ext.define("TestRouting.widget.GridPanel", {
	extend: "Ext.grid.Panel",
    alias: "widget.gridpanel",

    config: {
        url: null,
    },

    columns: [],

    initComponent: function() {
        store = new TestRouting.store.GridStore({ url: this.getUrl()})
        this.callParent();
    },

    listeners: {
        afterrender: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("afterrender(%o)", arguments);
            grid.getStore().load();
        }
    }
});