Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		"name"
	]
});

Ext.define("CustomGridPanel" ,{
	extend: "Ext.grid.Panel",
	alias : "widget.customgridpanel",

	initComponent: function() {
		Ext.apply(this, {
			disableSelection: false
		});

		this.callParent(arguments);
		
		this.addListener("beforerender", this.beforeRender);
	},
	
	beforeRender: function() {
		if(window.console && console.log)
			console.log("CustomGridPanel.beforeRender(%o) (%o)", arguments, this.el);
	},
	
	onRender: function() {
		if(window.console && console.log)
			console.log("b4: CustomGridPanel.onRender(%o) (%o)", arguments, this.el);

		this.callParent(arguments);

		if(window.console && console.log)
			console.log("after: CustomGridPanel.onRender(%o) (%o)", arguments, this.el);
	},
	
	afterRender: function() {
		this.callParent(arguments);

		if(window.console && console.log)
			console.log("CustomGridPanel.afterRender(%o) (%o)", arguments, this.el);
	}
});

Ext.onReady(function() {
	var
		store = Ext.create("Ext.data.Store", {
			model: "TestModel"
		}),
		data=[
			[ 1, "Record# 1" ],
			[ 2, "Record# 2" ],
			[ 3, "Record# 3" ],
			[ 4, "Record# 4" ]
		];

	store.loadData(data);
	
	var
		w = Ext.create("Ext.window.Window", {
			title: "Custom Ext.grid.Panel",
			height: (window.innerHeight ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : (document.body.clientHeight ? document.body.clientHeight : 400))) - 200,
			width: (window.innerWidth ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : (document.body.clientWidth ? document.body.clientWidth : 800))) - 200,
			layout: "fit",
			autoDestroy: true,
			buttons: [
				{
					text: "Close",
					handler: function(btn, e) {
						w.close();
					}
				}
			],
			items: [
				{
					xtype: "customgridpanel",
					store: store,
					columns: [
						{ dataIndex: "id", header: "id" },
						{ dataIndex: "name", header: "name" },
					]
				}
			],
			renderTo: Ext.getBody()
		});

	w.show();
});