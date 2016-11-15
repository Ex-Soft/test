Ext.define("AM.store.Countries", {
    extend: "Ext.data.Store",
    alias: "store.countries",
    model: "AM.model.Country",
    autoLoad: true,
    proxy: {
        type: "ajax",
        url: "Country.aspx",
        reader: {
            type: "xml",
            record: "row",
            idProperty: "id",
            totalProperty: "total",
            successProperty: "success",
            messageProperty: "message"
        }
    },
    listeners: {
        beforeload: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload (Countries)");
        },
        beforeprefetch: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeprefetch (Countries)");
        },
        load: function (store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load: successful=%s (Countries)", successful);
        },
        update: function (store, record, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.update (Countries)");
        }
    }
});
