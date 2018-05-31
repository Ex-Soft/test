Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.Loader.injectScriptElement("../../../../../../../../Sencha/ExtJS/ExtJS4/ExtJS4.2.1/locale/ext-lang-ru.js", onLoad, onError);
});

function onLoad() {
	if(window.console && console.log)
		console.log("onLoad(%o)", arguments);

	var
		now = new Date();

	if(window.console && console.log)
		console.log("%s, %i %s %i", Ext.Date.dayNames[now.getDay()], now.getDate(), Ext.Date.shortMonthNames[now.getMonth()], now.getFullYear());
}

function onError() {
	if(window.console && console.log)
		console.log("onError(%o)", arguments);
}
