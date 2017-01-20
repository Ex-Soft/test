Ext.ns("Test");
Test.Window = Ext.extend(Ext.Window, {
	constructor : function(config) {
		if(Ext.isGecko && ("console" in window))
			console.info("Test.Window.constructor");

		if(Ext.isGecko && ("console" in window))
			console.info("1. before constructor parent");

		Test.Window.superclass.constructor.call(this, config);

		if(Ext.isGecko && ("console" in window))
			console.info("4. after constructor parent");
	},
	initComponent: function() {
		if(Ext.isGecko && ("console" in window))
			console.info("Test.Window.initComponent");

		Ext.apply(this, Ext.apply(this.initialConfig, {} ));
		
		if(Ext.isGecko && ("console" in window))
			console.info("2. before initComponent parent");

		Test.Window.superclass.initComponent.apply(this, arguments);

		if(Ext.isGecko && ("console" in window))
			console.info("3. after initComponent parent");
	}
});
