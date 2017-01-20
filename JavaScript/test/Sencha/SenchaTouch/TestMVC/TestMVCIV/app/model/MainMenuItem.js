Ext.define("TestApp.model.MainMenuItem", {
	extend: "Ext.data.Model",

	config: {
		fields: [
			{ name: "text", type: "string" },
			{ name: "entity", type: "string" },
			{ name: "action", type: "string" }
		]
	}
});
