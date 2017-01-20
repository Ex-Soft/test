Ext.onReady(function() {
	var
		l = function(btn, e) {
			btn.ownerCt.ownerCt.getLayout().regions.center.getLoader().load({ url: btn.text });
		},
		vp = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "north",
				height: 26,
				items: [{
					xtype: "button",
					text: "DataII.html",
					handler: l
				}, {
					xtype: "button",
					text: "DataIII.html",
					handler: l
				}]
			}, {
				region: "center",
				id: "regionCenter",
				loader: {
					url: "dataI.html",
					autoLoad: true
				}
			}]
		});
});
