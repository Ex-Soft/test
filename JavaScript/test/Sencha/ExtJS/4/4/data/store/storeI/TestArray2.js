function TestArray2()
{
	if(window.console && console.log)
		console.log("TestArray2() (store.loadRawData(), Model with mapping (works))");

	var
		TestArrayModel2 = Ext.define("TestArrayModel2", {
			extend: "Ext.data.Model",
			idProperty: "id",
			fields: [
				{ name: "id", type: "int", mapping: 1 },
				{ name: "name", type: "string", mapping: 0 },
				{ name: "dt", type: "date", dateFormat: "c" }
			]
		}),
		store = new Ext.data.Store({
			model: "TestArrayModel2",
			proxy: {
				type: "memory",
				reader: { type: "array" } //new Ext.data.reader.Array({ model: "TestArrayModel2" }, TestArrayModel2)
			}
		}),
		data=[
			[ "Record# 1", 1, "2012-04-19T14:55:13.123" ],
			[ "Record# 2", 2, "2012-04-19T11:55:13.123Z" ],
			[ "Record# 3", 3, "2012-04-20T19:00:00.000" ],
			[ "Record# 4", 4, "2012-04-20T19:00:00.000Z" ]
		],
		tmpRec;

	store.loadRawData(data);
	
	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" dt=%s", r.get("id"), r.get("name"), r.get("dt"));
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\" dt=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("dt"));
	}

	tmpRec=store.findRecord("name", "Record# 3");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i name=\"%s\" dt=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("dt"));
	}
}