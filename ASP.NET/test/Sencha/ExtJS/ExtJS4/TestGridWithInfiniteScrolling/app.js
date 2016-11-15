Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.require(["Ext.grid.plugin.BufferedRenderer"]);

Ext.define("TestModel", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        "name"
    ]
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
        store = Ext.create("Ext.data.Store", {
            autoLoad: true,
            model: "TestModel",
            pageSize: 25, // The grid should be bound to a store with a pageSize specified
            buffered: true, // Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time. Defaults to: false
            proxy: {
                type: "ajax",
                url: "data.aspx",
                reader: {
                    type: "json",
                    root: "rows",
                    idProperty: "id",
                    totalProperty: "total",
                    successProperty: "success",
                    messageProperty: "message"
                }
            },
            listeners: {
                beforeload: function (store, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.data.Store.beforeload(%o)", arguments);
                },
                beforeprefetch: function (store, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.data.Store.beforeprefetch(%o)", arguments);
                },
                load: function (store, records, successful, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.data.Store.load(%o)", arguments);
                },
                prefetch: function (store, records, successful, operation, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.data.Store.prefetch(%o)", arguments);
                }
            }
        }),
        grid = Ext.create("Ext.grid.Panel", {
            //region: "center",
            store: store,
            columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "name", header: "name" }
			],
            loadMask: true,
            //verticalScrollerType: "paginggridscroller", // Use a PagingGridScroller (this is interchangeable with a PagingToolbar)
            //invalidateScrollerOnRefresh: false, // do not reset the scrollbar when the view refreshs
            //disableSelection: true, // infinite scrolling does not support selection
            //viewConfig: {
            //    trackOver: false // True to enable mouseenter and mouseleave events. Defaults to: false
            //}
            plugins: "bufferedrenderer"
            //, height: 200 // Scroller isn't used without the height.
            //, width: 300
            //, renderTo: Ext.getBody()
        });

    //Ext.create("Ext.container.Viewport", {
    //    layout: "border",
    //    items: [grid]
    //});

    //store.guaranteeRange(0, store.pageSize - 1);
    //store.load();

    Ext.create("Ext.window.Window", {
        autoShow: true,
        height: 300,
        width: 300,
        layout: "fit",
        items: [grid]
    });
});