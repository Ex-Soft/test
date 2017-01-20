Ext.define("UnitTestingI.view.Viewport", {
	extend: "Ext.container.Viewport",
	requires:[
		"Ext.layout.container.Fit",
		"UnitTestingI.view.Main"
	],

	layout: {
		type: "fit"
	},

	items: [{
		xtype: "app-main"
	}]
});
