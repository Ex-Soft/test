Ext.define("TestApp.view.MainMenu", {
	extend: "Ext.dataview.NestedList",
	alias: "widget.viewmainmenu",
	requires: ["TestApp.store.MainMenu"],

	config: {
		store: { xclass: "TestApp.store.MainMenu" },
		toolbar: {
			items: [
			{
				//text: "Close",
				align: "right",
				iconCls: "iconMenu",
				action: "onBtnCloseAction"
			}]
		}
	}
});