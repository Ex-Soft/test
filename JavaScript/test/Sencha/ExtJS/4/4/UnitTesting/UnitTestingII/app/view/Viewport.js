Ext.define("App.view.Viewport", {
	extend: "Ext.container.Viewport",
	requires:[
		"Ext.layout.container.Fit",
		"App.view.SpikeView"
	],

	layout: {
		type: "fit"
	},

	items: [{
		xtype: "spike_view"
	}]
});
