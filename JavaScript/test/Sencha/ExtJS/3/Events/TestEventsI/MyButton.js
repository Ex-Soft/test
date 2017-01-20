MyButton = Ext.extend(Ext.Button, {
	initComponent: function(){
		MyButton.superclass.initComponent.apply(this, arguments);
		
		//this.addEvents("MyEvent");
		this.addListener({
			MyEvent: {
				fn: this.onMyEvent,
				scope: this
			}
		});
	},
	onMyEvent: function(data){
		if(Ext.isGecko)
			//console.log((this.id ? this.id+" " : "") + "in MyEvent" + (data ? " \""+data+"\"" : ""));
			console.info((this.id ? this.id+" " : "") + "in MyEvent" + (data ? " \""+data+"\"" : ""));
	}
});

Ext.reg("mybutton", MyButton);
