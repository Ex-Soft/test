Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false,
    paths: {
    	"AM": "app"
    }
});

Ext.require([
	"AM.app.Application"
]);

Ext.onReady(function() {
	Ext.create("AM.app.Application", {
		name: 'AM',
		appFolder: 'app',
		controllers: [
			'Users'
		]
	});
});