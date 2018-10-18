Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		myMenu = new Ext.menu.Menu({
			cls: "myMenuClass",
			width: 200,
			plain: true,
			items: [{
				text: "Menu item 1"
			} ,{
				text: "Menu item 2"
			}]
		}),
		RegionNorth = new Ext.Toolbar({
			region: "north",
			height: 28,
			items: [
				" ",
			{
				xtype: "button",
				text: "Button# 1",
				menu: {
					items: [{
						text: "SubButton# 1"
					}, {
						text: "SubButton# 2"
					}]
				}
			},
				" ",
			{
				xtype: "button",
				text: "Button# 2",
				menu: myMenu
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
