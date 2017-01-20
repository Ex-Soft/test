Ext.define("TestApp.store.MainMenu", {
	extend: "Ext.data.TreeStore",
	requires: ["TestApp.model.MainMenuItem"],

	config: {
		model: "TestApp.model.MainMenuItem",
		proxy: {
			type: "ajax",
			url: "MainMenu.json"
		}
	}
});