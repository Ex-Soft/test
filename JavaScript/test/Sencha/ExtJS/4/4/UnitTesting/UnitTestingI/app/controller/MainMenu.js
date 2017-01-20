Ext.define("UnitTestingI.controller.MainMenu", {
	extend: "Ext.app.Controller",

	views: [ "MainMenu" ],
	
	refs: [{
		ref: "MainMenu",
		selector: "mainmenu"
	}, {
		ref: "ButtonDoIt",
		selector: "mainmenu button"
	}],

	init: function(application) {
		this.control({
			"mainmenu": {
				testEvent: Ext.Function.alias(this, "onTestEvent")
			},
			"mainmenu button": {
				click: Ext.Function.alias(this, "onButtonClick")
			}
		});
	},

	onTestEvent: function() {
		if(window.console && console.log)
			console.log("UnitTestingI.controller.MainMenu.onTestEvent(%o)", arguments);
	},

	onButtonClick: function(btn, e) {
		if(window.console && console.log)
			console.log("UnitTestingI.controller.MainMenu.onButtonClick(%o)", arguments);
	}
});
