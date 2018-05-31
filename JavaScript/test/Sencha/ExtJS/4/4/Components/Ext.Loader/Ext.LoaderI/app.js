// http://www.sencha.com/blog/using-ext-loader-for-your-application

Ext.onReady(function() {
	Ext.Loader.setConfig({ enabled: true, disableCaching: false });

	Ext.require([
		"TestClassI",
		"TestClassII"
	],
	function() {
		if(window.console && console.log)
			console.log("Ext.require.callback");

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

	if(window.console && console.log)
	{
		console.log("getNameByAlias: \"%s\", getNameByAlternate: \"%s\"", Ext.ClassManager.getNameByAlias("TestClassI"), Ext.ClassManager.getNameByAlternate("TestClassI"));
		console.log("getNameByAlias: \"%s\", getNameByAlternate: \"%s\"", Ext.ClassManager.getNameByAlias("TestClassII"), Ext.ClassManager.getNameByAlternate("TestClassII"));
	}

	var
		o1;

	try
	{
		o1=Ext.create("TestClassI");
	}
	catch(e)
	{
		if(window.console && console.log)
			console.log("%s: %s", e.name, e.message);
	}
});
