Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "AM",

	appFolder: "app",

	controllers: [ "Base", "Derived" ],

	launch: function() {
		Ext.create("AM.view.Viewport", {
		});
	}
});