Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
        data1 = [
            { id:"1", value:"Rec# 1" },
            { id:"2", value:"Rec# 2" },
			{ id:"3", value:"Rec# 3" }
        ],
		store = new Ext.data.JsonStore({
            autoDestroy: true,
			fields: [
                { name: "id", type: "int" },
                { name: "value" }
            ],
			listeners: {
				load: function(store, records, options){
					if(window.console && console.log)
						console.info("Ext.data.JsonStore.load(%o)", arguments);
				}
			}
		}),
		data2 = [
			{ id:1, name:"#6", f1:"1", f11:"1.2", f111:"1.2.1" },
			{ id:2, name:"#5", f1:"1", f11:"1.1", f111:"1.1.1" },
			{ id:3, name:"#7", f1:"1", f11:"1.3", f111:"1.3.3" },
			{ id:4, name:"#9", f1:"1", f11:"1.3", f111:"1.3.1" },
			{ id:5, name:"#8", f1:"1", f11:"1.3", f111:"1.3.2" },
			{ id:6, name:"#3", f1:"2", f11:"2.2", f111:"2.2.1" },
			{ id:7, name:"#1", f1:"2", f11:"2.1", f111:"2.1.2" },
			{ id:8, name:"#2", f1:"2", f11:"2.1", f111:"2.1.1" },
			{ id:9, name:"#4", f1:"2", f11:"2.3", f111:"2.3.1" }
		],
		storeWithSorters = new Ext.data.JsonStore({
			autoDestroy: true,
			fields: [
				{ name: "id", type: "int" },
				{ name: "name" },
				{ name: "f1" },
				{ name: "f11" },
				{ name: "f111" },
			],
			hasMultiSort: true,
			multiSortInfo: {
				sorters: [{
					field: "f1",
					direction: "DESC"
				}, {
					field: "f11",
					direction: "ASC"
				}, {
					field: "f111",
					direction: "DESC"
				}]
			},
			listeners: {
				load: function(store, records, options) {
					if(window.console && console.info)
						console.info("Ext.data.JsonStore.load(%o)", arguments);
				},
				add: function(store, records, index) {
					if(window.console && console.info)
						console.info("Ext.data.JsonStore.add(%o)", arguments);
				}
			}
		}),
		record,
		tmp,
		isStore = function (store) {
			var result = false;

			for (var c = store; c && c.constructor; c = c.constructor.superclass) {
				if (result = c.constructor.xtype == "store") {
					break;
				}
			}

			return result;
		};

	tmp = store.constructor.xtype;
	tmp = store.constructor.superclass.constructor.xtype;
	tmp = isStore(store);

	store.loadData(data1);

	record = new store.recordType({ id:999, value:"new store.recordType()" }, "999");
	if ((tmp = store.indexOfId("3")) != -1)
		store.insert(tmp + 1, record);

	if (record = store.getById("1")) {
		tmp = record.get("id");
	}

	store.filter("id", "1");

	store.filter({
		fn: function(record) {
			return record.get("id") == "2";
		}
	});

	storeWithSorters.loadData(data2);
	storeWithSorters.each(function(r)
	{
		var
			id = r.get("id"),
			name = r.get("name"),
			f1 = r.get("f1"),
			f11 = r.get("f11"),
			f111 = r.get("f111");

		if(window.console && console.log)
			console.log("id=%i name=\"%s\" f1=\"%s\" f11=\"%s\" f111=\"%s\"", id, name, f1, f11, f111);
	});

	record = new storeWithSorters.recordType({ id:999, name:"new store.recordType(999)", f1:"1", f11:"1.3", f111:"1.3.4" }, 999);
	if ((tmp = storeWithSorters.indexOfId(7)) != -1)
	storeWithSorters.insert(tmp + 1, record);
	storeWithSorters.each(function(r)
	{
		var
			id = r.get("id"),
			name = r.get("name"),
			f1 = r.get("f1"),
			f11 = r.get("f11"),
			f111 = r.get("f111");

		if(window.console && console.log)
			console.log("id=%i name=\"%s\" f1=\"%s\" f11=\"%s\" f111=\"%s\"", id, name, f1, f11, f111);
	});

	tmp = [{ id:998, name:"new store.recordType(998)", f1:"1", f11:"1.3", f111:"1.3.5" }];
	storeWithSorters.loadData(tmp, true);

	record = new storeWithSorters.recordType({ id:997, name:"new store.recordType(997)", f1:"1", f11:"1.3", f111:"1.3.6" }, 997);
	storeWithSorters.addSorted(record);
	storeWithSorters.each(function(r)
	{
		var
			id = r.get("id"),
			name = r.get("name"),
			f1 = r.get("f1"),
			f11 = r.get("f11"),
			f111 = r.get("f111");

		if(window.console && console.log)
			console.log("id=%i name=\"%s\" f1=\"%s\" f11=\"%s\" f111=\"%s\"", id, name, f1, f11, f111);
	});
});
