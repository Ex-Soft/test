function TestArray1()
{
	if(window.console && console.log)
		console.log("TestArray1() (store.loadData(), Model with mapping (doesn't work))");

	var
		TestArrayModel1 = Ext.define("TestArrayModel1", {
			extend: "Ext.data.Model",
			idProperty: "id",
			fields: [
				{ name: "id", type: "int", mapping: 1 },
				{ name: "name", type: "string", mapping: 0 },
				{ name: "dt", type: "date", dateFormat: "c" }
			]
		}),
		store = new Ext.data.Store({
			model: "TestArrayModel1"
		}),
		data=[
			[ 1, "Record# 1", "2012-04-19T14:55:13.123" ],
			[ 2, "Record# 2", "2012-04-19T11:55:13.123Z" ],
			[ 3, "Record# 3", "2012-04-20T19:00:00.000" ],
			[ 4, "Record# 4", "2012-04-20T19:00:00.000Z" ]
		],
		tmpRec;

	store.loadData(data);
	
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