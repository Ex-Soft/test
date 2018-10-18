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
					text: "Test1",
					tooltip: "Create Tab \"Test1\"",
					handler: function(btn){ DoIt(btn) }
					}, {
					xtype: "button",
					text: "Test2",
					handler: function(btn){ DoIt(btn) }
					}, {
					xtype: "button",
					text: "Test3",
					handler: function(btn){ DoIt(btn) }
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
	var
		tabPanel,
		tab;
		
	if(!(tabPanel=Ext.getCmp("TabPanel")))
		return;

	if(!(tab=tabPanel.items.find(function(i){return i.title === btn.text;})))
		tab=tabPanel.add({ title: btn.text, html: btn.text, layout: "fit", closable: true });
	tabPanel.setActiveTab(tab); 
	
	if(!tabPanel.isVisible())
	{
		tabPanel.setVisible(true);
		tabPanel.ownerCt.doLayout();
	}
}
