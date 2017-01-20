Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		TestModel = Ext.define("TestModel", {
			extend: "Ext.data.Model",
			idProperty: "id",
			fields: [
				{ name: "id", type: "int" },
				{ name: "name", mapping: 1 },
				{ name: "issmth", type: "boolean" }
			]
		}),
		data=[
			[ 1, "Record# 1", false ],
			[ 2, "Record# 2", false ],
			[ 3, "Record# 3", false ],
			[ 4, "Record# 4", false ],
			[ 5, "Record# 5", true ],
			[ 6, "Record# 5", true ]
		],
		store = new Ext.data.Store({
			model: "TestModel"
		}),
		storeBuffered = new Ext.data.Store({
			model: "TestModel",
			pageSize: 2,
			buffered: true,
			purgePageCount: 0
		}),
		records=[],
		tmpRec;

	store.loadData(data);

	if(window.console && console.log)
		console.log("All record(s)");

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	if(window.console && console.log)
		console.log("Store.getById()");

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(1): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	if(window.console && console.log)
		console.log("Store.getAt(Store.find())");

	tmpRec=store.getAt(store.find("issmth", true));
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getAt(Store.find(\"issmth\", true)): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	if(window.console && console.log)
		console.log("Store.findRecord()");

	tmpRec=store.findRecord("issmth", true);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(\"issmth\", true): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	if(window.console && console.log)
		console.log("Store.filter()");

	//store.filter("name", "Record# 3");
	//store.filter([{ property: "name", value: "Record#", exactMatch: true }]);
	store.filter([{ property: "name", value: "or", anyMatch: true }]);
	//store.filter([{ property: "name", value: "Record# 5" }, { property: "issmth", value: true }]);
	//store.filter([ Ext.create("Ext.util.Filter", { property: "name", value: "Record# 3", root: "data" }) ]);
	//store.filter([ Ext.create("Ext.util.Filter", { property: "name", value: "Record# 5", root: "data" }), Ext.create("Ext.util.Filter", { property: "issmth", value: true, root: "data" }) ]);
	//store.filter([ Ext.create("Ext.util.Filter", { filterFn: function(item) { return item.get("name")=="Record# 3" }, root: "data" }) ]);
	//store.filter([ Ext.create("Ext.util.Filter", { filterFn: function(item) { return item.get("name")=="Record# 5" && item.get("issmth") }, root: "data" }) ]);

	if(window.console && console.log)
		console.log("getCount()=%i", store.getCount());

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	store.clearFilter(true);
	store.filter([{ property: "name", value: "Record# 3" }]);

	if(window.console && console.log)
		console.log("getCount()=%i", store.getCount());

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	if(window.console && console.log)
		console.log("Store.filter([{ property: \"issmth\", value: false }])");

	store.clearFilter(true);
	store.filter([{ property: "issmth", value: false }]);

	if(window.console && console.log)
		console.log("getCount()=%i", store.getCount());

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	if(window.console && console.log)
		console.log("Store.filter([{ property: \"name\", value: \"Record# 3\" }])");

	store.filter([{ property: "name", value: "Record# 3" }]);

	if(window.console && console.log)
		console.log("getCount()=%i", store.getCount());

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});
	
	if(window.console && console.log)
		console.log("storeBuffered");

	for(var i=0, len=data.length; i<len; ++i)
		records.push(Ext.create(storeBuffered.getProxy().getModel(), data[i]));

	storeBuffered.cacheRecords(records);

	storeBuffered.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	tmpRec=storeBuffered.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getById(): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	tmpRec=storeBuffered.getAt(storeBuffered.find("issmth", true));
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.getAt(Store.find()): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	tmpRec=storeBuffered.findRecord("issmth", true);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("Store.findRecord(): id=%i name=\"%s\" issmth=%s", tmpRec.get("id"), tmpRec.get("name"), tmpRec.get("issmth"));
	}

	//storeBuffered.filter("name", "Record# 3");
	//storeBuffered.filter([{ property: "name", value: "Record# 3", root: "prefetchData" }]);
	//storeBuffered.filter([{ property: "name", value: "Record# 5" }, { property: "issmth", value: true }]);
	storeBuffered.filter([ Ext.create("Ext.util.Filter", { property: "name", value: "Record# 3", root: "prefetchData" }) ]);
	//storeBuffered.filter([ Ext.create("Ext.util.Filter", { property: "name", value: "Record# 5", root: "data" }), Ext.create("Ext.util.Filter", { property: "issmth", value: true, root: "data" }) ]);
	//storeBuffered.filter([ Ext.create("Ext.util.Filter", { filterFn: function(item) { return item.get("name")=="Record# 3" }, root: "data" }) ]);
	//storeBuffered.filter([ Ext.create("Ext.util.Filter", { filterFn: function(item) { return item.get("name")=="Record# 5" && item.get("issmth") }, root: "data" }) ]);
	//storeBuffered.filter([ Ext.create("Ext.util.Filter", { filterFn: function(item) { return item.get("name")=="Record# 5" && item.get("issmth") }, root: "prefetchData" }) ]);

	if(window.console && console.log)
		console.log("getCount()=%i", storeBuffered.getCount());

	storeBuffered.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});

	storeBuffered.clearFilter(true);
	storeBuffered.filter([{ property: "name", value: "Record# 3" }]);

	if(window.console && console.log)
		console.log("getCount()=%i", storeBuffered.getCount());

	storeBuffered.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" issmth=%s", r.get("id"), r.get("name"), r.get("issmth"));
	});
});