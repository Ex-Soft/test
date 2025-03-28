﻿Ext.define("TestApp.profile.Phone", {
	extend: "TestApp.profile.Base",

	config: {
		controllers: [ "Main", "TestApp.controller.MainMenu" ],
		views: [ "Main" ]
	},

	isActive: function() {
		return Ext.os.is.Phone; // || Ext.os.is.Desktop;
	},

	launch: function() {
		if(window.console && console.log)
			console.log("TestApp.profile.Phone.launch(%o)", arguments);

		Ext.create("TestApp.view.phone.Main");

		this.callParent();
	}
});
