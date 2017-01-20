[
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
					" ",
					"<tpl if=\"this.isEqual(&quot;blah-blah-blah&quot;)\">",
						"{[this.toUpperCase(\"halb-halb-halb\")]}",
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
					definitions: "var smthExternalInternalVar=\""+smthExternalVar+"\";\n",
					isEqual: function(val) {
						var
							result = false;

						if(window.console && console.log)
							console.log("typeof smthExternalVar = \"%s\"", typeof smthExternalVar);

						if(Ext.isDefined(smthExternalVar))
						{
							if(window.console && console.log)
								console.log("smthExternalVar = \"%s\", val = \"%s\"", smthExternalVar, val);

							result = smthExternalVar===val;
						}

						return result;
					},
					toUpperCase: function(val) {
						return val.toUpperCase();
					}
				}
			);

		result = tpl.apply(record.data);

		return result;
	},
	flex: 1 }
]