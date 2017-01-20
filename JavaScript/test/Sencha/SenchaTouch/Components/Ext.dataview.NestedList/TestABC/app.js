Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("Test.model.NestedListItem", {
	extend: "Ext.data.Model",

	config: {
		fields: [
			{ name: "text", type: "string" }
		]
	}
});

Ext.application({
	launch: function() {
		if (window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.dataview.NestedList", {
			//title: "Ext.dataview.NestedList",
			docked: "left",
			width: "25%",
			/* detailCard: {
				html: "detailCard"
			},*/
			store: {
				model: "Test.model.NestedListItem",
				proxy: {
					type: "ajax",
					url: "NestedListData.json"
				},
				listeners: {
					beforeload: function(store, operation, eOpts, eventController) {
						if (window.console && console.log)
							console.log("store.beforeload(%o)", arguments);
					},
					load: function(store, records, successful, operation, eOpts, eventController) {
						if (window.console && console.log)
							console.log("store.load(%o)", arguments);
					}
				}
			}
		}));
	}
});