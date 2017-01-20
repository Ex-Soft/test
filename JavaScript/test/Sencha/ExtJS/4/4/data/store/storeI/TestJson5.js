function TestJson5()
{
	var
		idProperty = "id", // "id" only!!!
		createData = function() {
			var
				data = [],
				o;

			for(var i=1; i<5; ++i)
			{
				o = { name: "Record# "+i };
				o[idProperty] = "ID"+i;

				data.push(o);
			}

			return data;
		},
		store = Ext.create("Ext.data.Store", {
			//idProperty: idProperty, // doesn't work
			fields: [
				{ name: idProperty, type: "string" },
				{ name: "name", type: "string" }
			],
			data: createData()
		}),
		tmpRec;

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("%s=\"%s\" name=\"%s\"", idProperty, r.get(idProperty), r.get("name"));
	});

	tmpRec=store.getById("ID3");
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(\"ID3\"): %s=\"%s\" name=\"%s\"", idProperty, tmpRec.get(idProperty), tmpRec.get("name"));
	}
}