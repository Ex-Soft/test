Ext.define("Custom.ux.data.proxy.CustomProxy", {
    extend: "Ext.data.proxy.Ajax",
    alias: "proxy.customproxy",

    constructor: function (config) {
        Ext.apply(this, {
            url: "test.aspx",
            actionMethods: {
                read: "POST"
            },
            reader: {
                type: "customreader",
                root: "data",
                totalProperty: "total"
            }
        });

        this.callParent(arguments);

        return this;
    },

    doRequest: function (operation, callback, scope) {
        if (window.console && console.log)
            console.log("CustomProxy.doRequest(%o)", arguments);

        if (!scope.buffered) {
            scope.buffered = true;

            scope.data = new scope.PageMap({
                store: scope,
                pageSize: scope.pageSize,
                maxSize: scope.purgePageCount,
                listeners: {
                    clear: scope.onPageMapClear,
                    scope: scope
                }
            });

            scope.pageRequests = {};

            scope.sortOnLoad = false;
            scope.filterOnLoad = false;

            if (operation.generation !== scope.data.generation) {
                operation.generation = scope.data.generation;
                operation.addRecords = true;
            }
        }

        return this.callParent(arguments);
    },

    processResponse: function (success, operation, request, response, callback, scope) {
        if (window.console && console.log)
            console.log("CustomProxy.processResponse(%o)", arguments);

        this.callParent(arguments);
    },

    onDestroy: function () {
        if (window.console && console.log)
            console.log("CustomProxy.onDestroy(%o)", arguments);

        this.callParent(arguments);
    },

    destroy: function () {
        if (window.console && console.log)
            console.log("CustomProxy.destroy(%o)", arguments);

        this.callParent(arguments);
    }
});