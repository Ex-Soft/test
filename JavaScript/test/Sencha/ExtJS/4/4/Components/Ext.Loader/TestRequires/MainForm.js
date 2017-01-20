Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false,
	paths: {
		"App": "app"
	}
});

//Ext.require([ "App.classes.A1", "App.classes.B1" ]);

Ext.onReady(function() {
	//App.classes.A1.callB();
	//App.classes.B1.callA();
	
	Ext.create("App.classes.C1").callAB();
	Ext.create("App.classes.C2").callAB();
});
