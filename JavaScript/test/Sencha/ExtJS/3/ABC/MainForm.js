Ext.onReady(function() {
	Ext.BLANK_IMAGE_URL="../../../ExtJS/resources/images/default/s.gif";

	Ext.QuickTips.init();

	var
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [
			{ region: "west", xtype: "panel", html: "West", width: 200 },
			{ region: "center", xtype: "panel", html: "Center" }
			]
		});
});