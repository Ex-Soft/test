Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "fstring", type: "string", useNull: true },
		{ name: "fdate", type: "date", dateFormat: "c", useNull: true },
		{ name: "fint", type: "int", useNull: true },
		{ name: "ffloat", type: "float", useNull: true },
		{ name: "fboolean", type: "boolean", useNull: true },
		"fauto"
	]
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		logName = "loadData",
		maxRecordsCount = 50000,
		createDataObject = function(max) {
			var
				data = [];

			for(var i=1; i<=max; ++i)
				data.push({ id: i, fstring: "Record# "+i, fdate: Ext.Date.format(new Date(), "c"), fint: i*10, ffloat: i*1.1, fboolean: i%2, fauto: Ext.Date.format(new Date, "c")});

			return data;
		},
		createDataArray = function(max) {
			var
				data = [];

			for(var i=1; i<=max; ++i)
				data.push([ i, "Record# "+i, Ext.Date.format(new Date(), "c"), i*10, i*1.1, i%2, Ext.Date.format(new Date, "c")]);

			return data;
		},
		loadData = function(store, data, logDesc) {
			var
				r;

			if(window.console && console.log)
				console.log(logDesc);

			if(window.console && console.time)
				console.time(logName);

			store.loadData(data);

			if(window.console && console.timeEnd)
				console.timeEnd(logName);

			if(window.console && console.log)
				console.log("store.getCount() = %i", store.getCount());

			if(r = store.getById(13))
			{
				if(window.console && console.log)
					console.log("id=%i fstring=\"%s\" fdate=%s fint=%i ffloat=%f fboolean=%s fauto=%s", r.get("id"), r.get("fstring"), r.get("fdate"), r.get("fint"), r.get("ffloat"), r.get("fboolean"), r.get("fauto"));
			}
		},
		dataObject = createDataObject(maxRecordsCount),
		dataArray = createDataArray(maxRecordsCount),
		storeObject = Ext.create("Ext.data.Store", {
			model: "TestModel"/*,
			proxy: {
				type: "memory",
				reader: {
					type: "json"
				}
			}*/
		}),
		storeArray = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel"/*,
			proxy: {
				type: "memory",
				reader: {
					type: "array"
				}
			}*/
		});

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "object",
			handler: function(btn, e) {
				loadData(storeObject, dataObject, btn.text);
			}
		}, {
			text: "array",
			handler: function(btn, e) {
				loadData(storeArray, dataArray, btn.text);
			}
		}, {
			text: "watch",
			handler: function(btn, e) {
				if(btn)
					;
			}
		}],
		renderTo: Ext.getBody()
	});
});
