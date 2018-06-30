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
            "navPanelReady": true,
            "navNodeSelected": true,
            "routechanged": true,
            "gridrowselected": true,
            "routeparamschanged": true,
            "gridsearch": true
        });
    },

    launch: function() {
    	if (window.console && console.log)
    		console.log("Ext.application.launch(%o)", arguments);

        TestRouting.Router.init(this);

	    Ext.create("TestRouting.view.Viewport", {
	    });
    }
});