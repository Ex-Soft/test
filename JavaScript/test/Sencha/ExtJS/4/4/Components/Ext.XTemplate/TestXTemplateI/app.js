Ext.onReady(function() {
	Ext.define("TestJsonModelParent", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		],
		hasMany: {
			model: "TestJsonModelChild",
			name: "children"
		},
		
		proxy: {
			type: "memory",
			reader: {
				type: "json",
				root: "rows"
			}
		}
	});

	Ext.define("TestJsonModelChild", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "name" }
		],

		belongsTo: "TestJsonModelParent"
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "TestJsonModelParent"
		}),
		data={
			"success" : true,
			"total": 4,
			"rows": [
				{ 
					"id": 1,
					"name": "Record# 1", 
					"children": [
						{ "id": 11, "name": "Record# 11" },
						{ "id": 12, "name": "Record# 12" },
						{ "id": 13, "name": "Record# 13" },
						{ "id": 14, "name": "Record# 14" }
					]
				},
				{ 
					"id": 2,
					"name": "Record# 2", 
					"children": [
						{ "id": 21, "name": "Record# 21" },
						{ "id": 22, "name": "Record# 22" },
						{ "id": 23, "name": "Record# 23" },
						{ "id": 24, "name": "Record# 24" }
					]
				},
				{ 
					"id": 3,
					"name": "Record# 3", 
					"children": [
						{ "id": 31, "name": "Record# 31" },
						{ "id": 32, "name": "Record# 32" },
						{ "id": 33, "name": "Record# 33" },
						{ "id": 34, "name": "Record# 34" }
					]
				},
				{ 
					"id": 4,
					"name": "Record# 4", 
					"children": [
						{ "id": 41, "name": "Record# 41" },
						{ "id": 42, "name": "Record# 42" },
						{ "id": 43, "name": "Record# 43" },
						{ "id": 44, "name": "Record# 44" }
					]
				}
			]
		},
		tpl1 = new Ext.XTemplate(
			"<tpl for=\".\">",
				"<div class=\"itemSelector\">",
					"<dl>",
						"<dt><dfn>{id} {name}</dfn></dt>",
						"<tpl for=\"children\">",
							"<dd>{id} {name} (parent {parent.name})</dd>",
						"</tpl>",
					"</dl>",
				"</div>",
			"</tpl>"
		),
		tpl2 = new Ext.XTemplate(
			"<tpl for=\".\">",
				"<div class=\"itemSelector\">",
					"<dl>",
						"<dt><dfn>{id} {name}</dfn></dt>",
						"<tpl for=\"children\">",
							"<dd id=\"Rec{id}\">{id} {name} (parent {parent.name})</dd>",
						"</tpl>",
					"</dl>",
				"</div>",
			"</tpl>"
		);

	store.loadRawData(data, false);

	Ext.create("Ext.view.View", {
		store: store,
		tpl: tpl1,
		itemSelector: "div.itemSelector",
		renderTo: Ext.get("div1"),
		listeners: {
			itemclick: function(view, record, item, index, e, eOpts) {
				if(window.console && console.log)
					console.log("Ext.view.View.itemclick(%o)", arguments);
			}
		}
	});

	Ext.create("Ext.view.View", {
		store: store,
		tpl: tpl2,
		itemSelector: "div.itemSelector",
		renderTo: Ext.get("div2"),
		listeners: {
			click: {
				element: "el",
				fn: function(e, t) {
					e.stopEvent();

					if(window.console && console.log)
						console.log("%s click (%o)", t.id, arguments);
				},
				options: {
					delegate: "dd"
				}
			}/*
			afterrender: function(view, eOpts) {
				view.getEl().on("click", function(e, t) {
					e.stopEvent();

					if(window.console && console.log)
						console.log("%s click", t.id);
				}, view, { delegate: "dd" });
			}*/
		}
	});
});