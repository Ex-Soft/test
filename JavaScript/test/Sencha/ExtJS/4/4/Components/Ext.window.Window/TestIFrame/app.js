Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

﻿Ext.onReady(function() {
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
						regionCenter = btn.up("viewport").getLayout().centerRegion,
						w = Ext.create("CustomWindow", {
							//autoShow: true,
							autoDestroy: true,
							constrain: true,
							constrainTo: regionCenter.getEl(),
							renderTo: regionCenter.getEl(),
							title: "iframe",
							closeable: true,
							maximizable: false,
							resizable: false,
							height: Ext.getBody().getViewSize().height / 2,
							width: Ext.getBody().getViewSize().width / 2
						});

					w.show();
				}
			}]
		}, {
			region: "center",
			id: "regionCenter",
			html: "html"
		}]
	});
});
