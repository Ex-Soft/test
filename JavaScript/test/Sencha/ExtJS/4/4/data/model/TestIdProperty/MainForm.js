Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "ID",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
	]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		r = Ext.create("TestModel", {
			id: 1,
			name: "Record# 1"
		});

	if(window.console && console.log)
		console.log("%o", r);
});

