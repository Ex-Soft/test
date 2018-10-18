Bus = new Ext.util.Observable();
Bus.addEvents("myevent");

MyButton = Ext.extend(Ext.Button, {
	initComponent: function(){
		MyButton.superclass.initComponent.apply(this, arguments);
	},
	onRender: function(){
		MyButton.superclass.onRender.apply(this, arguments);
		Bus.on("myevent", this.onMyEvent, this);
	},
	onMyEvent: function(data){
		if(Ext.isGecko && ("console" in window))
			//console.log((this.id ? this.id+" " : "") + "in MyEvent" + (data ? " \""+data+"\"" : ""));
			console.info((this.id ? this.id+" " : "") + "in MyEvent" + (data ? " \""+data+"\"" : ""));
	}
});

Ext.reg("mybutton", MyButton);
