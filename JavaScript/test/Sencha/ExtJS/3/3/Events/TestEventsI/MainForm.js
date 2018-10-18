Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	var
		viewport=new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				region: "north",
				xtype: "mypanel",
				id: "MyPanel",
				height: 500,
				width: 700,
				items: [{
					xtype: "mybutton",
					id: "MyButton0",
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
	var
		Ctrl;
		
	if(Ctrl=Ext.getCmp("MyPanel"))
	{
		Ctrl.fireEvent("MyEvent","data");
	}
	
	btn.fireEvent("MyEvent","data");
}