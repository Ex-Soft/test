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
				{ name: "name", type: "string" }
			]
		}),
		store = new Ext.data.Store({
			model: "TestModel",
			proxy: {
				type: "memory",
				reader: {
					type: "array",
					root: "data",
					successProperty: "success",
					totalProperty: "total",
					messageProperty: "message"
				}/*,
				listeners: {
					metachange: function(store, meta, eOpts) {
						if(window.console && console.log)
							console.log("Ext.data.proxy.Proxy.metachange(%o)", arguments);
					}
				}*/
			}/*,
			listeners: {
				metachange: function(store, meta, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.metachange(%o)", arguments);
				}
			}*/
		}),
		data = {
			metaData: {
				fields: [
					{ name: "id", type: "int" },
					{ name: "name", type: "string" },
					{ name: "additionalField", type: "string" }
				]
			},
			success: true,
			total: 5,
			message: "message",
			data: [
				[ 1, "Record# 1", "additionalField# 1" ],
				[ 2, "Record# 2", "additionalField# 2" ],
				[ 3, "Record# 3", "additionalField# 3" ],
				[ 4, "Record# 4", "additionalField# 4" ],
				[ 5, "Record# 5", "additionalField# 5" ]
			]
		};

	store.loadRawData(data);

	store.each(function(r)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\" additionalField=\"%s\"", r.get("id"), r.get("name"), r.get("additionalField"));
	});
});