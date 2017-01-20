Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

//Ext.require(["TestWindow"]);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		b = Ext.create("Ext.button.Button", {
			text: "DoIt!",
			handler: function(btn, e) {
				Ext.create("TestWindow").show();
			},
			renderTo: Ext.getBody()
		});
});