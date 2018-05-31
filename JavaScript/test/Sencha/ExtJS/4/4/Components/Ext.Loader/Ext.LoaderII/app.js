Ext.Loader.setConfig({
	enabled: true, disableCaching: false
});

Ext.require([
	"TestClassI",
	"TestClassII"
]);

Ext.onReady(function() {
	if(window.console && console.log)
	{
		console.log("getNameByAlias: \"%s\", getNameByAlternate: \"%s\"", Ext.ClassManager.getNameByAlias("TestClassI"), Ext.ClassManager.getNameByAlternate("TestClassI"));
		console.log("getNameByAlias: \"%s\", getNameByAlternate: \"%s\"", Ext.ClassManager.getNameByAlias("TestClassII"), Ext.ClassManager.getNameByAlternate("TestClassII"));
	}

	var
		o1=Ext.create("TestClassI"),
		o2=Ext.create("TestClassII");

	o1.foo();
	o2.foo();
});
