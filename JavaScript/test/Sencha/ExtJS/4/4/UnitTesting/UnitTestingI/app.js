Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "UnitTestingI",

	extend: "UnitTestingI.Application",

	autoCreateViewport: true
});
