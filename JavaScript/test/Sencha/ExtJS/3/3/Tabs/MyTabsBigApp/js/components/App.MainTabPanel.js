Ext.ns("App.Components");

App.Components.MainTabPanel = Ext.extend(Ext.TabPanel, {
    initComponent: function() {
		var
			config = {
				hidden: true,
				id: "TabPanel",
				tabPosition: "bottom",
				ShowTab: function(TabTitle){
					var
						tab;
						
					if (!(tab = this.items.find(function(i) { return i.title === TabTitle; })))
						tab = this.add({ title: TabTitle, layout: "fit", closable: true, html: "Tab: \""+TabTitle+"\"" });

					this.setActiveTab(tab);

					if (!this.isVisible()) {
						this.setVisible(true);
						//this.ownerCt.doLayout();
					}
				}
			};

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		App.Components.MainTabPanel.superclass.initComponent.apply(this, arguments);
	}
});

Ext.reg('maintabpanel', App.Components.MainTabPanel);
