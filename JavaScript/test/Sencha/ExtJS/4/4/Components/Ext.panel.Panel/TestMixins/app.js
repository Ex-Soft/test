Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.create("TestPanel1", {
		renderTo: Ext.getBody()
	});

	Ext.create("TestPanel2", {
		renderTo: Ext.getBody()
	});
});
