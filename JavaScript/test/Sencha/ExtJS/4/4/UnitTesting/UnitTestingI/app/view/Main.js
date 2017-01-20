Ext.define("UnitTestingI.view.Main", {
	extend: "Ext.container.Container",
	requires:[
		"Ext.layout.container.Border",
		"Ext.layout.container.Fit",
		"UnitTestingI.view.MainMenu"
	],

	xtype: "app-main",

	layout: {
		type: "border"
	},

	items: [{
		region: "north",
		xtype: "mainmenu",
		height: 26,
		border: false
	},{
		region: "center",
		layout: "fit",
		border: false
	}]
});