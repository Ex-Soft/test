Ext.define("AM.model.User", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		"name",
		"email"
	]
});
