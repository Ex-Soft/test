Ext.data.HttpProxyWithExceptionListener = Ext.extend(Ext.data.HttpProxy, {
	constructor: function(config) {
	
		config.listeners = config.listeners || {};
		
		Ext.applyIf(config.listeners, {
			exception: function(proxy, type, action, options, response, arg) {
				if(window.console)
					console.log("HttpProxy.listeners.exception (arguments.length=", arguments.length ,"): response.status=", response.status, " response.isAbort=", response.isAbort, " response.isTimeout=", response.isTimeout, "response.statusText=\"", response.statusText, "\" response.responseText=\"", response.responseText, "\"");
			}
		});

		Ext.data.HttpProxyWithExceptionListener.superclass.constructor.call(this, config);
	}
});