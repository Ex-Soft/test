Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	requires: [ "Ext.tab.Panel", "Ext.form.Panel" ],
	
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		var tp = Ext.create("Ext.tab.Panel", {
			fullscreen: true,
			tabBar: {
				docked: "top",
				layout: {
					pack: "center",
					align: "center"
				}
			},
			items: [{
				xtype: "titlebar",
				title: "title",
				docked: "top"
			}, {
				title: "1st",
				xtype: "formpanel",
				items: [{
					xtype: "fieldset",
					items: [{
						xtype: "textfield",
						label: "textfield"
					}]
				}]
			}, {
				title: "2nd",
				xtype: "formpanel",
				items: [{
					xtype: "fieldset",
					items: [{
						xtype: "numberfield",
						label: "numberfield"
					}]
				}]
			}, {
				title: "3rd",
				xtype: "formpanel",
				items: [{
					xtype: "fieldset",
					items: [{
						xtype: "textfield",
						label: "textfield"
					}]
				}]
			}]
		});
	}
});