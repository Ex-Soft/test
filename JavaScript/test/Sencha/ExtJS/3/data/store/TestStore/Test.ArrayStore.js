function TestArrayStore()
{
	var
		rec = Ext.data.Record.create([
			{ name: "name", mapping: 1 },
			{ name: "f1", mapping: 2 },
			{ name: "f11", mapping: 3 },
			{ name: "f111", mapping: 4 }
		]),
		reader = new Ext.data.ArrayReader({
			idIndex: 0
		}, rec),
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			reader: reader,
			listeners: {
				load: function(store, records, options) {
					if(window.console && console.info)
						console.info("Ext.data.ArrayStore.load(%o)", arguments);
				},
				add: function(store, records, index) {
					if(window.console && console.info)
						console.info("Ext.data.ArrayStore.add(%o)", arguments);
				}
			}
		}),
		storeWithSorters = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				{ name: "name" },
				{ name: "f1" },
				{ name: "f11" },
				{ name: "f111" },
			],
			reader: reader,
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
						console.info("Ext.data.ArrayStore.load(%o)", arguments);
				},
				add: function(store, records, index) {
					if(window.console && console.info)
						console.info("Ext.data.ArrayStore.add(%o)", arguments);
				}
			}
		}),
		data=[
			[ 1, "Иванов Иван Иванович" ],
			[ 2, "Петров Петр Петрови" ],
			[ 3, "Сидоров Сидор Сидорович" ],
			[ 4, "Васильев Василий Василиевич" ]
		],
		data2=[
			[ 11, "Иванов Иван Иванович" ],
			[ 21, "Петров Петр Петрови" ],
			[ 31, "Сидоров Сидор Сидорович" ],
			[ 41, "Васильев Василий Василиевич" ]
		],
		data3 = [
			[ 1, "#6", "1", "1.2", "1.2.1" ],
			[ 2, "#5", "1", "1.1", "1.1.1" ],
			[ 3, "#7", "1", "1.3", "1.3.3" ],
			[ 4, "#9", "1", "1.3", "1.3.1" ],
			[ 5, "#8", "1", "1.3", "1.3.2" ],
			[ 6, "#3", "2", "2.2", "2.2.1" ],
			[ 7, "#1", "2", "2.1", "2.1.2" ],
			[ 8, "#2", "2", "2.1", "2.1.1" ],
			[ 9, "#4", "2", "2.3", "2.3.1" ]
		],
		tmpRec;

	store.loadData(data);
	store.loadData(data2);

	rec = new store.recordType({ id: 111, name: "new store.recordType()" });
	store.add(rec);

	store.each(function(r)
	{
		var
			id=r.get("id"),
			name=r.get("name");

		if(window.console && console.log)
			console.log("id=%i name=\"%s\"",id,name);
	});

	tmpRec=store.getById(1);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	tmpRec=store.getById(11);
	if(tmpRec)
	{
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", tmpRec.get("id"), tmpRec.get("name"));
	}

	storeWithSorters.loadData(data3);
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

	storeWithSorters.filter([
		{ property: "f1", value: "2", anyMatch: true, caseSensitive: false, exactMatch: false },
		{ property: "f11", value: "3", anyMatch: true, caseSensitive: false, exactMatch: false }
	]);
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
}
