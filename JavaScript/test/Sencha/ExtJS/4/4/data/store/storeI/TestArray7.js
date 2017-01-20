function TestArray7()
{
	if(window.console && console.log)
		console.log("TestArray7()");

	Ext.define("TestArrayModel7", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name", type: "string"  },
			{ name: "smthfield", type: "int" }
		]
	});

	var
		maxRecordsCount = 30000,
		pageSize = maxRecordsCount,
		createData = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push([ i, "Record# "+i, i%10 ]);

			return data;
		},
		data = createData(maxRecordsCount),
		store = new Ext.data.ArrayStore({
			model: "TestArrayModel7",
			buffered: true,
			pageSize: pageSize,
			proxy: {
				type: "memory",
				reader: {
					type: "array"
				}
			}
		}),
		map,
		lastIdx,
		tmpRec,
		proxy,
		reader;

	store.getProxy().data = data;
	//store.load();
	store.loadPage(1);

	if(window.console && console.log)
	{
		if(store.pageMap)
		{
			console.log("store.pageMap.length = %i", store.pageMap.length);
			for(var i=1, len=store.pageMap.length; i<=len; ++i)
			{
				map = store.pageMap.map[i];
				console.log("map[%i].value.length = %i", i, map.value.length);
				console.log("map[%i].value[0] = { id=%i name=\"%s\" smthfield=%i }", i, map.value[0].get("id"), map.value[0].get("name"), map.value[0].get("smthfield"));
				lastIdx = map.value.length-1;
				console.log("map[%i].value[%i] = { id=%i name=\"%s\" smthfield=%i }", i, lastIdx, map.value[lastIdx].get("id"), map.value[lastIdx].get("name"), map.value[lastIdx].get("smthfield"));
			}
		}

		proxy=store.getProxy();
		console.log("proxy.data %s= data", proxy.data==data?"=":"!");
		console.log("proxy.data %s== data", proxy.data===data?"=":"!");
		reader=proxy.getReader();
		console.log("proxy.reader.jsonData %s= data", reader.jsonData==data?"=":"!");
		console.log("proxy.reader.jsonData %s== data", reader.jsonData===data?"=":"!");
		console.log("proxy.reader.jsonData %s= proxy.data", reader.jsonData==proxy.data?"=":"!");
		console.log("proxy.reader.jsonData %s== proxy.data", reader.jsonData===proxy.data?"=":"!");
		console.log("proxy.reader.rawData %s= data", reader.rawData==data?"=":"!");
		console.log("proxy.reader.rawData %s== data", reader.rawData===data?"=":"!");
		console.log("proxy.reader.rawData %s= proxy.data", reader.rawData==proxy.data?"=":"!");
		console.log("proxy.reader.rawData %s== proxy.data", reader.rawData===proxy.data?"=":"!");
	}
/*
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
	}*/
}