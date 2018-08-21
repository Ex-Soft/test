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

	var tp = Ext.create("Ext.tree.Panel", {
		title: "Ext.tree.Panel",
		rootVisible: false,
		useArrows: true,
		height: 500,
		width: 900,
		renderTo: Ext.getBody(),
		store: Ext.create("Ext.data.TreeStore", {
			proxy: {
				type: "ajax",
				url: "getData.php"
				//url: "getDataWithRoot.php"
			},
			listeners: {
				beforeexpand: function () {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.beforeexpand(%o)", arguments);
				},
				expand: function (parent, records, suppressEvent, listeners) {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.expand(%o)", arguments);
				},
				load: function () {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.load(%o)", arguments);
				}
			}
		}),
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "getRootNode()",
				handler: function(btn, e) {
					var
						treePanel,
						rootNode;

					if (!(treePanel = btn.up("treepanel"))) {
						return;
					}

					rootNode = treePanel.getRootNode();
				}
			}]
		}]
	});
});