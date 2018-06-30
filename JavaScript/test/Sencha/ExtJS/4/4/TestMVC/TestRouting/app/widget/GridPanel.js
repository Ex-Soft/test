Ext.define("TestRouting.widget.GridPanel", {
	extend: "Ext.grid.Panel",
    alias: "widget.gridpanel",

    requires: [
        "TestRouting.store.GridStore",
        "TestRouting.RoutingPlugin"
    ],

    config: {
        url: null,
    },

    plugins: ["routingplugin"],

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
            name: "id"
        }, {
            xtype: "button",
            text: "Search",
            handler: function (btn) {
                var grid;
                
                if (!(grid = btn.up("grid")))
                    return;

                grid.onBtnSearchClick(btn);
            }
        }]
    }],

    columns: [],

    constructor: function (config) {
        if (window.console && console.log)
            console.log("GridPanel.ctor(%o)", arguments);

        this.callParent([config]);

        return this;
    },

    initComponent: function() {
        if (window.console && console.log)
            console.log("GridPanel.initComponent(%o)", arguments);

        var me = this;

        me.store = new TestRouting.store.GridStore({ url: this.getUrl(), grid: me })
        me.callParent();
    },

    listeners: {
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("reconfigure(%o)", arguments);
        }
    },

    onBtnSearchClick: function (btn) {
        var grid,
            form,
            values,
            store;

        if (!(grid = btn.up("grid"))
            || !(form = grid.down("form")))
            return;

        values = form.getForm().getValues();

        if ((store = grid.getStore()).isFiltered()) {
            store.clearFilter(!Ext.isEmpty(values.id));
        }

        if (!Ext.isEmpty(values.id)) {
            store.filter({ property: "id", value: values.id });
            store.fireEvent("load");
        }
    }
});
