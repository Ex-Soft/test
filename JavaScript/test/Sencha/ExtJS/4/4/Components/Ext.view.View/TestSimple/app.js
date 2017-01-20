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
			fields: [ "one", "two",	"three"	],
			data: [
				{ one: "1", two: "2", three: "3" },
				{ one: "1", two: "2", three: "3" },
				{ one: "1", two: "2", three: "3" },
				{ one: "1", two: "2", three: "3" },
				{ one: "1", two: "2", three: "3" }
			]
		}),
		tpl = new Ext.XTemplate(
			"<tpl for=\".\">",
				"<div class=\"row-wrap\">",
					"<div class=\"leftColumn\">{one}</div>",
					"<div class=\"rightColumn\">",
						"<div>{two}</div>",
						"<div>{three}</div>",
					"</div>",
				"</div>",
			"</tpl>"
		);

	 Ext.create("Ext.view.View", {
		store: store,
		tpl: tpl,
		itemSelector: "div.row-wrap",
		renderTo: Ext.getBody(),
		listeners: {
			itemdblclick: function(view, record, item, index, e, eOpts) {
				if(window.console && console.log)
					console.log("itemdblclick(%o)", arguments);
			},
			select: function(view, record, eOpts) {
				if(window.console && console.log)
					console.log("select(%o)", arguments);
			}
		}
	});
});