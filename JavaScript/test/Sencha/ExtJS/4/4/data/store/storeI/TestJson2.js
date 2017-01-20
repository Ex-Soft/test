function TestJson2()
{
	Ext.define("TestJsonModelParent", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		],
		hasMany: {
			model: "TestJsonModelChild",
			name: "children"
		},
		
		proxy: {
			type: "memory",
			reader: {
				type: "json",
				root: "rows"
			}
		}
	});

	Ext.define("TestJsonModelChild", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		],

		belongsTo: "TestJsonModelParent"
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestJsonModelParent"
		}),
		data={
			"success" : true,
			"total": 4,
			"rows": [
				{ 
					"id": 1,
					"name": "Record# 1", 
					"children": [
						{ "id": 11, "name": "Record# 11" },
						{ "id": 12, "name": "Record# 12" },
						{ "id": 13, "name": "Record# 13" },
						{ "id": 14, "name": "Record# 14" }
					]
				},
				{ 
					"id": 2,
					"name": "Record# 2", 
					"children": [
						{ "id": 21, "name": "Record# 21" },
						{ "id": 22, "name": "Record# 22" },
						{ "id": 23, "name": "Record# 23" },
						{ "id": 24, "name": "Record# 24" }
					]
				},
				{ 
					"id": 3,
					"name": "Record# 3", 
					"children": [
						{ "id": 31, "name": "Record# 31" },
						{ "id": 32, "name": "Record# 32" },
						{ "id": 33, "name": "Record# 33" },
						{ "id": 34, "name": "Record# 34" }
					]
				},
				{ 
					"id": 4,
					"name": "Record# 4", 
					"children": [
						{ "id": 41, "name": "Record# 41" },
						{ "id": 42, "name": "Record# 42" },
						{ "id": 43, "name": "Record# 43" },
						{ "id": 44, "name": "Record# 44" }
					]
				}
			]
		},
		tmpRec;

	store.loadRawData(data, false);
	
	store.each(function(r) {
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));

		r.children().each(function(r) {
			if(window.console && console.log)
				console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
		});
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}
}