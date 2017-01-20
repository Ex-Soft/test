function TestRecord1()
{
	Ext.define("TestRecordModel1", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		],
		proxy: {
			type: "memory",
			reader: {
				type: "json"
			}
		}
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestRecordModel1"
			, buffered: true
		}),
		data = [
			{ "name": "Record# 1", "id": 1 },
			{ "name": "Record# 2", "id": 2 },
			{ "name": "Record# 3", "id": 3 },
			{ "name": "Record# 4", "id": 4 }
		],
		records = [],
		tmpRec;

	for(var i=0; i<data.length; ++i)
		records.push(Ext.create("TestRecordModel1", data[i]));

	store.loadRecords(records);
	
	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	store.insert(0, Ext.create("TestRecordModel1", {
		//id: 6,
		name: "Record# 6"
	}));

	store.sync();
}