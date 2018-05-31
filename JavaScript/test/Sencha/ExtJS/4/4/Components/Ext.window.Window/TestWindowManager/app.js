Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.toolbar.Toolbar",{
		items: [{
			text: "create",
			handler: function(btn, e) {
				Ext.create("Ext.window.Window", {
					id: "TestWindowId",
					itemId: "TestWindowItemId",
					title: "title",
					height: 100,
					width: 300,
					autoShow: true,
					html: "html"
				});
			}
		}],
		renderTo: Ext.getBody()
	});
});
