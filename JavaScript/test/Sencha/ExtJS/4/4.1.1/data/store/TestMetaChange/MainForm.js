Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			fields: [],
			listeners: {
				metachange: function(store, meta, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.metachange(%o)", arguments);
				}
			}
		}),
		data = {
			success : true,
			total: 1,
			rows: [
				{ id: 1, name: "Record# 1" },
				{ id: 2, name: "Record# 2" },
				{ id: 3, name: "Record# 3" },
				{ id: 4, name: "Record# 4" }
			],
			metaData: {
				root: "rows",
				idProperty: "id",
				fields: [
					{ name: "id", type: "int" },
					"name"
				],
				columns: [
					{ dataIndex: "id", header: "id" },
					{ dataIndex: "name", header: "name" }
				]
			}
		};

	store.loadRawData(data, false);

	store.each(function(r) {
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
	});
});