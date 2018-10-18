MyPanel = Ext.extend(Ext.Panel, {
	constructor: function(config){
		config = config || {};
		config.listeners = config.listeners || {};
		Ext.applyIf(config.listeners, { /* add listeners config here */ });
 		MyPanel.superclass.constructor.call(this, config);
	},
	initComponent: function(){
		MyPanel.superclass.initComponent.apply(this, arguments);
		this.addEvents("MyEvent");
	}
});

Ext.reg("mypanel", MyPanel);
