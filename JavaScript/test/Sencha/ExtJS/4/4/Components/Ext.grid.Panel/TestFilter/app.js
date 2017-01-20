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
		createData = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push( { id: i, name: "Record# "+i } );

			return data;
		},
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: createData(1000),
			autoDestroy: true
		}),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			columns: [
				{ dataIndex: "id", header: "id", align: "center", cls: "columnHeaderTextBold" },
				{ dataIndex: "name", header: "name", cls: "columnHeaderTextAlignCenter" /* "columnHeaderTextAlignCenterAndBold" */ }
			],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "set",
					handler: function(btn, e) {
						btn.up("grid").getStore().filter([{ property: "name", value: "123", anyMatch: true }]);
					}
				}, {
					text: "reset",
					handler: function(btn, e) {
						btn.up("grid").getStore().clearFilter();
					}
				}]
			}]
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		layout: "fit",
		height: 200,
		width: 300,
		items: [grid]
	});
});