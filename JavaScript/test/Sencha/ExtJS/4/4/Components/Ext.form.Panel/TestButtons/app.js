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
		form = Ext.create("Ext.form.Panel", {
			buttons: [
				{
					text: "Button# 1",
					cls: "btn1"
				}
			],
			renderTo: Ext.getBody()
		});
});