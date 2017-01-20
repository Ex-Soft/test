Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "fstring", type: "string", useNull: true },
		{ name: "fdate", type: "date", dateFormat: "c", /*convert: null,*/ useNull: true },
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
		getData = function(max, dateInString) {
			var
				data = [],
				dt = new Date();

			for(var i=1; i<=max; ++i)
				data.push([ i, "Record# "+i, dateInString ? Ext.Date.format(dt, "c") : dt, i*10, i*1.1, i%2, dateInString ? Ext.Date.format(dt, "c") : dt]);

			return data;
		},
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
		tmpRec,
		logName = "loadData";

	if(window.console && console.time)
		console.time(logName);

//	store.loadData(data);
	store.loadData(getData(50000, true));

	if(window.console && console.timeEnd)
		console.timeEnd(logName);

	if(store.getCount()<10)
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

	tmpRec=store.findRecord("fstring", "Record# 4");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i fstring=\"%s\" fdate=%s", tmpRec.get("id"), tmpRec.get("fstring"), tmpRec.get("fdate"));
	}

	tmpRec=store.findRecord("fdate", Ext.Date.parse("2012-04-20T19:00:00.000", "c"));
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i fstring=\"%s\" fdate=%s", tmpRec.get("id"), tmpRec.get("fstring"), tmpRec.get("fdate"));
	}
});
