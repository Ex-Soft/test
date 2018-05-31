Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.button.Button", {
		text: "injectScriptElement",
		handler: injectScriptElement,
		renderTo: Ext.getBody()
	});

	Ext.create("Ext.button.Button", {
		text: "loadScript",
		handler: loadScript,
		renderTo: Ext.getBody()
	});

	Ext.create("Ext.button.Button", {
		text: "loadScriptFile",
		handler: loadScriptFile,
		renderTo: Ext.getBody()
	});
});

function injectScriptElement() {
	Ext.Loader.injectScriptElement("f1.js", onLoad, onError);
}

function loadScript() {
	Ext.Loader.loadScript({ url: "f1.js", onLoad: onLoad, onError: onError, scope: window });
}

function loadScriptFile() {
	Ext.Loader.loadScriptFile("f1.js", onLoad, onError, window);
}

function onLoad() {
	if(window.console && console.log)
		console.log("onLoad(%o)", arguments);

	f1function();
}

function onError() {
	if(window.console && console.log)
		console.log("onError(%o)", arguments);
}