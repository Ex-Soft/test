Ext.define("TestClassI", {
	alias: "TestClassI",
	alternateClassName: "TestClassI",
	foo: function() {
		if(window.console && console.log)
			console.log("TestClassI.foo()");
	}
});
