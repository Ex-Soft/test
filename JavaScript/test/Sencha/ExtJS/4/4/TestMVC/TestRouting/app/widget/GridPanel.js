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
        var me = this;

        me.store = new TestRouting.store.GridStore({ url: this.getUrl(), grid: me })
        me.callParent();

        me.addEvents({
            "navNodeSelected": true
        });

        me.on("navNodeSelected", me.onNavNodeSelected, me);
    },

    listeners: {
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("reconfigure(%o)", arguments);
        }
    },

    onNavNodeSelected: function (nodeId) {
        if (window.console && console.log)
            console.log("onNavNodeSelected(%o)", arguments);

        var me = this,
            store = me.getStore();

        if (!Ext.isEmpty(me.getUrl()) && !store.getTotalCount())
            store.load();
    }
});