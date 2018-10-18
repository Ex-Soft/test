Ext.ns("App.Components");

App.Components.MainPanel = Ext.extend(Ext.Panel, {
	initComponent: function(){
		var
			tabpanel=new App.Components.MainTabPanel(),
			config = {
				region: "center",
				layout: "border",
				border: false,
				items: [{
					region: "north",
					height: 29,
					items: [new App.Components.MainToolBar({ TabPanel: tabpanel })]
				}, {
					region: "center",
					items: [tabpanel]
				}]
			};

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		App.Components.MainPanel.superclass.initComponent.apply(this, arguments);
	}
});

Ext.reg('mainpanel', App.Components.MainPanel);
