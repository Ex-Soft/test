Ext.Loader.setPath("Ext.ux", "../../../../../../../ExtJS/ExtJS4/ExtJS4.1.1/examples/ux");

Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.ux.data.PagingMemoryProxy"
]);

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.define("TestModel", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name", type: "string"  },
			{ name: "smthfield", type: "int" }
		]
	});

	var
		logName = "loadData",
		maxRecordsCount = 50000,
		pageSize = 150,
		createDataArray = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push( [ i, "Record# "+i, i%10 ] );

			return data;
		},
		data = createDataArray(maxRecordsCount),
		store = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel",
			pageSize: pageSize,
			remoteSort: true,
			remoteFilter: true,
			remoteGroup: true,
			buffered: true,
			proxy: {
				type: "pagingmemory",
				reader: {
					type: "array"
				}
				//, data: data // need store.load() || store.loadPage()
			}
			//, data: data // store load data automatically
		}),
		fieldName = Ext.create("Ext.form.field.Text", {
			value: "name"
		}),
		fieldValue = Ext.create("Ext.form.field.Text", {
			value: "Record# 999"
		}),
		pageSizeValue = Ext.create("Ext.form.field.Number", {
			value: pageSize,
			minValue: 1,
			maxValue: maxRecordsCount,
			hideTrigger: true
		}),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "name", header: "name" },
				{ dataIndex: "smthfield", header: "smthfield" }
			],
			selModel: {
				pruneRemoved: false
			},
			multiSelect: true,
			viewConfig: {
				trackOver: false
			},
			features: [{
				ftype: "grouping",
				groupHeaderTpl: "{columnName}: {name} ({rows.length} Item{[values.rows.length > 1 ? \"s\" : \"\"]})"
			}],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [
					"Field's name: ",
					fieldName,
					"Field's value: ",
					fieldValue,
				{
					text: "status",
					handler: function(btn, e) {
						var
							map,
							lastIdx,
							proxy,
							reader;

						if(window.console && console.log)
						{
							console.log("%i", store.getCount());

							if(store.pageMap)
							{
								console.log("store.pageMap.length = %i", store.pageMap.length);
								for(var i=1, len=store.pageMap.length; i<=len; ++i)
								{
									if(map = store.pageMap.map[i])
									{
										console.log("map[%i].value.length = %i", i, map.value.length);
										console.log("map[%i].value[0] = { id=%i name=\"%s\" smthfield=%i }", i, map.value[0].get("id"), map.value[0].get("name"), map.value[0].get("smthfield"));
										lastIdx = map.value.length-1;
										console.log("map[%i].value[%i] = { id=%i name=\"%s\" smthfield=%i }", i, lastIdx, map.value[lastIdx].get("id"), map.value[lastIdx].get("name"), map.value[lastIdx].get("smthfield"));
									}
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
					}
				}, {
					text: "getById",
					handler: function(btn, e) {
						var
							rec = store.getById(parseInt(fieldValue.getValue(), 10));

						if(window.console && console.log)
							console.log("%o", rec);
					}
				}, {
					text: "filter",
					handler: function(btn, e) {
						store.filter([{ property: fieldName.getValue(), value: fieldValue.getValue(), anyMatch: true }]);
					}
				}, {
					text: "clearFilter",
					handler: function(btn, e) {
						store.clearFilter();
					}
				}, {
					text: "clearGrouping",
					handler: function(btn, e) {
						store.clearGrouping();
					}
				}, {
					text: "find",
					handler: function(btn, e) {
						var
							rec = store.find(fieldName.getValue(), fieldValue.getValue(), 0, true);

						if(window.console && console.log)
							console.log("%o", rec);
					}
				},
					"pageSize: ",
					pageSizeValue,
				{
					text: "set pageSize",
					handler: function(btn, e) {
						store.pageSize = pageSizeValue.getValue();
					}
				}]
			}]
		}),
		w = Ext.create("Ext.window.Window", {
			layout: "fit",
			height: 400,
			width: 1100,
			maximizable: true,
			items: [grid]
		});

	store.getProxy().data = data;

	if(window.console && console.time)
		console.time(logName);

	store.load();
	//store.loadPage(2);

	if(window.console && console.timeEnd)
		console.timeEnd(logName);

	w.show();
});