Ext.define("App.classes.A1", {
	singleton: true,

	requires: [ "App.classes.B1" ],

	doSmth: function() {
		if(window.console && console.log)
			console.log("A1.doSmth()");
	},

	callB: function() {
		if(window.console && console.log)
			console.log("A1.callB()");

		App.classes.B1.doSmth();
	}
});