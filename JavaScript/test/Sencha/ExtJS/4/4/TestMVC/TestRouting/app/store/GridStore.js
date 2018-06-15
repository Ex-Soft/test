Ext.define("TestRouting.store.GridStore", {
	extend: "Ext.data.Store",
	alias: "store.gridstore",

    config: {
        url: null,
        grid: null
    },

    constructor: function(config) {
        config = config || {};

        Ext.applyIf(config, {
            proxy: {
                type: "ajax",
                url: config.url,
                reader: {
                    type: "json",
                    root: "rows",
                    messageProperty: "message"
                }
            },
        });

        this.callParent([config]);

        return this;
    },

	listeners: {
		load: function(store, records, successful, operation, eOpts) {
			if (window.console && console.log)
				console.log("load(%o)", arguments);
        },
        metachange: function(store, meta) {
            if (window.console && console.log)
				console.log("metachange(%o)", arguments);
            store.getGrid().reconfigure(store, meta.columns);
        }
	}
});