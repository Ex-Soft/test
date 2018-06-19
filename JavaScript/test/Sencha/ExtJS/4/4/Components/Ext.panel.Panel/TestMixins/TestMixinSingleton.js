Ext.define("TestMixinSingleton", {
	single: true,

	constructor: function(config) {
		if (window.lonsole && console.log)
			console.log("TestMixinSingleton.ctor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	doSmth: function(){
		this.html = "blah-blah-blah";
	}
});
