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

Ext.define("Test.store.NestedListStore", {
	extend: "Ext.data.TreeStore",

	config: {
		model: "Test.model.NestedListItem",
		proxy: {
			type: "ajax",
			url: "NestedListData.json"
		}
	}
});

Ext.application({
	launch: function() {
		if (window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.dataview.NestedList", {
			docked: "left",
			width: "25%",
			store: { xclass: "Test.store.NestedListStore" }
		}));
	}
});