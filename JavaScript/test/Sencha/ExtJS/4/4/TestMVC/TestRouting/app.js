Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.application({
    name: "TestRouting",

    appFolder: "app",

    controllers: [
        "TestRouting.controller.NavPanel"
    ],

    stores: [
        "TestRouting.store.NavStore",
        "TestRouting.store.GridStore"
    ],

    launch: function() {
    	if (window.console && console.log)
    		console.log("Ext.application.launch");

	    Ext.create("TestRouting.view.Viewport", {
	    });
    }
});