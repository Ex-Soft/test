function TestJson3()
{
	Ext.define("TestJsonModel3", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		]
	});

	Ext.define("TestJsonReader3", {
		extend: "Ext.data.reader.Json",
		alias: "reader.TestJsonReader3",
		idProperty: "id",
		root: "rows",
		successProperty: "success",
		totalProperty: "total",
		read: function(response) {
			if(window.console && console.log)
				console.log("TestJsonReader3.read()");

			var
				data = [];

			data=response;
			data.rows.push({ "name": "Record# 5", "id": 5 });
			data.total++;

			return this.callParent([data]);
		}
	});

	Ext.define("TestJsonWriter3", {
		extend: "Ext.data.writer.Json",
		alias: "writer.TestJsonWriter3",
		allowSingle: true,
		root: "rows",
		writeAllFields: false,
		write: function(request) {
			if(window.console && console.log)
				console.log("TestJsonWriter3.write()");

			return this.callParent([request]);
		},
		writeRecords: function(request, data) {
			if(window.console && console.log)
				console.log("TestJsonWriter3.writeRecords()");

			return this.callParent([request, data]);
		},
		getRecordData: function(record) {
			if(window.console && console.log)
				console.log("TestJsonWriter3.getRecordData()");

			return this.callParent([record]);
		}
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestJsonModel3",
			proxy: {
				type: "memory",
				batchActions: false,
				model: "TestJsonModel3",
				reader: "TestJsonReader3",
				writer: "TestJsonWriter3"
			}
		}),
		data={
			"success" : true,
			"total": 4,
			"rows": [
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

	store.insert(0, Ext.create("TestJsonModel3", {
		//id: 6,
		name: "Record# 6"
	}));

	store.sync();
}