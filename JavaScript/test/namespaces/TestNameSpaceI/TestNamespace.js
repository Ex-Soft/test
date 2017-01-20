(function() {
	var
		global=this;

	if(typeof(TestNamespace)==="undefined")
		global.TestNamespace={};

	TestNamespace.global=global;
})();