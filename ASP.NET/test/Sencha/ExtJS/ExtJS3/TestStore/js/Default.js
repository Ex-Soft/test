Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		proxy = new Ext.data.HttpProxy({
			url: "DataSource.aspx",
	    	listeners: {
	    		load: function(s, r, o) {
					if(Ext.isGecko && window.console)
						console.info("HttpProxy.listeners.load");
	    		},
	    		exception: function(proxy, type, action, options, response) {
	    			if(Ext.isGecko && window.console)
						console.info("HttpProxy.listeners.exception (arguments.length=%i)", arguments.length);
				}
	    	}
		}),
		store = new Ext.data.JsonStore({
			url: "DataSource.aspx",
			root: "rows",
	    	idProperty: "Id",
	    	successProperty: "success",
	    	totalProperty: "count",
	    	fields: [
	    		{ name: "Id", type: "int" },
	    		"Name"
	    	],
	    	listeners: {
	    		load: function(s, r, o) {
					if(Ext.isGecko && window.console)
						console.info("store.listeners.load");
	    		},
	    		exception: function(proxy, type, action, options, response) {
	    			if(Ext.isGecko && window.console)
						console.info("store.listeners.exception (arguments.length=%i)", arguments.length);
				}
	    	}
		}),
		storeWithHttpProxy = new Ext.data.JsonStore({
			proxy: proxy,
			root: "rows",
	    	idProperty: "Id",
	    	successProperty: "success",
	    	totalProperty: "count",
	    	fields: [
	    		{ name: "Id", type: "int" },
	    		"Name"
	    	],
	    	listeners: {
	    		load: function(s, r, o) {
					if(Ext.isGecko && window.console)
						console.info("storeWithHttpProxy.listeners.load");
	    		},
	    		exception: function(proxy, type, action, options, response) {
	    			if(Ext.isGecko && window.console)
						console.info("storeWithHttpProxy.listeners.exception (arguments.length=%i)", arguments.length);
				}
	    	}
		}),
		store1WithMyHttpProxy = new Ext.data.JsonStore({
			proxy: new MyHttpProxy({url: "DataSource.aspx"}),
			root: "rows",
	    	idProperty: "Id",
	    	successProperty: "success",
	    	totalProperty: "count",
	    	fields: [
	    		{ name: "Id", type: "int" },
	    		"Name"
	    	],
	    	listeners: {
	    		load: function(s, r, o) {
					if(Ext.isGecko && window.console)
						console.info("store1WithMyHttpProxy.listeners.load");
	    		},
	    		exception: function(proxy, type, action, options, response) {
	    			if(Ext.isGecko && window.console)
						console.info("store1WithMyHttpProxy.listeners.exception (arguments.length=%i)", arguments.length);
				}
	    	}
		}),
		store2WithMyHttpProxy = new Ext.data.JsonStore({
			proxy: new MyHttpProxy({url: "DataSource.aspx"}),
			root: "rows",
	    	idProperty: "Id",
	    	successProperty: "success",
	    	totalProperty: "count",
	    	fields: [
	    		{ name: "Id", type: "int" },
	    		"Name"
	    	],
	    	listeners: {
	    		load: function(s, r, o) {
					if(Ext.isGecko && window.console)
						console.info("store2WithMyHttpProxy.listeners.load");
	    		},
	    		exception: function(proxy, type, action, options, response) {
	    			if(Ext.isGecko && window.console)
						console.info("store2WithMyHttpProxy.listeners.exception (arguments.length=%i)", arguments.length);
				}
	    	}
		}),
		StoreResult,
		StoreWithHttpProxyResult,
		Store1WithMyHttpProxyResult,
		Store2WithMyHttpProxyResult;

	StoreResult=store.load({
		params: {
			param: 1
		},
		callback: function(r, o, s) {
			if(Ext.isGecko && window.console)
				console.info("store.load.callback: success="+s);
		}
	});

	StoreWithHttpProxyResult=storeWithHttpProxy.load({
		params: {
			param: 1
		},
		callback: function(r, o, s) {
			if(Ext.isGecko && window.console)
				console.info("storeWithHttpProxy.load.callback: success="+s);
		}
	});

	Store1WithMyHttpProxyResult=store1WithMyHttpProxy.load({
		params: {
			param: 1
		},
		callback: function(r, o, s) {
			if(Ext.isGecko && window.console)
				console.info("store1WithMyHttpProxy.load.callback: success="+s);
		}
	});
	
	Store2WithMyHttpProxyResult=store2WithMyHttpProxy.load({
		params: {
			param: 1
		},
		callback: function(r, o, s) {
			if(Ext.isGecko && window.console)
				console.info("store2WithMyHttpProxy.load.callback: success="+s);
		}
	});
});