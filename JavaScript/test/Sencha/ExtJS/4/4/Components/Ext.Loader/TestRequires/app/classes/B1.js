Ext.define("App.classes.B1", {
	singleton: true,

	uses: [ "App.classes.A1" ],

	doSmth: function() {
		if(window.console && console.log)
			console.log("B1.doSmth()");
	},

	callA: function() {
		if(window.console && console.log)
			console.log("B1.callA()");

		App.classes.A1.doSmth();
	}
});