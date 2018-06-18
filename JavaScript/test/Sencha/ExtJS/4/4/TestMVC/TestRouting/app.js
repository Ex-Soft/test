Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.application({
    name: "TestRouting",

    appFolder: "app",

    requires: [
        "TestRouting.Router"
    ],

    controllers: [
        "TestRouting.controller.CNavPanel",
        "TestRouting.controller.CMainPanel",
        "TestRouting.controller.CSubPanel"
    ],

    stores: [
        "TestRouting.store.NavStore"
    ],

    constructor: function(config) {
        this.callParent([config]);

        this.addEvents({
            "navNodeSelected": true,
            "gridRowSelected": true
        });

        this.on("navNodeSelected", this.onNavNodeSelected, this);
        this.on("gridRowSelected", this.onGridRowSelected, this);
    },

    launch: function() {
    	if (window.console && console.log)
    		console.log("Ext.application.launch(%o)", arguments);

        TestRouting.Router.init(this);

	    Ext.create("TestRouting.view.Viewport", {
	    });
    },

    onNavNodeSelected: function() {
        if (window.console && console.log)
    		console.log("Ext.application.onNavNodeSelected(%o)", arguments);
    },

    onGridRowSelected: function() {
        if (window.console && console.log)
    		console.log("Ext.application.onGridRowSelected(%o)", arguments);
    }
});