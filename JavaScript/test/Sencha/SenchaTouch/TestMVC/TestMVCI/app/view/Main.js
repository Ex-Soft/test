Ext.define("TestApp.view.Main", {
	extend: "Ext.Container",
	xtype: "main",
	requires: ["TestApp.view.MainMenu"],

	config: {
		fullscreen: true,
		items: [{
			xtype: "viewmainmenu",
			docked: "left",
			width: "25%"
		}]
	}
});