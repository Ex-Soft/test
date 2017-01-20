Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestGridWithTemplateColumn", {
	extend: "Ext.grid.Panel",

	initComponent: function() {
		this.columns = [
			{ header: "one (with renderer)", dataIndex: "one", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				if(window.console && console.log)
					console.log("renderer(%o)", arguments);

				return value;
			} },
			{ text: "one", xtype: "templatecolumn", tpl: "{one}" },
			{ text: "two+three", xtype: "templatecolumn", tpl: "<div>{two}</div><div>{three}</div>" },
			{ text: "four+five", xtype: "templatecolumn", tpl: new Ext.XTemplate(
				"<div>{four:this.frmString(\"four\")}</div><div>{five:this.frmString(\"five\")}</div><div>{[myVarInDefinitions]}</div>",
				{
					definitions: "var myVarInDefinitions=\"" + this.id + "\";\n",
					frmString: function(val, add) {
						return val.toUpperCase()+add;
					}
				}
			), flex: 1 }
		];

		//this.hideHeaders = true;

		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			fields: [ "one", "two", "three", "four", "five" ],
			data: [
				{ one: "1", two: "2", three: "3", four: "four", five: "five" },
				{ one: "1", two: "2", three: "3", four: "four", five: "five" },
				{ one: "1", two: "2", three: "3", four: "four", five: "five" },
				{ one: "1", two: "2", three: "3", four: "four", five: "five" },
				{ one: "1", two: "2", three: "3", four: "four", five: "five" }
			]
		});

	 Ext.create("Ext.grid.Panel", {
		store: store,
		//hideHeaders: true,
		columns: [
			{ header: "one (with renderer)", dataIndex: "one", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				if(window.console && console.log)
					console.log("renderer(%o)", arguments);

				return value;
			} },
			{ text: "one", xtype: "templatecolumn", tpl: "{one}" },
			{ text: "two+three", xtype: "templatecolumn", tpl: "<div>{two}</div><div>{three}</div>" },
			{ text: "four+five", xtype: "templatecolumn", tpl: new Ext.XTemplate(
				"<div>{four:this.frmString(\"four\")}</div><div>{five:this.frmString(\"five\")}</div><div>{[myVarInDefinitions]}</div>",
				{
					currentStore: store,
					definitions: "var myVarInDefinitions=\"blah-blah-blah\";\n",
					frmString: function(val, add) {
						return val.toUpperCase()+add;
					}
				}
			), flex: 1 }
		],
		renderTo: Ext.get("div1")
	});

	Ext.create("TestGridWithTemplateColumn", {
		id: "TestGridWithTemplateColumn",
		store: store,
		renderTo: Ext.get("div2")
	});
});