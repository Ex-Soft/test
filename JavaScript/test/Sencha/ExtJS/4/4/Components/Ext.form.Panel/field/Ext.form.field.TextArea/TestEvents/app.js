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
		ta = Ext.create("Ext.form.field.TextArea", {
			enableKeyEvents: true,
			renderTo: Ext.getBody(),
			listeners: {
				change: function(textarea, newValue, oldValue, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.TextArea.change(%o)", arguments);
				},
				keyup: function(textarea, e, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.TextArea.keyup(%o)", arguments);
				}
			}
		});
});