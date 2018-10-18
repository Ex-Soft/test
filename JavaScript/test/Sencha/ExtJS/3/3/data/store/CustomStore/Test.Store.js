Ext.ns("Test");
Test.Store = Ext.extend(Ext.data.Store, {
	constructor : function(config) {
		if(Ext.isGecko && ("console" in window))
			console.info("Test.Store.constructor");

		if(Ext.isGecko && ("console" in window))
			console.info("1. before constructor parent");

		Test.Store.superclass.constructor.call(this, config);

		if(Ext.isGecko && ("console" in window))
			console.info("4. after constructor parent");
	},
	initComponent: function() {
		if(Ext.isGecko && ("console" in window))
			console.info("Test.Store.initComponent");

		Ext.apply(this, Ext.apply(this.initialConfig, {} ));
		
		if(Ext.isGecko && ("console" in window))
			console.info("2. before initComponent parent");

		Test.Store.superclass.initComponent.apply(this, arguments);

		if(Ext.isGecko && ("console" in window))
			console.info("3. after initComponent parent");
	}
});
