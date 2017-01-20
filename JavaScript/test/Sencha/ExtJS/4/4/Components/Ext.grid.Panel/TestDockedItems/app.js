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
		store = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel",
			data: [
				[ 1, "Record# 1" ],
				[ 2, "Record# 2" ],
				[ 3, "Record# 3" ],
				[ 4, "Record# 4" ]
			]
		}),
		grid = Ext.create("Ext.grid.Panel", {
			title: "titleGrid",
			region: "center",
			store: store,
			columns: [
				{ dataIndex: "id", header: "id" },
				{ dataIndex: "name", header: "name" },
			]
		}),
		vp = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "west",
				layout: {
					type: "vbox",
					align: "stretch"
				},
				width: 100,
				items: [{
					xtype: "button",
					text: "Watch",
					handler: function(btn, e) {
						if(vp)
							;
					}
				}, {
					xtype: "button",
					text: "Panel2",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
					}
				}, {
					xtype: "button",
					text: "Panel3",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
					}
				}]
			},
				grid
			]
		});
});