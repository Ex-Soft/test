Ext.define("UniView.ux.tab.GridsPanel", {
    extend: "Ext.tab.Panel",
    alias: ["widget.gridstabpanel"],
    
    requires: ["UniView.ux.grid.EditPanel"],

    initComponent: function() {
        var me = this;

        me.callParent();

        me.on("addtable", me.onAddTable, me);
    },

    onAddTable: function (table) {
        if (!table || Ext.isEmpty(table.name))
            return;

        var me = this,
            tab;

        if (!(tab = me.child("#" + table.name)))
            tab = me.add({
                title: table.description,
                itemId: table.name,
                closable: true,
                xtype: "editgrid",
                url: "data/" + table.name
            });

        me.setActiveTab(tab);
    }
});