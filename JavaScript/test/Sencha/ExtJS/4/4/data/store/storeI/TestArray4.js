function TestArray4()
{
	var
		TestArrayModel4 = Ext.define("TestArrayModel4", {
			extend: "Ext.data.Model",
			idProperty: "name",
			fields: [
				{ name: "name", type: "string" }
			]
		}),
		store = new Ext.data.ArrayStore({
			model: "TestArrayModel4",
			data: [
				[ "Record# 1" ],
				[ "Record# 2" ],
				[ "Record# 3" ],
				[ "Record# 4" ]
			]
		}),
		tmpRec;

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("name=\"%s\"", r.get("name"));
	});

	tmpRec=store.getById("Record# 1");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): name=\"%s\"", tmpRec.get("name"));
	}

	tmpRec=store.findRecord("name", "Record# 3");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): name=\"%s\"", tmpRec.get("name"));
	}
}