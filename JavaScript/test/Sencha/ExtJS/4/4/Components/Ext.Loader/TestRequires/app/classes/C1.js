Ext.define("App.classes.C1", {
	requires: [ "App.classes.A1" ],
	//uses: [ "App.classes.A1" ],

	callAB: function() {
		if(window.console && console.log)
			console.log("C1.callAB()");

		App.classes.A1.callB();
	}
});