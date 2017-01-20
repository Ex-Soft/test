Ext.define("TestMVCI.view.main.Menu", {
	extend: "Ext.toolbar.Toolbar",
	xtype: "mainmenu",

	requires: [
		"Ext.button.Button",
		"Ext.menu.Menu",
		"TestMVCI.view.main.MenuController"
	],

	controller: "mainmenu",

	items: [{
		text: "Item 1",
		menu: {
			items: [{
				text: "Item 1.1"
			}, {
				text: "Item 1.2"
			}],
			listeners: {
				click: "onMenuClick"
			}
		}
	}]
});
