Ext.require([
	"Ext.data.*"
]);

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" },
		{ name: "fdate", type: "date", dateFormat: "c" }
	],
	proxy: {
		type: "memory",
		reader: {
			type: "json"
		}
	}
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	TestModel.setFields(TestModel.getFields().concat([
		{ name: "addField1", type: "int", useNull: true }
	]));

	var
		r = Ext.create("TestModel", {
			id: 1,
			name: "Record# 1",
			fdate: new Date(2012,8,25,9,13,13,13)
		});

	if(window.console && console.log)
		console.log("%o", r);
});

