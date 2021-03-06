Ext.define("DbView.ux.classic.tab.GridsPanel", {
    extend: "Ext.tab.Panel",
    alias: ["widget.gridstabpanel"],
    
    requires: ["DbView.ux.classic.grid.EditPanel"],

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
                url: "api/data/" + table.name
            });

        me.setActiveTab(tab);
    }
});
