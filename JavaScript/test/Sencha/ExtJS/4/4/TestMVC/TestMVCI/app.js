Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.application({
    name: 'AM',

    appFolder: 'app',

    controllers: [
        'Users'
    ],

    launch: function() {
    	if (window.console && console.log)
    		console.log("Ext.application.launch");

	Ext.create('AM.view.Viewport', {
	});
    }
});