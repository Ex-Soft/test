Ext.define("UniView.ux.grid.EditPanel", {
    extend: "UniView.ux.grid.AutoReconfigurePanel",
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
            text: "Save"
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