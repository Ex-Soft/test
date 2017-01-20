Ext.define("App.classes.B2", {
	singleton: true,

	requires: [ "App.classes.A2" ],

	doSmth: function() {
		if(window.console && console.log)
			console.log("B2.doSmth()");
	},

	callA: function() {
		if(window.console && console.log)
			console.log("B2.callA()");

		App.classes.A2.doSmth();
	}
});