Ext.define("TestApp.controller.MainMenu", {
	extend: "Ext.app.Controller",
	
	config: {
		refs: {
			mainMenu: "viewmainmenu",
			//btnClose: "viewmainmenu titlebar button[text=Close]"
			//btnClose: "viewmainmenu titlebar button[iconCls=iconMenu]"
			btnClose: "viewmainmenu titlebar button[action=onBtnCloseAction]"
		},

		control: {
			mainMenu: {
				leafitemtap: "onLeafItemTap"
			},
			btnClose: {
				tap: "onBtnCloseTap"
			}
		},

		views: [ "MainMenu" ],

		bubbleEvents: [ "smthEvent" ]
	},

	constructor: function(config) {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.constructor(%o)", arguments);

		this.initConfig(config);

		return this;
	},
	
	init: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.init(%o)", arguments);

		this.callParent(arguments);

		this.addListener({
			smthEvent: {
				fn: this.doSmth,
				scope: this
			}
		});

		this.addListener({
			smthEvent: {
				fn: this.doSmthII,
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

	getBubbleTarget: function() {
		return this.getApplication().getController("Main");
	},

	onLeafItemTap: function(nestedList, list, index, target, record, e, eOpts, eventController) {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.onLeafItemTap(%o)", arguments);

		this.fireEvent("smthEvent", [1, 2, 3]);
		this.getApplication().fireEvent("smthAppEvent", [1, 2, 3]);
	},
	
	onBtnCloseTap: function(btn, e, eOpts, eventController) {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.onBtnCloseTap(%o)", arguments);
	},

	doSmth: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.doSmth(%o)", arguments);
	},

	doSmthII: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.doSmthII(%o)", arguments);
	},

	doSmthApp: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.MainMenu.doSmthApp(%o)", arguments);
	}
});
