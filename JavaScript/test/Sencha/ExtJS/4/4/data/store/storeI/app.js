Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	//TestArray1(); // store.loadData(), Model with mapping (doesn't work)
	//TestArray2(); // store.loadRawData(), Model with mapping (works)
	//TestArray3();
	//TestArray4();
	//TestArray5();
	//TestArray6();
	//TestArray7();
	//TestArray8(); // store.load()/loadPage(), Model with mapping (works)
	//TestJson1();
	//TestJson2();
	//TestJson3();
	TestJson4(); // store.loadRawData(), Model with mapping (works)
	//TestJson5();
	//TestJson6();
	//TestRecord1();
});
