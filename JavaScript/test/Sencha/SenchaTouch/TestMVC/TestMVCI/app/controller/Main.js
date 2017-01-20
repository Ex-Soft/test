Ext.define("TestApp.controller.Main", {
	extend: "Ext.app.Controller",
	
	config: {
		refs: {
			mainMenu: "viewmainmenu"
		},

		control: {
			mainMenu: {
				leafitemtap: "onLeafItemTap"
			}
		},

		views: [ "Main" ]
	},

	init: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.init(%o)", arguments);

		this.callParent(arguments);

		this.addListener({
			smthEvent: {
				fn: this.doSmth,
				scope: this
			}
		});

		this.getApplication().addListener({
			smthAppEvent: {
				fn: this.doSmthApp,
				scope: this
			}
		});
	},

	onLeafItemTap: function(nestedList, list, index, target, record, e, eOpts, eventController) {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.onLeafItemTap(%o)", arguments);
	},

	doSmth: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.doSmth(%o)", arguments);
	},

	doSmthApp: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.doSmthApp(%o)", arguments);
	}
});
