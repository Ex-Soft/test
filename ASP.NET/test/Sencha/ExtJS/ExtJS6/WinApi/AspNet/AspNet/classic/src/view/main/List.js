Ext.define('AspNetApp.view.main.List', {
    extend: 'Ext.grid.Panel',
    xtype: 'mainlist',
    controller: 'list',
    reference: 'mainlist',

    requires: [
        'AspNetApp.store.Task',
        'Ext.grid.plugin.RowEditing'
    ],

    plugins: [{
        ptype: 'rowediting',
        clicksToEdit: 1
    }],

    title: 'Task',

    columns: [
        { text: 'TaskName', dataIndex: 'TaskName', flex: 1 },
        { text: "Date", dataIndex: "Date", xtype: 'datecolumn', flex: 1, format: 'd.m.Y' },
        { text: "Begin", dataIndex: "Begin", xtype: 'datecolumn', flex: 1, format: 'H:i:s' },
        { text: "End", dataIndex: "End", xtype: 'datecolumn', flex: 1, format: 'H:i:s' }
    ],

    initComponent: function() {
        var store = Ext.data.StoreManager.lookup('AspNetApp.store.Task');

        this.store = store;

        this.dockedItems = [{
            xtype: 'toolbar',
            items: [{
                text: 'Add',
                iconCls: 'icon-add'
            }, {
                text: 'Delete',
                iconCls: 'icon-delete'
            }]
        }, {
            xtype: 'pagingtoolbar',
            store: store,
            dock: 'bottom',
            displayInfo: true
        }],

        this.callParent();
    },

    listeners: {
        select: 'onSelect'
    }
});
