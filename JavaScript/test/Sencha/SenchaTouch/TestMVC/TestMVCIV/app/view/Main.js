Ext.define("TestApp.view.Main", {
    extend: "Ext.Container",

    requires: [ "Ext.TitleBar" ],

    xtype: "mainview",
	
    config: {
        fullscreen: true,
		
		layout: {
			type: "card",
			animation: {
				type: "slide",
				direction: "left",
				duration: 250
			}
		},
		
        items: [{
			xtype: "titlebar",
            title: "Test MVC (IV)",
			docked: "top",
			items: [{
				align: "right",
				ui: "action",
				action: "menu",
				iconCls: "iconMenu"
			}]
        }]
    }
});
