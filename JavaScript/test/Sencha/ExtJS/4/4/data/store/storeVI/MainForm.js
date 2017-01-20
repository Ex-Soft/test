Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("Staff", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        { name: "name" }
    ]
});

Ext.define("StaffStore", {
    extend: "Ext.data.Store",
    alias: "store.StaffStore",
    storeId: "StaffStore",

    constructor: function(config) {
        config = config || {};

        Ext.applyIf(config, {
            model: "Staff",
            proxy: {
                type: "ajax",
                url: "Staff.aspx",
                reader: {
                    idProperty: "id",
                    root: "rows",
                    successProperty: "success",
                    totalProperty: "total",
                    messageProperty: "message"
                },
                extraParams: {
                    extraParams1: "extraParams1",
                    extraParams2: "extraParams2"
                }
            }
        });

        this.callParent([config]);
    }
});

Ext.onReady(function() {
	var
		staffStore = Ext.create("StaffStore", { autoLoad: false });

	staffStore.load({ params: { params1: "params1", extraParams2: "params2" } });
});

