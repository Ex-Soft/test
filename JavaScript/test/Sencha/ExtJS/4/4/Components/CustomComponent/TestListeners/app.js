Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	var
		p = Ext.create("TestPanelI", {
			renderTo: Ext.getBody()
		});
});
