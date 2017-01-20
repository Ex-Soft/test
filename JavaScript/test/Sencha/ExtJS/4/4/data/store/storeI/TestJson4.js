function TestJson4()
{
	if(window.console && console.log)
		console.log("TestJson4() (store.loadRawData(), Model with mapping (works))");

	Ext.define("TestJsonModel4", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int", mapping: "idid" },
			{ name: "name", type: "string", mapping: "namename" },
			{ name: "dt", type: "date", dateFormat: "c" }
		]
	});
	
	var
		store = Ext.create("Ext.data.Store", {
			model: "TestJsonModel4",
			proxy: {
				type: "memory",
				reader: {
					idProperty: "id",
					root: "rows.data",
					successProperty: "success",
					totalProperty: "total"
				}
			}
		}),
		data={
			success : true,
			total: 4,
			rows: {
				data: [
					{ namename: "Record# 1", idid: 1, dt: "2012-04-19T14:55:13.123" },
					{ namename: "Record# 2", idid: 2, dt: "2012-04-19T11:55:13.123Z" },
					{ namename: "Record# 3", idid: 3, dt: "2012-04-20T19:00:00.000" },
					{ namename: "Record# 4", idid: 4, dt: "2012-04-20T19:00:00.000Z" }
				]
			}
		},
		tmpRec;

	store.loadRawData(data, false);
	
	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" dt=%s", r.get("id"), r.get("name"), r.get("dt"));
	});

	tmpRec=store.getById(3);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\" dt=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("dt"));
	}

	tmpRec=store.findRecord("name", "Record# 1");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i name=\"%s\" dt=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("dt"));
	}
}