(function(global, definition) {
	var def = function() { return definition(global); };

	TestNamespace = def();
})(this, function(global) {
	var
		TestNameSpace = {};

	if(global.window)
		global.window.TestNameSpace = TestNameSpace;
});