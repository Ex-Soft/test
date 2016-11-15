Ext.define("CustomJsonWriter", {
    extend: "Ext.data.writer.Json",
    alias: "writer.CustomJsonWriter",
    writeAllFields: false,
    allowSingle: false,
    writeRecords: function (request, data) {
        if (window.console && console.log)
            console.log("CustomJsonWriter.writeRecords()");

        return this.callParent([request, data]); // return request;
    }
});

Ext.define("TG.store.Staffs", {
    extend: "Ext.data.Store",
    model: "TG.model.Staff",
    autoLoad: true,
    pageSize: 2,
    proxy: {
        type: "ajax",
        api: {
            create: "Staff.aspx?action=create",
            read: "Staff.aspx?action=read",
            update: "Staff.aspx?action=update",
            destroy: "Staff.aspx?action=destroy"
        },
        reader: {
            type: "json",
            root: "staffs",
            idProperty: "Id",
            totalProperty: "total",
            successProperty: "success",
            messageProperty: "message"
        },
        writer: "CustomJsonWriter",
        listeners: {
            exception: function (proxy, response, operation, eOpts) {
                if (window.console && console.log)
                    console.log("Proxy.Exception (%o)", arguments);
            }
        }
    },
    listeners: {
        beforeload: function (store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload (Staffs)");
        },
        beforeprefetch: function (store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeprefetch (Staffs)");
        },
        beforesync: function (options, eOpts) {
            var 
                proxy = this.getProxy();

            if (window.console && console.log)
                console.log("Store.beforesync (Staffs)");

            proxy.extraParams = {
                extraParam1: 1,
                extraParam2: 2
            };
        },
        load: function (store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load: successful=%s (Staffs), getCount(): %i, getTotalCount(): %i", successful, store.getCount(), store.getTotalCount());
        },
        update: function (store, record, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.update (Staffs)");
        },
        write: function (store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.write (Staffs)");
        }
    }
});
