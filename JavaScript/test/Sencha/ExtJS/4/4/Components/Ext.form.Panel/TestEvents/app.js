Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		form = Ext.create("Ext.form.Panel",{
			defaults: {
				enableKeyEvents: true,
				listeners: {
					keypress: function(field, e, eOpts) { // doesn't occur in 4.0.7
						if (window.console && console.log)
							console.log("keypress(%o)", arguments);

						if(e.getKey() === Ext.EventObject.ENTER) {
						}
					},
					specialkey: function(field, e, eOpts) {
						if (window.console && console.log)
							console.log("specialkey(%o)", arguments);

						if(e.getKey() === Ext.EventObject.ENTER) {
						}
					}
				}
			},
			items: [{
				xtype: "textfield"
			}]
		}),
		panel = Ext.create("Ext.panel.Panel", {
			dockedItems: [{
				xtype: "toolbar",
				doc: "top",
				items: [form]
			}],
			renderTo: Ext.getBody()
		});
});