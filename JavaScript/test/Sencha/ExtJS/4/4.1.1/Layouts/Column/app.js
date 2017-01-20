Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		title: "Column Layout Panel# 1",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "125px",
			width: 125,
			layout: "fit",
			html: "125px",
			xtype: "panel"
		},{
			title: ".7",
			columnWidth: .7
		},{
			title: ".2",
			columnWidth: .2
		}, {
			title: ".1",
			columnWidth: .1
		}],
		renderTo: Ext.get("Panel1")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Column Layout Panel# 2",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "125px",
			width: 125
		},{
			title: "70%",
			width: "70%"
		},{
			title: "20%",
			width: "20%"
		}, {
			title: "10%",
			width: "10%"
		}],
		renderTo: Ext.get("Panel2")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Column Layout Panel# 3",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "70%",
			width: "70%"
		},{
			title: "20%",
			width: "20%"
		}, {
			title: "10%",
			width: "10%"
		}],
		renderTo: Ext.get("Panel3")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Column Layout Panel# 4",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "75%",
			width: "75%"
		},{
			title: "75%",
			width: "75%"
		}],
		renderTo: Ext.get("Panel4")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Column Layout Panel# 5",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "75%",
			width: "75%"
		},{
			title: "25%",
			width: "25%"
		}],
		renderTo: Ext.get("Panel5")
	});

	Ext.create("Ext.window.Window", {
		title: "Window# 1",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "75%",
			width: "75%"
		},{
			title: "25%",
			width: "25%"
		}],
		renderTo: Ext.getBody()
	}).show();

	Ext.create("Ext.window.Window", {
		title: "Window# 2",
		width: 500,
		height: 100,
		layout: "column",
		items: [{
			title: "125px",
			width: 125
		},{
			title: ".7",
			columnWidth: .7
		},{
			title: ".2",
			columnWidth: .2
		}, {
			title: ".1",
			columnWidth: .1
		}],
		renderTo: Ext.getBody()
	}).show();
});