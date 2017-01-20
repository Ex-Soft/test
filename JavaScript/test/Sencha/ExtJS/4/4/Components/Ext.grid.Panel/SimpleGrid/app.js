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
				"fstring"
			],
			data: [
				{ id: 1, fstring: "1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890" },
				{ id: 2, fstring: "fstring" },
				{ id: 3, fstring: "fstring" },
				{ id: 4, fstring: "fstring" },
				{ id: 5, fstring: "fstring" }
			]
		}),
		colFString = new Ext.grid.column.Column({ header: "fstring", dataIndex: "fstring", style: { "white-space": "normal", color: "red" } });

	 Ext.create("Ext.grid.Panel", {
		store: store,
		columns: [
			{ header: "id", dataIndex: "id" },
			{ header: "fstring", dataIndex: "fstring", style: { whiteSpace: "normal", color: "red" } },
			colFString,
			{ header: "fstring", dataIndex: "fstring", tdCls: "multiline-content" },
			{ header: "fstring", dataIndex: "fstring", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.style = "white-space: normal;"; // applied style for DIV element
				//metaData.tdAttr = "style=\"white-space: normal;\""; // applied style for TD element

				return value;
			} }
		],
		viewConfig: {
			getRowClass: function(record, rowIndex, rowParams, store) {
				return record.get("id") === 3 ? "third" : "";
			}
		},
		renderTo: Ext.getBody()
	});
});