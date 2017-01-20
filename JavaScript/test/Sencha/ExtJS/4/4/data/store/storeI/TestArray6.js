function TestArray6()
{
	if(window.console && console.log)
		console.log("TestArray6()");

	Ext.define("TestArrayModel6", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name", type: "string"  },
			{ name: "smthfield", type: "int" }
		]
	});

	var
		maxRecordsCount = 5,
		createData = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push([ i, "Record# "+i, i%10 ]);

			return data;
		},
		data = createData(maxRecordsCount),
		store = new Ext.data.ArrayStore({
			model: "TestArrayModel6",
			proxy: {
				type: "memory",
				reader: {
					type: "array"
				}
			}
		}),
		tmpRec;

	store.loadData(data);

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" smthfield=%i", r.get("id"), r.get("name"), r.get("smthfield"));
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" smthfield=%i", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("smthfield"));
	}

	tmpRec=store.findRecord("name", "Record# 3");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i name=\"%s\" smthfield=%i", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("smthfield"));
	}
}