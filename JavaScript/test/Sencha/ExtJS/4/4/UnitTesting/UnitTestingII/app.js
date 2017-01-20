Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "App",

	extend: "App.Application",

	autoCreateViewport: true
});
