Ext.define('AspNetApp.store.Task', {
    extend: 'Ext.data.Store',
    alias: 'store.task',

    model: 'AspNetApp.model.Task',

    proxy: {
        type: 'ajax',
        url: 'task',
        reader: {
            type: 'json',
            rootProperty: 'data',
            messageProperty: 'message'
        }
    }
    , pageSize: 10
    //, autoLoad: true
    , listeners: {
        beforeload: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload(%o)", arguments);
        },
        load: function(store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load: successful=%s, getCount(): %i, getTotalCount(): %i", successful, store.getCount(), store.getTotalCount());
        }
    },

    constructor: function (config) {
        var me = this;

        if (window.console && console.log)
            console.log("Store.constructor(%o)", arguments);

        this.callParent([config]);
    },

    setDate: function (date) {
        this.getProxy().setExtraParam("date", date);
        this.loadPage(1);
    }
});