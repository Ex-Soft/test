function TestStore()
{
	var
		rec = Ext.data.Record.create([
			{ name: "id", type: "int", mapping: "id" },
			{ name: "name" }
		]),
		reader = new Ext.data.XmlReader({
			record: "row",
			totalProperty: "total",
			idProperty: "id",
			idPath: "id",
			id: "id"
		}, rec),
		proxy = new Ext.data.HttpProxy({
			url: "Data.xml"
		}),
		store = new Ext.data.Store({
			autoDestroy: true,
			reader: reader, 
			//proxy: proxy,
			url: "Data.xml",
			listeners: {
				load: function(store, records, options){
					if(Ext.isGecko && window.console)
						console.info("Ext.data.Store.load");
				}
			}
		});

	store.load({
		callback: function(records, options, success){
			if(Ext.isGecko && window.console)
				console.info("Ext.data.Store.load.callback");

			store.each(function(r)
			{
				var
					id=r.get("id"),
					name=r.get("name");

				if(Ext.isGecko && window.console)
				console.log("id=%i name=\"%s\"",id, name);
			});
		}
	});
}
