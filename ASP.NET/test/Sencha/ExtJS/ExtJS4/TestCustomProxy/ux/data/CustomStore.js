Ext.define("Custom.ux.data.CustomStore", {
    extend: "Ext.data.Store",
    alias: "store.customstore",

    requires: [
        "Custom.ux.data.proxy.CustomProxy",
        "Custom.ux.data.reader.CustomReader"
    ],

    constructor: function (config) {
        Ext.apply(this, {
            autoLoad: true,
            autoDestroy: true,
            proxy: {
                type: "customproxy"
            }
        });

        this.callParent(arguments);

        this.addListener("beforeload", this.onBeforeLoad, this);
        this.addListener("beforeprefetch", this.onBeforePrefetch, this);
        this.addListener("load", this.onLoad, this);
        this.addListener("prefetch", this.onPrefetch, this);

        return this;
    },

    onProxyLoad: function (operation) {
        if (window.console && console.log)
            console.log("CustomStore.onProxyLoad(%o)", arguments);

        this.callParent(arguments);

        //this.onProxyPrefetch(operation);
    },

    onProxyPrefetch: function (operation) {
        if (window.console && console.log)
            console.log("CustomStore.onProxyPrefetch(%o)", arguments);

        this.callParent(arguments);
    },

    onBeforeLoad: function (store, operation, eOpts) {
        if (window.console && console.log)
            console.log("CustomStore.beforeload(%o)", arguments);

        //return false; // If the beforeload handler returns false the load action will be canceled.
    },

    onBeforePrefetch: function (store, operation, eOpts) {
        if (window.console && console.log)
            console.log("CustomStore.beforeprefetch(%o)", arguments);

        //return false; // Return false to cancel.
    },

    onLoad: function (store, records, successful, eOpts) {
        if (window.console && console.log)
            console.log("CustomStore.load(%o)", arguments);

        //store.fireEvent('cachefilled', store, 0, 150);
    },

    onPrefetch: function (store, records, successful, operation, eOpts) {
        if (window.console && console.log)
            console.log("CustomStore.prefetch(%o)", arguments);
    },

    getRange: function (start, end, options) {
        var 
            me = this;

        if (window.console && console.log)
            console.log("CustomStore.getRange(%o)", arguments);

        //me.prefetchRange(start, end);

        var 
            result;

        result = me.callParent(arguments);

        /*if (options && options.callback)
        {
        options.callback.call(options.scope || me, result, start, end, options)
        }*/

        return result;
    },

    prefetch: function (options) {
        var 
            me = this;

        if (window.console && console.log)
            console.log("CustomStore.prefetch(%o)", arguments);

        return me.callParent(arguments);
    }
});