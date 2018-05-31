Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.panel.Panel"
]);

Ext.onReady(function() {
	var
		p = Ext.create("Ext.panel.Panel", {
			renderTo: Ext.getBody(),
			html: "Ext.panel.Panel"
		});
});
