Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.get("div1").fadeOut();
	window.setTimeout(function() {
		Ext.get("div1").fadeIn();
	}, 3000);

	Ext.get("div2").fadeOut({endOpacity:0.25});
	window.setTimeout(function() {
		Ext.get("div2").fadeIn({endOpacity: 0.75});
	}, 3000);

	Ext.get("div3").frame();
	Ext.get("div4").frame("ff0000", 3);
});
