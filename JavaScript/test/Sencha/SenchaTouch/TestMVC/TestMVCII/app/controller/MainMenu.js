Ext.define("TestApp.controller.MainMenu", {
    extend: "Ext.app.Controller",

	requires: [ "TestApp.view.MainMenu" ],

	config: {
		refs: {
			mainMenu: "mainmenu",
			btnClose: "mainmenu titlebar button[action=close]"
		},

		control: {
			btnClose: {
				tap: "onBtnCloseTap"
			}
		}
	},

	onBtnCloseTap: function(btn, e, eOpts, eventController) {
		this.getApplication().fireEvent("menuclose", this.getMainMenu());
	}
});
