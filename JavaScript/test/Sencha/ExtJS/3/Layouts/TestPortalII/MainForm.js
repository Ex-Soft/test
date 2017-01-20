Ext.BLANK_IMAGE_URL="../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		viewport = new Ext.Viewport({
			layout: "fit",
			items: [{
				xtype: "portal",
				items: [{
					columnWidth: .33,
					style: "padding:10px 0 10px 10px",
					items:[{
						title: "Panel [0,0]",
						html: "Panel [0,0]"
					}, {
						title: "Panel [0,1]",
						html: "Panel [0,1]"
					}, {
						title: "Panel [0,2]",
						html: "Panel [0,2]"
					}]
				}, {
					columnWidth: .33,
					style: "padding:10px 0 10px 10px",
					items:[{
						title: "Panel [1,0]",
						html: "Panel [1,0]"
					}, {
						title: "Panel [1,1]",
						html: "Panel [1,1]"
					}]
				}, {
					columnWidth: .33,
					style: "padding:10px 0 10px 10px",
					items:[{
						title: "Panel [2,0]",
						html: "Panel [2,0]"
					}, {
						title: "Panel [2,1]",
						html: "Panel [2,1]"
					}, {
						title: "Panel [2,2]",
						html: "Panel [2,2]"
					}]
				}]
			}]
		});
});
