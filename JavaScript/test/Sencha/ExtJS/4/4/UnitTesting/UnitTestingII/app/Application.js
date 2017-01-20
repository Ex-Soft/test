Ext.define("App.Application", {
	name: "App",

	extend: "Ext.app.Application",

	views: [],

	controllers: [ "SpikeController" ],

	stores: [],

	init: function(application) {
		this.callParent(arguments);
	}
});
