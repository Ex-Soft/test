Ext.define("TestApp.view.phone.Main", {
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
                title: "TestApp",
                docked: "top",
                items: [{
                    align: "right",
                    ui: "action",
                    action: "showMenu",
                    iconCls: "iconMenu"
                }]
            }]
    }
});
