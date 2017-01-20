Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.container.Viewport", {
		layout: "border",
		items: [{
			region: "west",
			layout: {
				type: "vbox",
				align: "stretch"
			},
			width: 100,
			items: [{
				xtype: "button",
				text: "create",
				handler: function(btn, e) {
					var
						regionCenter = btn.up("viewport").getLayout().centerRegion;

					Ext.create("Ext.window.Window", {
						autoShow: true,
						autoDestroy: true,
						constrain: true,
						constrainTo: regionCenter.getEl(),
						renderTo: regionCenter.getEl(),
						title: "test",
						closeable: true,
						maximizable: true,
						height: 200,
						width: 200,
						html: "html"
					});
				}
			}]
		}, {
			region: "center",
			id: "regionCenter",
			html: "html"
		}]
	});
});