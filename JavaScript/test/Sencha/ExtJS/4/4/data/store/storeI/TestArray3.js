// http://stackoverflow.com/questions/6725453/how-to-create-ext-data-store-from-an-unusal-json-store

function TestArray3()
{
	Ext.define("TestArrayModel3", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int", mapping: 1 },
			{ name: "name", mapping: 0 }
		]
	});

	Ext.define("TestArrayReader3", {
		extend: "Ext.data.reader.Array",
		alias: "reader.TestArrayReader3",
		read: function(response) {
			if(window.console && console.log)
				console.log("TestArrayReader3.read()");

			var
				data = [];

			data=response;
			data.push([ "Record# 5", 5 ]);

			return this.callParent([data]);
		},
		buildExtractors: function() {
			if(window.console && console.log)
				console.log("TestArrayReader3.buildExtractors()");

			this.callParent(arguments);
		}
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestArrayModel3",
			proxy: {
				type: "memory",
				reader: "TestArrayReader3"
			}
		}),
		data=[
			[ "Record# 1", 1 ],
			[ "Record# 2", 2 ],
			[ "Record# 3", 3 ],
			[ "Record# 4", 4 ]
		],
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
}