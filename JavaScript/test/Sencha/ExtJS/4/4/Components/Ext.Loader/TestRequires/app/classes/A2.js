Ext.define("App.classes.A2", {
	singleton: true,

	uses: [ "App.classes.B2" ],

	doSmth: function() {
		if(window.console && console.log)
			console.log("A2.doSmth()");
	},

	callB: function() {
		if(window.console && console.log)
			console.log("A2.callB()");

		App.classes.B2.doSmth();
	}
});