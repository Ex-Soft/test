Ext.BLANK_IMAGE_URL = "../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("App");

App.A = function(config) {
	App.A.superclass.constructor.apply(this, config);
	Ext.applyIf(this, config);
}

Ext.extend(App.A, Object, {
	getStr1: function() {
		return this.str1;
	},

	getStr2: function() {
		return this.str2;
	},

	foo: function() {
		if (window.console && console.log)
			console.log("A.foo() (%o)", this);	
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
        a1 = new App.A({ str1: "a1Str1", str2: "a1Str2" }),
        a2 = new App.A({ str1: "a2Str1", str2: "a2Str2" });

	if(window.console && console.log) {
        console.log("{str1: \"%s\", str2: \"%s\"}", a1.getStr1(), a1.getStr2());
        console.log("{str1: \"%s\", str2: \"%s\"}", a2.getStr1(), a2.getStr2());
	}

	a1.foo();
	a2.foo();
});
