Ext.define("DbView.ux.grid.NavigatePanel", {
    extend: "DbView.ux.grid.AutoReconfigurePanel",
    alias: ["widget.navigategridpanel", "widget.navigategrid"],
    
    doReconfigure: function (store, meta) {
        var me = this;

        me.callParent([store, meta]);
        me.hideColumns([store.getModel().idProperty]);
    },

    hideColumns: function (columns2hide) {
        var me = this,
            columns;

        if (!Ext.isArray(columns2hide))
            return;

        columns = me.getColumns();

        columns2hide.forEach(function (column) {
            var col;

            if (!(col = columns.find(function (c) { return c.dataIndex == column; })))
                return;

            col.hide();
        });
    }
});