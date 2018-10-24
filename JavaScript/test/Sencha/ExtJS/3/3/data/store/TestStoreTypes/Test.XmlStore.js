function TestXmlStore()
{
	var
		store = new Ext.data.XmlStore({
			autoDestroy: true,
			url: "Data.xml",
			record: "row",
			idPath: "id",
			totalRecords: "total",
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			listeners: {
				load: function(store, records, options){
					if(Ext.isGecko && window.console)
						console.info("Ext.data.XmlStore.OnLoad");
				},
				exception: function(proxy, type, action, options, response){
					if(Ext.isGecko && window.console)
						console.info("Ext.data.XmlStore.OnException: arguments.length=%i",arguments.length);
				}
			}
		});

	store.load({
		callback: function(records, options, success){
			if(Ext.isGecko && window.console)
				console.info("Ext.data.XmlStore.load.callback");

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
