Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		"name"
	],
	proxy: {
		type: "memory",
		reader: {
			type: "json"
		}
	}
});

Ext.onReady(function() {
	var
		pageSize = 100,
		store = Ext.create("Ext.data.Store", {
			model: "TestModel",
			pageSize: pageSize,
			buffered: true,
			purgePageCount: 0,
			listeners: {
				add: function(store, records, index, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.add(%o)", arguments);
				},
				beforeload: function(store, operation, eOpts) {
					if(window.console && console.log)
						console.log("%i Ext.data.Store.beforeload(%o)", arguments.length, arguments);
				},
				beforeprefetch: function(store, operation, eOpts) {
					if(window.console && console.log)
						console.log("%i Ext.data.Store.beforeprefetch(%o)", arguments.length, arguments);
				},
				prefetch: function(store, operation, eOpts) {
					if(window.console && console.log)
						console.log("%i Ext.data.Store.prefetch(%o)", arguments.length, arguments);
				},
				/*datachanged: function(store, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.datachanged(%o)", arguments);
				},*/
				load: function(store, records, successful, operation, eOpts) {
					if(window.console && console.log)
						console.log("%i Ext.data.Store.load(%o)", arguments.length, arguments);
				}
			}
		}),
		data = [],
		records = [],
		i,
		maxRecords = 5000;

	for(i=0; i<maxRecords; ++i)
		data.push({ id: i, name: "Record# "+i });

	for(i=0; i<maxRecords; ++i)
		records.push(Ext.create("TestModel", data[i]));
	
	store.cacheRecords(records);

	if(window.console && console.log)
		console.log("totalCount: %i, getTotalCount(total number of Model instances that the Proxy indicates exist): %i, count(count of items in the store): %i, getCount(cached records): %i", store.totalCount, store.getTotalCount(), store.count(), store.getCount());

	var
		grid = Ext.create("Ext.grid.Panel", {
			region: "center",
			title: maxRecords,
			store: store,
			columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "name", header: "name" },
			],
			verticalScroller: {
				xtype: "paginggridscroller",
				activePrefetch: false
			},
			loadMask: true,
			disableSelection: true,
			invalidateScrollerOnRefresh: false,
			viewConfig: {
				trackOver: false
			}
			//, height: 500,
			//, width: 500,
			//, renderTo: Ext.getBody()
		});

	Ext.create("Ext.container.Viewport", {
		layout: "border",
		items: [grid]
	});

	store.guaranteeRange(0, pageSize-1);
});