Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
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
		store = new Ext.data.Store({
			model: "TestModel",
			data: [
				{ id: 1, name: "Record# 1" },
				{ id: 2, name: "Record# 2" },
				{ id: 3, name: "Record# 3" },
				{ id: 4, name: "Record# 4" },
				{ id: 5, name: "Record# 5" }
			]
		}),
		tmpRec = Ext.create("TestModel", {
			id: 3,
			name: "Record# 33"
		}),
		storeRec = store.getById(3);

	store.each(function(r) {
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});

	storeRec.set("name", "Record# 333");
	storeRec.copyFrom(tmpRec);

	store.each(function(r) {
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});
});