Ext.define("TestRouting.widget.GridPanel", {
	extend: "Ext.grid.Panel",
    alias: "widget.gridpanel",

    requires: [ "TestRouting.store.GridStore" ],

    config: {
        url: null,
    },

    tbar: [{
        xtype: "form",
        frame: true,
        style: {
            border: "none"
        },
        layout: {
            type: "hbox",
            align: "middle"
        },
        defaults: {
            style : "margin-right: 5px;"
        },
        bodyStyle : {
            background: "none repeat scroll 0 0 transparent;"
        },
        items: [{
            xtype: "label",
            text: "ID"
        }, {
            xtype: "textfield",
            name: "ID"
        }, {
            xtype: "button",
            text: "Search"
        }]
    }],

    columns: [],

    initComponent: function() {
        this.store = new TestRouting.store.GridStore({ url: this.getUrl(), grid: this })
        this.callParent();
    },

    listeners: {
        afterrender: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("afterrender(%o)", arguments);

            if (!Ext.isEmpty(grid.getUrl()))
                grid.getStore().load();
        },
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("reconfigure(%o)", arguments);
        }
    }
});