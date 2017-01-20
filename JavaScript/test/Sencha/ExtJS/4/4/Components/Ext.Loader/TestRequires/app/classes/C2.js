Ext.define("App.classes.C2", {
	requires: [ "App.classes.A2" ],
	//uses: [ "App.classes.A2" ],

	callAB: function() {
		if(window.console && console.log)
			console.log("C2.callAB()");

		App.classes.A2.callB();
	}
});