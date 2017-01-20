Ext.BLANK_IMAGE_URL="../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		LeftPanel=new Ext.Panel({
			html: "left left left"
		}),
		RightPanel=new Ext.Panel({
			html: "right right right"
		}),
		NorthPanel=new Ext.Panel({
			region: "north",
			layout: "column",
			border: false,
			height: 200,
			items: [
				LeftPanel,
				RightPanel
			]
		}),
		viewport=new Ext.Viewport({
			layout: "border",
			border: false,
			renderTo: Ext.getBody(),
			items: [
				NorthPanel,
			{
				region: "center",
				html: "center"
			}]
		});
});
