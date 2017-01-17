MyHttpProxy = Ext.extend(Ext.data.HttpProxy, {
	constructor : function(config) {
		if(Ext.isGecko && window.console)
			console.info("MyHttpProxy.constructor");

		config.listeners = config.listeners || {};
		Ext.applyIf(config.listeners, {
			load: function(s, r, o) {
				if(Ext.isGecko && window.console)
					console.info("MyHttpProxy.listeners.load");
			},
			exception: function(proxy, type, action, options, response, arg) {
				if(Ext.isGecko && window.console)
					console.info("HttpProxy.listeners.exception: response.status=", response.status, " response.isAbort=", response.isAbort, " response.isTimeout=", response.isTimeout, "response.statusText=\"", response.statusText, "\" response.responseText=\"", response.responseText, "\" (arguments.length=", arguments.length, ")");
			}
		});

		if(Ext.isGecko && window.console)
			console.info("1. before constructor parent");

		MyHttpProxy.superclass.constructor.call(this, config);

		if(Ext.isGecko && window.console)
			console.info("4. after constructor parent");
	},
	initComponent: function() {
		if(Ext.isGecko && window.console)
			console.info("MyHttpProxy.initComponent");

		Ext.apply(this, Ext.apply(this.initialConfig, {} ));
		
		if(Ext.isGecko && window.console)
			console.info("2. before initComponent parent");

		MyHttpProxy.superclass.initComponent.apply(this, arguments);

		if(Ext.isGecko && window.console)
			console.info("3. after initComponent parent");
	}
});