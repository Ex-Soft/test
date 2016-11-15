Ext.define("TG.store.Countries", {
    extend: "Ext.data.Store",
    model: "TG.model.Country",
    autoLoad: true,
    proxy: {
        type: "ajax",
        url: "Country.xml",
        reader: {
            type: "xml",
            record: "row",
            idProperty: "Id",
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
