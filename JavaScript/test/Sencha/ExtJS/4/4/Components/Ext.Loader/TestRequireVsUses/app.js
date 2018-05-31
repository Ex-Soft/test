// http://www.sencha.com/forum/showthread.php?133191-What-s-the-difference-between-requires-and-uses-when-defining-a-class
// http://www.sencha.com/forum/showthread.php?184725-Uses-vs-requires

Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.view.*",
	"Ext.grid.*"
]);

Ext.onReady(function() {
	Ext.Loader.injectScriptElement("../../../../../../ExtJS/ExtJS4/locale/ext-lang-ru.js", onLoad, onError);
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