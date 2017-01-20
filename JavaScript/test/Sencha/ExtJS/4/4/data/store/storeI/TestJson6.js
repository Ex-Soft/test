function TestJson6()
{
	var
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"name"
			]
		}),
		data = [
			{ id: 1, name: "Record# 1" },
			{ id: 2, name: "Record# 2" },
			{ id: 3, name: "Record# 3" },
			{ id: 4, name: "Record# 4" }
		],
		tmpRec;

	store.loadData(data);

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});

	tmpRec=store.getById(3);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}
}