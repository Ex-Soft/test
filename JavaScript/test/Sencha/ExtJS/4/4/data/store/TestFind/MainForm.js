Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = new Ext.data.Store({
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: [
				{ id: 1, name: "Record# 1" },
				{ id: 2, name: "Record# 2" },
				{ id: 3, name: "Record# 3" },
				{ id: 4, name: "Record# 4" },
				{ id: 5, name: "Record# 5" },
				{ id: 6, name: "Record# 5" }
			]
		}),
		idx,
		tmpRec;

	idx = store.find("name", "rec" /* startIndex=0, anyMatch=false, caseSensitive=false, exactMatch=false */ );
	tmpRec=store.getAt(idx);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Ext.data.Store.find(\"name\", \"rec\"): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	idx = store.find("name", "rec", 4);
	tmpRec=store.getAt(idx);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Ext.data.Store.find(\"name\", \"rec\", 4): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	idx = store.find("name", "ec", 0, true);
	tmpRec=store.getAt(idx);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Ext.data.Store.find(\"name\", \"ec\", 0, true): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	idx = store.find("name", "Rec", 0, false,  true);
	tmpRec=store.getAt(idx);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Ext.data.Store.find(\"name\", \"Rec\", 0, false, true): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	idx = store.find("name", "Record# 3", 0, false, false, true);
	tmpRec=store.getAt(idx);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Ext.data.Store.find(\"name\", \"Record# 3\", 0, false, false, true): id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}
});