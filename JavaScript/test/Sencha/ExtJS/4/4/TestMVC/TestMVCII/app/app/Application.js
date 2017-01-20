Ext.define("AM.app.Application", {
	extend: "Ext.app.Application",

	constructor: function(config) {
		if(window.console && console.log)
			console.log("AM.app.Application.constructor(%o)", arguments);

		this.callParent([config]);
	},

	init: function(app) {
		if(window.console && console.log)
			console.log("AM.app.Application.init(%o)", arguments);

		this.callParent(arguments);
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("AM.app.Application.initComponent(%o)", arguments);

		this.callParent(arguments);
	},
	
	launch: function() {
		if (window.console && console.log)
			console.log("Ext.application.launch");

		Ext.create('AM.view.Viewport', {
		});
	},

	onLaunch: function(app) {
		if(window.console && console.log)
			console.log("AM.app.Application.onLaunch(%o)", arguments);

		this.callParent(arguments);
	}
});
