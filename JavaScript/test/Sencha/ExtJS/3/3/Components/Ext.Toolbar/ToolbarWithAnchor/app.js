Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		RegionNorth = new Ext.Toolbar({
			region: "north",
			height: 28,
			items: [
				" ",
				"<a href=\"http://google.com/\">google.com</a>",
				"-",
			{
				xtype: "tbtext",
				text: "<a href=\"http://google.com.ua/\">google.com.ua</a>"
			},
				"->"
			]
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [
				RegionNorth,
			{
				region: "center",
				html: "center"
			}]
		});
});
