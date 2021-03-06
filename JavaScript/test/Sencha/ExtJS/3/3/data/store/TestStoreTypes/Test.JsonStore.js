function TestJsonStore()
{
	var
        data = [
            { id: "1", value: "Rec# 1" },
            { id: "2", value: "Rec# 2" },
			{ id: "3", value: "Rec# 3" },
			{ id: "4", value: "tag" }
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
		field;

	field = store.fields.get("value");

	store.loadData(data);

	store.filter("value", new RegExp("(?!^tag$)(^.*$)", "i"));
	store.filter("id", 1);
	store.filter({ fn: function(record) { return record.get("id") == 2; }});
}
