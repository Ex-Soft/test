Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.Ajax.request({
		url: "http://livedev.ru/offline/online",
		method: "GET",
		callback: function(options, success, response){
			if(window.console && console.log)
				console.log("callback(%o)", arguments);
		},
		success: function(response, options){
			if(window.console && console.log)
				console.log("success(%o)", arguments);
		},
		failure: function(response, options){
			if(window.console && console.log)
				console.log("failure(%o)", arguments);

		}
	}); 	
});
