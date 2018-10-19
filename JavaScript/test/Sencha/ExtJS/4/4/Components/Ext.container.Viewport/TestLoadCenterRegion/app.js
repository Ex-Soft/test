Ext.onReady(function() {
	var
		l = function(btn, e) {
			var vp = btn.findParentByType("viewport"),
				layout = vp ? vp.getLayout() : null,
				centerRegion = layout ? layout.centerRegion : null;

			if (centerRegion)
				centerRegion.getLoader().load({ url: btn.text });
		},
		vp = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "north",
				height: 26,
				items: [{
					xtype: "button",
					text: "dataII.html",
					handler: l
				}, {
					xtype: "button",
					text: "dataIII.html",
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
