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
				"fstring4",
				{ name: "fdate", type: "date" }
			],
			data: [
				{ id: 1, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 9, 24) },
				{ id: 2, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 10, 24) },
				{ id: 3, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 11, 24) },
				{ id: 4, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2013, 0, 24) },
				{ id: 5, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2013, 1, 24) }
			]
		});

	 Ext.create("Ext.grid.Panel", {
		store: store,
		columns: [
			{ header: "id", dataIndex: "id" },
			{ header: "fstring1", dataIndex: "fstring1", columns: [
				{ header: "fstring2", dataIndex: "fstring2" },
				{ header: "fstring3", dataIndex: "fstring3" }
			]},
			{ header: "fstring4", dataIndex: "fstring4"/*, items: [
				Ext.create("Ext.form.field.Text")
			]*/},
			{ text: "fdate", dataIndex: "fdate", xtype: "datecolumn", format: "d.m.Y" },
			{ header: "fdate", dataIndex: "fdate", renderer: Ext.util.Format.dateRenderer("d.m.Y") }
		],
		renderTo: Ext.getBody()
	});
});