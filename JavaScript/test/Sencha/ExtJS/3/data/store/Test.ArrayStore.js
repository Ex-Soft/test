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
						console.info("Ext.data.ArrayStore.load");
				}
			}
		}),
		data=[
			[ 1, "������ ���� ��������" ],
			[ 2, "������ ���� �������" ],
			[ 3, "������� ����� ���������" ],
			[ 4, "�������� ������� ����������" ]
		],
		data2=[
			[ 11, "������ ���� ��������" ],
			[ 21, "������ ���� �������" ],
			[ 31, "������� ����� ���������" ],
			[ 41, "�������� ������� ����������" ]
		],
		tmpRec;

	store.loadData(data);
	store.loadData(data2);

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
