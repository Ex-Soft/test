Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = new Ext.data.Store({
			fields: [
				{ name: "id", type: "int" },
				"name",
				{ name: "fieldFilter", type: "int" },
				{ name: "fieldSort", type: "int" }
			],
			data: [
				{ id: 1, name: "Record# 1", fieldFilter: 0, fieldSort: 1 },
				{ id: 2, name: "Record# 2", fieldFilter: 1, fieldSort: 2 },
				{ id: 3, name: "Record# 3", fieldFilter: 0, fieldSort: 3 },
				{ id: 4, name: "Record# 4", fieldFilter: 1, fieldSort: 4 },
				{ id: 5, name: "Record# 5", fieldFilter: 0, fieldSort: 5 }
			]
		}),
		sorters;

	store.filter([{ property: "fieldFilter", value: 0 }]);

	store.filters.each(function(item, index, len) {
		if(window.console && console.log)
			console.log("{ property: \"%s\", value: \"%s\" }", item.property, item.value);
	});

	store.filter([ { property: "name", value: "Record# 3" } ]);

	store.filters.each(function(item, index, len) {
		if(window.console && console.log)
			console.log("{ property: \"%s\", value: \"%s\" }", item.property, item.value);
	});

	
	if(window.console && console.log)
		console.log("Without sorting");

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});

	if(window.console && console.log)
		console.log("ASC");

	sorters = store.sort([{ property: "fieldSort", direction: "ASC" }]);
	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});
	store.sorters.clear();

	if(window.console && console.log)
		console.log("DESC");

	sorters = store.sort([{ property: "fieldSort", direction: "DESC" }]);
	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});
	store.sorters.clear();
	store.sort();

	if(window.console && console.log)
		console.log("Without sorting");

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});
		
	store.clearFilter(true);
});