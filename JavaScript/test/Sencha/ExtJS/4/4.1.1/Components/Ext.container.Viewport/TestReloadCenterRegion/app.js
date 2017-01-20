Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
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
					text: "Panel1",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
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
			},{
				region: "center",
				html: "center",
				id: "regionCenter"
			}]
		}),
		replaceRegionCenter = function(text)
		{
			var
				layoutItems = vp.getLayout().getLayoutItems(),
				regionCenter = vp.getLayout().centerRegion,
				renderTarget = vp.layout.getRenderTarget(),
				target = vp.layout.getTarget();

			regionCenter.removeAll();
			regionCenter.add(Ext.create("Ext.panel.Panel", {
				region: "center",
				id: text,
				items: [{
					xtype: "button",
					text: "Watch",
					handler: function(btn, e) {
						var
							panel = btn.up("panel");

						if(panel
							&& panel.ownerCt
							&& panel.ownerCt.setTitle)
							panel.ownerCt.setTitle(text);
					}
				}]
			}));
		};
});
