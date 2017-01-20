Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		TestModel1 = Ext.define("TestModel1", {
			extend: "Ext.data.Model",
			idProperty: "id",
			fields: [
				{ name: "id", type: "int" },
				{ name: "name", type: "string" }
			]
		}),
		TestModel2 = Ext.define("TestModel2", {
			extend: "Ext.data.Model",
			idProperty: "id",
			fields: [
				{ name: "issmth", type: "boolean" },
				{ name: "name", type: "string" },
				{ name: "id", type: "int" }
			]
		}),
		store = new Ext.data.Store({
			model: "TestModel1"
		}),
		data1=[
			[ 1, "Record# 1" ],
			[ 2, "Record# 2" ],
			[ 3, "Record# 3" ],
			[ 4, "Record# 4" ],
			[ 5, "Record# 5" ],
			[ 6, "Record# 5" ]
		],
		data2=[
			[ false, "Record# 1", 1 ],
			[ false, "Record# 2", 2 ],
			[ false, "Record# 3", 3 ],
			[ false, "Record# 4", 4 ],
			[ true, "Record# 5", 5 ],
			[ true, "Record# 5", 6 ]
		],
		tmpRec;

	//store.getProxy().setModel(TestModel1);
	store.loadData(data1);

	if(window.console && console.log)
		console.log("All record(s) (TestModel1)");

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});

	store.getProxy().setModel(TestModel2, true);
	store.loadData(data2);

	if(window.console && console.log)
		console.log("All record(s) (TestModel2)");

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});
});