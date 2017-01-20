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

Ext.define("StaffReader", {
    extend: "Ext.data.reader.Json",
    alias: "reader.StaffReader",
    idProperty: "id",
    root: "rows",
    successProperty: "success",
    totalProperty: "total",
    messageProperty: "message"
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
                reader: "StaffReader"
            }
        });

        this.callParent([config]);
    }
});

Ext.onReady(function() {
	if(window.console && console.log)
		console.log("Ext.data.StoreManager.keys = %o", Ext.data.StoreManager.keys);

	var
        	staffStoreLocal1 = Ext.create("StaffStore", { autoLoad: true });
        	
	if(window.console && console.log)
		console.log("Ext.data.StoreManager.keys = %o", Ext.data.StoreManager.keys);

	if(window.console && console.log)
		console.log("Ext.onReady");
});

