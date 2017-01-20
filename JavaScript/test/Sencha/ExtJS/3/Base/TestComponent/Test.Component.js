Ext.ns("Test");
Test.ComponentDebugWComment=Ext.extend(Ext.Component,{
	id: "TestComponent" /* начальная инициализация */,
	constructor: function(config /* параметр, который передается из new (м.б. изменен в initComponent) */){
		config = config || /* если передан параметр из new - не имеет никакого эффекта */ { id: "_Test_constructor_Component_" };
		config.listeners = config.listeners || {};
		Ext.applyIf(config.listeners, { /* add listeners config here */	});
		Ext.apply(config, { /* stuff */ });

		if(Ext.isGecko && ("console" in window))
			console.info("1. before constructor parent");

		Test.ComponentDebugWComment.superclass.constructor.call(this, config);

		if(Ext.isGecko && ("console" in window))
			console.info("4. after constructor parent");
	},
	initComponent: function(config /* всегда undefined */){
		config=config || { id: "_Test_initComponent_Component_" };
		Ext.apply(this, Ext.apply(this.initialConfig, config)); /* изменяет значения, установленные в constructor */

		if(Ext.isGecko && ("console" in window))
			console.info("2. before initComponent parent");

		Test.ComponentDebugWComment.superclass.initComponent.apply(this, arguments);

		if(Ext.isGecko && ("console" in window))
			console.info("3. after initComponent parent");
	}
});

Test.Component=Ext.extend(Ext.Component,{
	id: "TestComponent",
	constructor: function(config){
		config = config || { id: "_Test_constructor_Component_" };
		config.listeners = config.listeners || {};
		Ext.applyIf(config.listeners, {});
		Ext.apply(config, {});
		Test.Component.superclass.constructor.call(this, config);
	},
	initComponent: function(){
		var
			config={ id: "_Test_initComponent_Component_" };

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		Test.Component.superclass.initComponent.apply(this, arguments);
	}
});
