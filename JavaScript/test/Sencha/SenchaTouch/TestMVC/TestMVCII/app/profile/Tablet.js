Ext.define("TestApp.profile.Tablet", {
	extend: "TestApp.profile.Base",

    config: {
        controllers: ["Main", "TestApp.controller.MainMenu" ],
        views: ["Main"]
    },

    isActive: function() {
        return Ext.os.is.Tablet || Ext.os.is.Desktop;
    },

    launch: function() {
		if (window.console && console.log)
			console.log("TestApp.profile.Tablet.launch(%o)", arguments);

        Ext.create("TestApp.view.tablet.Main");

        this.callParent();
    }
});