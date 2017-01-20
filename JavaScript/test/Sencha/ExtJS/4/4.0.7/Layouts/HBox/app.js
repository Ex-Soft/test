Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		width: 500,
		height: 100,
		title: "HBoxLayout Panel",
		layout: {
			type: "hbox",
			align: "stretch"
		},
		items: [{
			xtype: "panel",
			title: "Inner Panel One",
			flex: 2,
			html: "Inner Panel One"
		},{
			xtype: "panel",
			title: "Inner Panel Two",
			flex: 1
		},{
			xtype: "panel",
			title: "Inner Panel Three",
			flex: 1
		}],
		renderTo: Ext.get("Panel1")
	});
});