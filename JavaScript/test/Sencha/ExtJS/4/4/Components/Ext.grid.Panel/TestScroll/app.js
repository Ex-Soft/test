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
			autoDestroy: false
		}),
		grid = Ext.create("Ext.grid.Panel", {
			store: store,
			columns: [
				{ dataIndex: "id", header: "id", width: 100, locked: false },
				{ dataIndex: "name", header: "name", width: 100 /*, locked: false */ }
			],
			viewConfig: {
				stripeRows: true
			},
			dockedItems: [{
				xtype: "toolbar",
				dock: "bottom",
				items: [{
					text: "setTitle",
					handler: function(btn, e) {
						var
							grid = btn.up("grid");

						grid.ownerCt.setTitle("Title");
					}
				}]
			}]
		}),
		w = Ext.create("Ext.window.Window", {
			layout: "fit", // !!!
			height: 200,
			width: 300,
			items: [grid]
		}),
		vp = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "west",
				layout: {
					type: "vbox",
					align: "stretch"
				},
				width: 200,
				items: [{
					xtype: "button",
					text: "Panel",
					handler: function(btn, e) {
						replaceRegionCenter(Ext.create("Ext.panel.Panel", {
							html: "Panel",
							autoDestroy: true
						}));
					}
				}, {
					xtype: "button",
					text: "Grid",
					handler: function(btn, e) {
						replaceRegionCenter(grid);
					}
				}, {
					xtype: "button",
					text: "Window",
					handler: function(btn, e) {
						w.show();
					}
				}]
			}, {
				region: "center",
				layout: "fit", // !!!
				border: false
			}]
		}),
		replaceRegionCenter = function(component)
		{
			var
				regionCenter = vp.getLayout().centerRegion;

			regionCenter.removeAll();
			regionCenter.add(component);
		};
});