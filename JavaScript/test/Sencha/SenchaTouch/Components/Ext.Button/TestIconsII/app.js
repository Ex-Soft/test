Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	launch: function() {
		if (window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.Container", {
			fullscreen: true,
			layout: "hbox",
			items: [{
				xtype: "container",
				flex: 1,
				defaults: {
					xtype: "button"
				},
				items: [
					{ iconCls: "iconNewDoc", ui: "action" }
				]
			}]
		}));
	}
});