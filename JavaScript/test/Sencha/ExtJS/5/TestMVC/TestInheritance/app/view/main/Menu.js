Ext.define("TestInheritance.view.main.Menu", {
	extend: "Ext.toolbar.Toolbar",
	xtype: "mainmenu",
	requires: [
		"Ext.button.Button",
		"Ext.menu.Menu",
		"TestInheritance.view.main.MenuController"
	],

	controller: "mainmenu",

	items: [{
		text: "Item 1",
		menu: {
			items: [{
				text: "Base"
			}, {
				text: "Derived"
			}],
			listeners: {
				click: "onMenuClick"
			}
		}
	}]
});
