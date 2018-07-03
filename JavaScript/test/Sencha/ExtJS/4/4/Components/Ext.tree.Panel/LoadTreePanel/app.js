Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.def

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.tree.Panel", {
		title: "Ext.tree.Panel",
		height: 500,
		width: 900,
		store: Ext.create("Ext.data.TreeStore", {
			root: {
				expanded: false,
				id: "root",
				text: "/"
			},
			proxy: {
				type: "ajax",
				url: "getData.php"
			}
		}),
		rootVisible: true,
		useArrows: true,
		renderTo: Ext.getBody(),
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "watch",
				handler: function(btn, e) {
					var
						store = btn.up("treepanel").getStore();

					if(store)
						;
				}
			}]
		}]
	});
});