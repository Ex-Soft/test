Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		viewport = new Ext.Viewport({
			id: "idViewportId",
			layout: "border",
			items: [{
				region: "north",
				height: 25,
				xtype: "toolbar",
				items: [{
					text: "getViewPort",
					handler: function (btn, e) {
						var vp = btn.findParentByType("viewport"),
							layout = vp ? vp.getLayout() : null,
							center = vp ? Ext.fly(layout.center.el) : null,
							south = vp ? Ext.fly(layout.south.el) : null,
							cmpCenter = vp ? vp.getComponent("idCenterId") : null,
							cmpSouth = vp ? vp.getComponent("idSouthId") : null;
					}
				}]
			},{
				region: "center",
				id: "idCenterId",
				html: "center"
			}, {
				region: "south",
				id: "idSouthId",
				height: 50,
				html: "south"
			}]
		}),
		vp;

	viewport.on("resize", function (vp, adjWidth, adjHeight, rawWidth, rawHeight) {
		if (window.console && console.log)
			console.log("Ext.Viewport.resize(%o)", arguments);

		toolTip.hide();
		toolTip.show();
	});

	vp = Ext.get("viewport");
	if (window.console && console.log)
		console.log("viewport = %o", vp);
});
