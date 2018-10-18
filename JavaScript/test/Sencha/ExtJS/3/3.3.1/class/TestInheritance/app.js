Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.ns("App");

App.Base = function(config) {
	Ext.apply(this, config);
}

App.Base.prototype = {
	getBaseStr1: function() {
		return this.baseStr1;
	},

	getBaseStr2: function() {
		return this.baseStr2;
	},

	foo1: function() {
		if (window.console && console.log)
			console.log("Base.foo1() (%o)", this);	
	},

	foo2: function() {
		if (window.console && console.log)
			console.log("Base.foo2() (%o)", this);
	},

	foo3: function() {
		if (window.console && console.log)
			console.log("Base.foo3() (%o)", this);	
	}
}

App.Derived = function(config) {
	App.Derived.superclass.constructor.apply(this, config);
	Ext.applyIf(this, config);
}

Ext.extend(App.Derived, App.Base, {
	statics: {
		staticFn1: function() {
			if (window.console && console.log)
				console.log("Derived.staticFn1() (%o)", this);
		}
	},

	getDerivedStr1: function() {
		return this.derivedStr1;
	},

	getDerivedStr2: function() {
		return this.derivedStr2;
	},

	foo2: function() {
		App.Derived.superclass.foo2.apply(this, arguments);

		if (window.console && console.log)
			console.log("Derived.foo2() (%o)", this);	
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		base1 = new App.Base({ baseStr1: "base1Str1", baseStr2: "base1Str2" }),
		base2 = new App.Base({ baseStr1: "base2Str1", baseStr2: "base2Str2" }),
		derived1 = new App.Derived({ baseStr1: "derived1baseStr1", baseStr2: "derived1baseStr2", derivedStr1: "derived1DerivedStr1", derivedStr2: "derived1DerivedStr2" }),
		derived2 = new App.Derived({ baseStr1: "derived2baseStr1", baseStr2: "derived2baseStr2", derivedStr1: "derived2DerivedStr1", derivedStr2: "derived2DerivedStr2" });

	if(window.console && console.log) {
		console.log("{baseStr1: \"%s\", baseStr2: \"%s\"}", base1.getBaseStr1(), base1.getBaseStr2());
		console.log("{baseStr1: \"%s\", baseStr2: \"%s\"}", base2.getBaseStr1(), base2.getBaseStr2());
		console.log("{baseStr1: \"%s\", baseStr2: \"%s\", derivedStr1: \"%s\", derivedStr2: \"%s\"}", derived1.getBaseStr1(), derived1.getBaseStr2(), derived1.getDerivedStr1(), derived1.getDerivedStr2());
		console.log("{baseStr1: \"%s\", baseStr2: \"%s\", derivedStr1: \"%s\", derivedStr2: \"%s\"}", derived2.getBaseStr1(), derived2.getBaseStr2(), derived2.getDerivedStr1(), derived2.getDerivedStr2());
	}

	base1.foo1();
	base1.foo2();
	base1.foo3();

	derived1.foo1();
	derived1.foo2();
	derived1.foo3();
});
