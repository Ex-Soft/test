Ext.define('TodoApi.store.Personnel', {
    extend: 'Ext.data.Store',

    alias: 'store.personnel',

    model: "TodoApi.model.Personnel",

    proxy: {
        type: 'ajax',
        url: "api/values",
        reader: {
            type: 'json',
            rootProperty: 'data',
            messageProperty: "message"
        }
    },

    autoLoad: true
});
