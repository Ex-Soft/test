Ext.define("TestRouting.widget.GridPanel", {
	extend: "Ext.grid.Panel",
    alias: "widget.gridpanel",

    requires: [
        "TestRouting.store.GridStore",
        "TestRouting.ToolbarSearchPlugin"
    ],

    mixins: {
        toolbarSearchMixin: "TestRouting.ToolbarSearchMixin"
    },

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
        }, {
            xtype: "button",
            text: "Emulate",
            handler: function (btn) {
                var grid;
                
                if (!(grid = btn.up("grid")))
                    return;

                grid.emulate();
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

        me.addPlugin("toolbarSearchPlugin");

        me.addEvents({
            "navNodeSelected": true,
            "gridRowChanged": true,
            "searched": true
        });

        me.on("navNodeSelected", me.onNavNodeSelected, me);
        me.on("gridRowChanged", me.onGridRowChanged, me);
    },

    listeners: {
        reconfigure: function(grid, eOpts) {
            if (window.console && console.log)
                console.log("reconfigure(%o)", arguments);
        }
    },

    onNavNodeSelected: function (category) {
        if (window.console && console.log)
            console.log("onNavNodeSelected(%o)", arguments);

        var me = this,
            store = me.getStore();

        if (Ext.isEmpty(me.getUrl())) {
            return;
        }

        if (!store.getTotalCount()) {
            store.load({
                scope: me,
                callback: me.onStoreFirstLoad
            });
        } else {
            me.onStoreFirstLoad();
        }
    },

    onStoreFirstLoad: function () {
        this.onGridRowChanged(TestRouting.Router.parseToken(TestRouting.Router.getToken()));
    },

    onGridRowChanged: function (token) {
        var plugin;

        if (!(plugin = this.findPlugin("toolbarSearchPlugin"))) {
            return;
        }

        var params = token.params || {};

        if (Ext.isEmpty(params.id))
            params.id = "";

        plugin.search(params);
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
    },

    emulate: function () {
        var plugin = this.findPlugin("toolbarSearchPlugin");

        plugin.search({ id: 1 });
    }
});