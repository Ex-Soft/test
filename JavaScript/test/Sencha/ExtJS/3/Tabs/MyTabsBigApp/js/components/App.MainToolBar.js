Ext.ns("App.Components");

App.Components.MainToolBar = Ext.extend(Ext.Toolbar, {
    initComponent: function() {
		var
			tp=this.TabPanel,
			config = {
				items: [{
					xtype: "tbspacer"
				}, {
					xtype: "button",
					text: "Tab# 1",
					handler: function(b, e){
						tp.ShowTab(b.text);
					}
				}, {
					xtype: "tbspacer"
				}, {
					xtype: "button",
					text: "Tab# 2",
					handler: function(b, e){
						tp.ShowTab(b.text);
					}
				}, {
					xtype: "tbspacer"
				}, {
					xtype: "button",
					text: "Tab# 3",
					handler: function(b, e){
						tp.ShowTab(b.text);
					}
				}, {
					xtype: "tbspacer"
				}, {
					xtype: "tbseparator"
				}, {
					xtype: "tbspacer"
				}, {
					xtype: "button",
					text: "Tab# 4",
					handler: function(b, e){
						tp.ShowTab(b.text);
					}
				}, {
					xtype: "tbfill"
				}]
			};

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		App.Components.MainToolBar.superclass.initComponent.apply(this, arguments);
	}
});

Ext.reg('maintoolbar', App.Components.MainToolBar);
