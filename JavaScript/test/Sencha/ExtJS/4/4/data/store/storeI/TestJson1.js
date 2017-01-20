function TestJson1()
{
	Ext.define("TestJsonModel1", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		]
	});

	Ext.define("TestJsonReader1", {
		extend: "Ext.data.reader.Json",
		alias: "reader.TestJsonReader1",
		idProperty: "id",
		root: "rows",
		successProperty: "success",
		totalProperty: "total",
		read: function(response) {
			if(window.console && console.log)
				console.log("TestJsonReader1.read()");

			var
				data = [];

			data=response;
			data.rows.push({ "name": "Record# 5", "id": 5 });
			data.total++;

			return this.callParent([data]);
		}
	});

	Ext.define("TestJsonWriter1", {
		extend: "Ext.data.writer.Json",
		alias: "writer.TestJsonWriter1",
		allowSingle: false,
		root: "rows",
		writeAllFields: false,
		write: function(request) {
			if(window.console && console.log)
				console.log("TestJsonWriter1.write()");

			return this.callParent([request]);
		},
		writeRecords: function(request, data) {
			if(window.console && console.log)
				console.log("TestJsonWriter1.writeRecords()");

			return this.callParent([request, data]);
		},
		getRecordData: function(record) {
			if(window.console && console.log)
				console.log("TestJsonWriter1.getRecordData()");

			return this.callParent([record]);
		}
	});
	
	var
		store = Ext.create("Ext.data.Store", {
			model: "TestJsonModel1",
			proxy: {
				type: "memory",
				reader: "TestJsonReader1",
				writer: "TestJsonWriter1"
			}
		}),
		data={
			success : true,
			total: 4,
			rows: [
				{ "name": "Record# 1", "id": 1 },
				{ "name": "Record# 2", "id": 2 },
				{ "name": "Record# 3", "id": 3 },
				{ "name": "Record# 4", "id": 4 }
			]
		},
		tmpRec;

	store.loadRawData(data, false);
	
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

	store.insert(0, Ext.create("TestJsonModel1", {
		//id: 6,
		name: "Record# 6"
	}));

	store.sync();
}