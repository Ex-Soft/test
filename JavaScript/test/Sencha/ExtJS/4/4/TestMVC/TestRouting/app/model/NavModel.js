Ext.define("TestRouting.model.NavModel", {
	extend: "Ext.data.Model",

	idProperty: "id",

	fields: [
		{ name: "id", type: "int" },
		"text",
		{ name: "leaf", type: "boolean" },
		"cls"
	]
});