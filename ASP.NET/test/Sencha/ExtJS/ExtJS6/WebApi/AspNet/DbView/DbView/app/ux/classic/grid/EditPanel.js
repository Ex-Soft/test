Ext.define("DbView.ux.classic.grid.EditPanel", {
    extend: "DbView.ux.classic.grid.AutoReconfigurePanel",
    alias: ["widget.editgridpanel", "widget.editgrid"],

    multiColumnSort: true,

    plugins: [
        { ptype: "rowediting" }
    ],

    dockedItems: [{
        xtype: "toolbar",
        dock: "top",
        items: [{
            xtype: "button",
            iconCls: "x-tool-save",
            text: "Save",
            handler: function (btn, e) {
                var grid;

                if (!(grid = btn.up("grid")))
                    return;

                grid.getStore().sync();
            }
        }]
    }],

    initComponent: function () {
        this.callParent();

        this.addDocked({
            xtype: "toolbar",
            dock: "bottom",
            items: [{
                xtype: 'pagingtoolbar',
                store: this.getStore(),
                displayInfo: true
            }]
        });
    }
});
