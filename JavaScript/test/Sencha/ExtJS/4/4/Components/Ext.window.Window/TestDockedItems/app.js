Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		"name"
	]
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		createGrid = function() {
			return Ext.create("Ext.grid.Panel", {
				title: "titleGrid",
				store: Ext.create("Ext.data.ArrayStore", {
					model: "TestModel",
					data: [
						[ 1, "Record# 1" ],
						[ 2, "Record# 2" ],
						[ 3, "Record# 3" ],
						[ 4, "Record# 4" ]
					]
				}),
				columns: [
					{ dataIndex: "id", header: "id" },
					{ dataIndex: "name", header: "name" },
				],
				dockedItems: [{
					xtype: "toolbar",
					dock: "top",
					items: [{
						text: "Watch",
						handler: function(btn, e) {
							var
								grid = btn.up("grid");

							if(grid)
								;
						}
					}, {
						text: "add",
						handler: function(btn, e) {
							var
								grid = btn.up("grid"),
								g = createGrid();

							g.dock = "bottom";
							g.height = 100,
							grid.addDocked(g);
						}
					}, {
						text: "height",
						handler: function(btn, e) {
							var
								grid = btn.up("grid"),
								g = grid.getDockedItems("gridpanel[dock=\"bottom\"]");

							if(Ext.isArray(g)
								&& g.length > 0)
								g[0].setHeight(300);
						}
					}]
				}],
				tools: [{
					type: "plus",
					handler: function(e, target, owner, tool) {
						var
							grid = owner.up("grid");

						if(grid)
							grid.setHeight(grid.getHeight()+10);
					},
				}, {
					type: "minus",
					handler: function(e, target, owner, tool) {
						var
							grid = owner.up("grid");

						if(grid)
							grid.setHeight(grid.getHeight()-10);
					}
				}, {
					type: "close",
					handler: function(e, target, owner, tool) {
						var
							grid = owner.up("grid"),
							parentGrid = grid.up("grid");

						if(parentGrid)
							parentGrid.removeDocked(grid);
					}
				}]
			});
		};

	Ext.create("Ext.window.Window", {
		title: "title",
		autoShow: true,
		height: 500,
		width: 300,
		layout: "fit",
		items: [createGrid()],
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "Watch",
				handler: function(btn, e) {
					var
						w = btn.up("window");

					if(w)
						;
				}
			}, {
				text: "add",
				handler: function(btn, e) {
					var
						w = btn.up("window"),
						g = createGrid();

					g.dock = "bottom";
					g.height = 100;
					w.addDocked(g);
				}
			}, {
				text: "height",
				handler: function(btn, e) {
					var
						w = btn.up("window"),
						g = w.getDockedItems("gridpanel[dock=\"bottom\"]");

					if(Ext.isArray(g)
						&& g.length > 0)
						g[0].setHeight(300);
				}
			}]
		}]
	});
});