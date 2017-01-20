Ext.define("TestApp.controller.Main", {
	extend: "Ext.app.Controller",
	
	config: {
		views: [ "MainMenu" ],
		
		refs: {
			mainView: "mainview",
			menuButton: "mainview titlebar button[action=menu]"
		},
		
		control: {
			menuButton: {
				tap: "onMenuButtonTap"
			}
		},
		
		itemMenu: undefined,
		itemGrid: undefined,
		lastActiveItem: undefined
	},
	
	init: function() {
		this.callParent(arguments);

		this.getApplication().on({
			menuitemselect: {
				fn: "onMenuItemSelect",
				scope: this
			}
		});
	},
	
	onMenuButtonTap: function(sender, e, eOpts) {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.onMenuButtonTap(%o)", arguments);

		var
			mainView = this.getMainView(),
			menu;

		if(menu = this.getItemMenu())
		{
			var
				activeItem = mainView.getActiveItem();

			if(menu !== activeItem)
			{
				this.setLastActiveItem(activeItem);
				mainView.setActiveItem(menu);
			}
			else
			{
				if(activeItem = this.getLastActiveItem())
					mainView.setActiveItem(activeItem);
			}
		}
		else
			this.setItemMenu(menu = mainView.add({ xtype: "mainmenu" }));
	},

	onMenuItemSelect: function(menuItem) {
		if(window.console && console.log)
			console.log("TestApp.controller.Main.onMenuItemSelect(%o)", arguments);

		if(menuItem.entity)
		{
			var
				mainView = this.getMainView(),
				grid;

			if(grid = this.getItemGrid())
			{
				if(grid.getHtml() !== menuItem.entity)
				{
					mainView.remove(grid);
					this.setItemGrid(grid = mainView.add({ xtype: "container", html: menuItem.entity }));
				}
			}
			else
				this.setItemGrid(grid = mainView.add({ xtype: "container", html: menuItem.entity }));

			mainView.setActiveItem(grid);
		}
	}
});
