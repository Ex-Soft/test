Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	var
		viewport=new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				region: "north",
				xtype: "toolbar",
				// autoHeight: true,
				height: 26,
				items: [{
					xtype: "tbspacer"
					}, {
					xtype: "button",
					text: "Button",
					tooltip: "fireEvent(\"MyEvent\")",
					handler: function(btn){ DoIt(btn); }
					}, {
					xtype: "mybutton",
					id: "MyButton1",
					text: "MyButton# 1"
					}, {
					xtype: "mybutton",
					id: "MyButton2",
					text: "MyButton# 2"
					}, {
					xtype: "tbfill"
				}]
				}, {
				region: "center",
				xtype: "tabpanel",
				id: "TabPanel",
				hidden: true
				, autoHeight: true
				, tabPosition: "bottom"
			}]
		});
});

function DoIt(btn)
{
	 Bus.fireEvent("MyEvent","data");
}