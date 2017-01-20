Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("TestWindow", {
		title: "Test"
		//,items: [Ext.create("TestForm")]
		//, height: undefined
		//, width: undefined
	}).show();
});