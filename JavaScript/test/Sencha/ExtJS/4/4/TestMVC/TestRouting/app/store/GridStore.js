Ext.define("TestRouting.store.GridStore", {
	extend: "Ext.data.Store",
	alias: "store.gridstore",

    proxy: {
        type: "ajax",
        reader: {
            type: "json",
            root: "rows"
        }
    },

    config: {
        url: null,
    },

    constructor: function(config) {
        config = config || {};

        if (config.url)
            this.proxy.url = config.url;

        this.callParent([config]);

        return this;
    },

	listeners: {
		load: function() {
			if (window.console && console.log)
				console.log("load(%o)", arguments);
		}
	}
});