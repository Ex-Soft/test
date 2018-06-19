Ext.define("TestRouting.model.NavModel", {
	extend: "Ext.data.Model",

	idProperty: "id",

	fields: [
		{ name: "id", type: "int" },
		"text",
		{ name: "parentId", type: "int" },
		{ name: "leaf", type: "boolean" },
		"cls",
		{ name: "expanded", type: "boolean" },
		"category"
	],

	proxy: {
		type: "ajax",
		url: "data/navdata.json",
		reader: {
			type: "json",
			root: "children"
		}
	},

	hasMany: {
		model: "NavModel",
		name: "children"
	},

	belongsTo: "NavModel"
});