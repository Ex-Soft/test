Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.form.Panel", {
		title: "Panel",
		items: [{
			xtype: "textarea",
			anchor: "100% 100%"
		}],
		renderTo: Ext.getBody()
	});
});