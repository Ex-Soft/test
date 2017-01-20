Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		"id",
		{ name: "fstring", type: "string", useNull: true },
		{ name: "fdate", type: "date", dateFormat: "c", useNull: true },
		{ name: "fint", type: "int", useNull: true },
		{ name: "ffloat", type: "float", useNull: true },
		{ name: "fboolean", type: "boolean", useNull: true },
		"fauto"
	]
}),

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = new Ext.data.Store({
			model: "TestModel"
		}),
		data=[
			[ 1, "Record# 1", "2012-04-19T14:55:13.123" ],
			[ 2, "Record# 2", "2012-04-19T11:55:13.123Z", 20 ],
			[ 3, "Record# 3", "2012-04-20T19:00:00.000", 30, 333.33 ],
			[ 4, "Record# 4", "2012-04-20T19:00:00.000Z", 40, 444.44, true ],
			[ 5, "Record# 5", "2012-11-04T07:00:00.000Z", 50, 555.55, false ],
			[ 6, "Record# 6", "2012-11-04T07:06:00.000Z", 60, 666.66, true, "2012-11-04T07:07:00.000Z" ]
		],
		tmpRec;

	store.loadData(data);

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i fstring=\"%s\" fdate=%s fint=%i ffloat=%f fboolean=%s fauto=%s", r.get("id"), r.get("fstring"), r.get("fdate"), r.get("fint"), r.get("ffloat"), r.get("fboolean"), r.get("fauto"));
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i fstring=\"%s\" fdate=%s", tmpRec.get("id"), tmpRec.get("fstring"), tmpRec.get("fdate"));
	}

	tmpRec=store.getById(3);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i fstring=\"%s\" fdate=%s", tmpRec.get("id"), tmpRec.get("fstring"), tmpRec.get("fdate"));
	}
});
