Ext.Loader.setPath("Ext.ux", "../../../../../../../../../ExtJS/ExtJS4/ExtJS4.1.1/examples/ux");

Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.ux.data.PagingMemoryProxy"
]);

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
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
		maxRecordsCount = 100,
		pageSize = 20,
		createData = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push( [ i, "Record# "+i ] );

			return data;

		},
		store = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel",
			buffered: true,
			pageSize: pageSize,
			remoteFilter: true,
			proxy: {
				type: "pagingmemory",
				reader: {
					type: "array"
				}
			},
			listeners: {
				beforeload: function(store, operation, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.AbstractStore.beforeload(%o)", arguments);
				},
				beforeprefetch: function (store, operation, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.beforeprefetch(%o)", arguments);
				}
			}
		});

	store.getProxy().data = createData(maxRecordsCount);

	if(window.console && console.time)
		console.time(logName);

	store.load();

	if(window.console && console.timeEnd)
		console.timeEnd(logName);

	Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "name",
		queryMode: "remote",
		editable: true,
		pageSize: pageSize,
		minChars: 0,
		width: 300,
		listeners: {
			beforequery: function(queryEvent, eOpts) {
				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.beforequery(%o)", arguments);
			}
		},
		renderTo: Ext.getBody()
	});
});