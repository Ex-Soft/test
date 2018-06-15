Ext.define("TestRouting.view.Viewport", {
	extend: "Ext.container.Viewport",
	layout: "border",

	requires: [
		"TestRouting.widget.NavPanel",
		"TestRouting.widget.MainPanel"
	],

	items: [{
		region: "west",
		layout: "fit",
		xtype: "navpanel",
		width: 300
	}, {
		region: "center",
		xtype: "mainpanel"
	}]
});