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

	var
		p = Ext.create("Ext.form.Panel", {
			title: "Panel",
			border: 0,
			items: [{
				xtype: "textarea",
				anchor: "100% 100%" // "100% -47"
			}]
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		width: 500,
		height: 300,
		layout: "fit",
		items: [p]
	});
});