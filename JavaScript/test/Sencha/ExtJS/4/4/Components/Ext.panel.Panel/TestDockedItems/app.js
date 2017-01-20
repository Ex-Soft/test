Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		dockedItems = [{
			xtype: "toolbar",
			dock: "bottom",
			ui: "footer",
			weight: 1,
			items: [
				{ xtype: "component", flex: 1 },
				{ xtype: "button", text: "1st" }
			]
		}, {
			xtype: "toolbar",
			dock: "bottom",
			ui: "footer",
			weight: 10,
			items: [
				{ xtype: "component", flex: 1 },
				{ xtype: "button", text: "2nd" }
			]
		}];

	dockedItems.splice(0, 0, {
		xtype: "toolbar",
		dock: "bottom",
		ui: "footer",
		weight: 3,
		items: [
			{ xtype: "component", flex: 1 },
			{ xtype: "button", text: "1st1st" }
		]
	});

	dockedItems.splice(1, 0, {
		xtype: "toolbar",
		dock: "bottom",
		ui: "footer",
		weight: 5,
		items: [
			{ xtype: "component", flex: 1 },
			{ xtype: "button", text: "2nd2nd" }
		]
	});

	Ext.create("Ext.panel.Panel", {
		html: "html",
		dockedItems: dockedItems,
		renderTo: Ext.getBody()
	});
});