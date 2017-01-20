Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"fstring1",
				"fstring2",
				"fstring3",
				{ name: "fdate", type: "date", dateFormat: "c" }
			],
			data: [
				{ id: 1, fstring1: "fstring1", fdate: "2012-10-31T15:55:13.123" },
				{ id: 2, fstring1: "fstring", fstring2: "fstring2" },
				{ id: 3, fstring1: "fstring1" },
				{ id: 4, fstring1: "fstring", fstring3: "fstring3" },
				{ id: 5, fstring1: "fstring1" }
			]
		});

	 Ext.create("Ext.grid.Panel", {
		store: store,
		columns: [
			{ header: "id", dataIndex: "id" },
			{ header: "fstring", dataIndex: "fstring", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				var
					result,
					smthExternalVar = "blah-blah-blah",
					tpl = new Ext.XTemplate(
						"<div>",
							smthExternalVar,
							" ",
							"{[smthExternalInternalVar]}",
							" ",
							"<tpl if=\"smthExternalInternalVar==&quot;blah-blah-blah&quot;\">",
								"halb-halb-halb",
							"</tpl>",
							" fstring1: {fstring1}",
							"<tpl if=\"fdate\">",
								" fdate: {fdate:date(\"d.m.Y\")}",
							"</tpl>",
							"<tpl if=\"fstring1==&quot;fstring&quot;\">",
								"<tpl if=\"fstring2\">",
									" fstring2: {fstring2}",
								"<tpl elseif=\"fstring3\">",
									" fstring3: {fstring3}",
								"</tpl>",
							"</tpl>",
						"</div>",
						{
							definitions: "var smthExternalInternalVar=\""+smthExternalVar+"\";\n"
						}
					);

				result = tpl.apply(record.data);

				return result;
			},
			flex: 1 }
		],
		renderTo: Ext.getBody()
	});
});