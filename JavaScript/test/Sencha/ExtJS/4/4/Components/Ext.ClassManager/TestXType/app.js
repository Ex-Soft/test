Ext.define("TestPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel",
	
	html: "testpanel",

	initComponent: function() {
		this.callParent();
	}
});

Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		items: [{
			xtype: "button",
			text: "DoIt!",
			handler: function() {
				var
					a = Ext.ClassManager.getByAlias("widget.testpanel"),
					n = Ext.ClassManager.getNameByAlias("widget.testpanel");

				if(a)
					;
			}
		}, {
			xtype: "testpanel"
		}],
		renderTo: Ext.getBody()
	});
});
