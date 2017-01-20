Ext.define("TestApp.controller.MainMenu", {
	extend: "Ext.app.Controller",

	views: [ "MainMenu" ],
	
	config: {
		refs: {
			mainMenu: "mainmenu"
		},

		control: {
			mainMenu: {
				leafitemtap: "onLeafItemTap"
			}
		}
	},

	onLeafItemTap: function(nestedList, list, index, target, record, e, eOpts, eventController) {
		this.getApplication().fireEvent("menuitemselect", { entity: record.get("entity"), action: record.get("action") });
	}
});
