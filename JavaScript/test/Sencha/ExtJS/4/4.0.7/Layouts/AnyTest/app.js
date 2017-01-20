Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		layout: "anchor",
		border: 0,
		style: "border-color: red !important;",
		items: [{
			xtype: "container",
			border: 0,
			style: "border-color: green !important;",
			padding: 10,
			margin: 20,
			html: "html"
		}],
		renderTo: Ext.get("Panel1")
	});
});