Ext.define("TestApp.controller.Main", {
    extend: "Ext.app.Controller",

	requires: [ "TestApp.view.MainMenu" ],

	config: {
		refs: {
			main: "mainview",
			menuButton: "mainview titlebar button[action=showMenu]"
		},

		control: {
			menuButton: {
				tap: "onShowMenu"
			}
		}
	},

	init: function() {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.init(%o)", arguments);

		this.callParent(arguments);

		this.getApplication().addListener({
			menuclose: {
				fn: this.hideMenu,
				scope: this
			}
		});
	},

	onShowMenu: function(btn, e, eOpts, eventController) {
		var
			main = this.getMain(),
			menu = main.getItems().findBy(function(item, key) { return item.xtype === "mainmenu"; });

		if(!menu)
			main.add(Ext.create("TestApp.view.MainMenu"));
		else
			this.hideMenu(menu);
	},
	
	hideMenu: function(menu) {
		this.getMain().remove(menu);
	}
});
