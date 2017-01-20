Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.tab.Panel", {
		items: [{
			title: "Tab# 1",
			html: "Tab# 1"
		}, {
			title: "Tab# 2",
			tabConfig: {
				title: "tabConfig.title",
				tooltip: "tabConfig.tooltip"
			},
			html: "Tab# 2"
		}],
		listeners: {
			afterrender: function(panel, eOpts) {
				var
					bar = panel.getTabBar();

				bar.add({xtype: "tbfill"});
				bar.add({xtype: "button", text: "button"});
			}
		},
		renderTo: Ext.getBody()
	});
});