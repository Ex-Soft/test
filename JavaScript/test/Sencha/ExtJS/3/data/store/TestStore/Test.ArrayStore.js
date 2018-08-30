function TestArrayStore()
{
	var
		rec = Ext.data.Record.create([
			{ name: "name", mapping: 1 }
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
}
