Ext.define("TestApp.view.MainMenu", {
	extend: "Ext.dataview.NestedList",
	alias: "widget.mainmenu",
	requires: ["TestApp.store.MainMenu"],
	xtype: "mainmenu",
	
	config: {
		store: { xclass: "TestApp.store.MainMenu" },
		toolbar: {
			items: [
			{
				text: "Close",
				align: "right",
				ui: "action",
				action: "close"
			}]
		}
	}
});