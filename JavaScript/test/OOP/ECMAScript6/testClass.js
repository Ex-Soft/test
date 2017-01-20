"use strict";

class Base {
	constructor(basePropA, basePropB) {
		this._basePropA = basePropA;
		this._basePropB = basePropB;
	}

	get basePropA() {
		if(window.console && console.log)
			console.log("get basePropA()");
		
		return this._basePropA;
	}

	set basePropA(value) {
		if(window.console && console.log)
			console.log("set basePropA(%s)", value);

		this._basePropA = value;
	}

	get basePropB() {
		if(window.console && console.log)
			console.log("get basePropB()");
		
		return this._basePropB;
	}

	set basePropB(value) {
		if(window.console && console.log)
			console.log("set basePropB(%s)", value);

		this._basePropB = value;
	}

	static staticFoo() {
		if(window.console && console.log)
			console.log("Base.staticFoo()");
	}

	static staticFooFoo() {
		if(window.console && console.log)
			console.log("Base.staticFooFoo()");
	}

	foo() {
		if(window.console && console.log)
			console.log("Base.foo()");
	}

	fooFoo() {
		if(window.console && console.log)
			console.log("Base.fooFoo()");
	}
}

class Derived extends Base {
	constructor(derivedPropA, derivedPropB, basePropA, basePropB) {
		super(basePropA, basePropB);
		this._derivedPropA = derivedPropA;
		this._derivedPropB = derivedPropB;
	}

	get derivedPropA() {
		if(window.console && console.log)
			console.log("get derivedPropA()");
		
		return this._derivedPropA;
	}

	set derivedPropA(value) {
		if(window.console && console.log)
			console.log("set derivedPropA(%s)", value);

		this._derivedPropA = value;
	}

	get derivedPropB() {
		if(window.console && console.log)
			console.log("get derivedPropB()");
		
		return this._derivedPropB;
	}

	set derivedPropB(value) {
		if(window.console && console.log)
			console.log("set derivedPropB(%s)", value);

		this._derivedPropB = value;
	}

	static staticFoo() {
		if(window.console && console.log)
			console.log("Derived.staticFoo()");
	}

	static staticFooFoo() {
		Base.staticFooFoo();

		if(window.console && console.log)
			console.log("Derived.staticFooFoo()");
	}

	foo() {
		if(window.console && console.log)
			console.log("Derived.foo()");
	}

	fooFoo() {
		super.fooFoo();

		if(window.console && console.log)
			console.log("Derived.fooFoo()");
	}
}

function onLoad()
{
	let
		baseVar1 = new Base("basePropAVar1", "basePropBVar1"),
		derivedVar1 = new Derived("derivedPropAVar1", "derivedPropBVar1", "derivedBasePropAVar1", "derivedBasePropBVar1");

	if(window.console && console.log)
	{
		console.log("%o", baseVar1);
		console.log("{ basePropA: \"%s\", basePropB: \"%s\" }", baseVar1.basePropA, baseVar1.basePropB);
		console.log("%o", derivedVar1);
		console.log("{ derivedPropA: \"%s\", derivedPropB: \"%s\", basePropA: \"%s\", basePropB: \"%s\" }", derivedVar1.derivedPropA, derivedVar1.derivedPropB, derivedVar1.basePropA, derivedVar1.basePropB);
		
		console.log("baseVar1 instanceof Base == %s", baseVar1 instanceof Base);
		console.log("baseVar1 instanceof Derived == %s", baseVar1 instanceof Derived);
		
		console.log("derivedVar1 instanceof Base == %s", derivedVar1 instanceof Base);
		console.log("derivedVar1 instanceof Derived == %s", derivedVar1 instanceof Derived);
	}

	baseVar1.basePropA += baseVar1.basePropA;
	baseVar1.basePropB += baseVar1.basePropB;

	derivedVar1.derivedPropA += derivedVar1.derivedPropA;
	derivedVar1.derivedPropB += derivedVar1.derivedPropB;
	derivedVar1.basePropA += derivedVar1.basePropA;
	derivedVar1.basePropB += derivedVar1.basePropB;

	if(window.console && console.log)
	{
		console.log("{ basePropA: \"%s\", basePropB: \"%s\" }", baseVar1.basePropA, baseVar1.basePropB);
		console.log("{ derivedPropA: \"%s\", derivedPropB: \"%s\", basePropA: \"%s\", basePropB: \"%s\" }", derivedVar1.derivedPropA, derivedVar1.derivedPropB, derivedVar1.basePropA, derivedVar1.basePropB);
	}

	Base.staticFoo();
	Base.staticFooFoo();
	Derived.staticFoo();
	Derived.staticFooFoo();
	
	baseVar1.foo();
	baseVar1.fooFoo();
	derivedVar1.foo();
	derivedVar1.fooFoo();
}

