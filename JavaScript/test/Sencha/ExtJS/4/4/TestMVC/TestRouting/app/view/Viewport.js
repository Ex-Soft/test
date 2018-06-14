Ext.define("TestRouting.view.Viewport", {
	extend: "Ext.container.Viewport",
	layout: "border",

	requires: [
		"TestRouting.widget.NavPanel"
	],

	items: [{
		region: "west",
		layout: "fit",
		xtype: "navpanel",
		width: 300
	}]
});