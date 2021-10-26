// https://www.htmlgoodies.com/javascript/spy-on-javascript-methods-using-the-jasmine-testing-framework/
// https://volaresystems.com/technical-posts/mocking-calls-with-jasmine
// https://jasmine.github.io/tutorials/your_first_suite
// https://jasmine.github.io/api/3.9/matchers.html

describe("jasmine", () => {
	it("jasmine.toBeUndefined()", () => {
		expect(a).toBeUndefined();
		expect(a).toBe(undefined);
	});
	
	it("jasmine.toBeNull()", () => {
		expect(b).toBeNull();
		expect(b).toBe(null);
		expect(b).not.toBeUndefined();
		expect(b).not.toBe(undefined);
		expect(b).toEqual(null);
	});
	
	it("jasmine.objectContaining()", () => {
		expect(foo).toEqual(jasmine.objectContaining({bar:"baz"}));
	});
	
	it("jasmine.arrayContaining()", () => {
		expect(arr).toEqual(jasmine.arrayContaining([3,1]));
		expect(arr).not.toEqual(jasmine.arrayContaining([13]));
	});
	
	it("jasmine.stringMatching()", () => {
		expect({foo: "bar"}).toEqual({foo: jasmine.stringMatching(/^bar$/)});
		expect({foo: "foobarbaz"}).toEqual({foo: jasmine.stringMatching("bar")});
	});

	it("jasmine.toBeInstanceOf()", () => {
		expect(dt).toBeInstanceOf(Date);
	});

	it("jasmine.toBeCloseTo()", () => {
		expect(num).toBeCloseTo(42.2, 3);
	});
	
	it("jasmine.toBeTrue()", () => {
		expect(bool).toBeTrue();
	});
	
	it("jasmine.toBeTruthy()", () => {
		expect(str).toBeTruthy();
		expect(str).not.toBeTrue();
	});
});

describe("Addition", function () {
	it("test add() is defined", function () {
		expect(add).toBeDefined();
	});

	it("test add 2 simple numbers", function () {
		expect(add(1,2)).toEqual(3);
	});
});

describe("Subtraction", function () {
	it("test subtract() is defined", function () {
		expect(subtract).toBeDefined();
	});

	it("test subtract 2 simple numbers", function () {
		expect(subtract(11, 2)).toEqual(9);
	});
});

describe("Multiplication", function () {
	it("test multiply() is defined", function () {
		expect(multiply).toBeDefined();
	});
});

describe("A spy", function() {
	var
		foo,
		bar = null;

	beforeEach(function() {
		foo = {
			setBar: function(value) {
				bar = value;
			}
		};

		spyOn(foo, "setBar");

		foo.setBar(123);
		foo.setBar(456, "another param");
	});

	it("tracks that the spy was called", function() {
		expect(foo.setBar).toHaveBeenCalled();
	});

	it("tracks all the arguments of its calls", function() {
		expect(foo.setBar).toHaveBeenCalledWith(123);
		expect(foo.setBar).toHaveBeenCalledWith(456, "another param");
	});

	it("stops all execution on a function", function() {
		expect(bar).toBeNull();
	});
});

describe("A spy, when configured to call through", function() {
	var
		foo,
		bar,
		fetchedBar;

	beforeEach(function() {
		foo = {
			setBar: function(value) {
				bar = value;
			},
			getBar: function() {
				return bar;
			}
		};

		spyOn(foo, "getBar").and.callThrough();

		foo.setBar(123);
		fetchedBar = foo.getBar();
	});

	it("tracks that the spy was called", function() {
		expect(foo.getBar).toHaveBeenCalled();
	});

	it("should not effect other functions", function() {
		expect(bar).toEqual(123);
	});

	it("when called returns the requested value", function() {
		expect(fetchedBar).toEqual(123);
	});
});

describe("spyOn", () => {
	let testSmthClass;
	beforeEach(() => { testSmthClass = new SmthClass() });
	afterEach(() => { testSmthClass = undefined });

	it("test call", () => {
		spyOn(testSmthClass, "smthMethod");
		testSmthClass.callerFn();
		expect(testSmthClass.smthMethod).toHaveBeenCalled();
	});
});

describe("createSpyObj", () => {
	let testSmthClass;
	beforeEach(() => { testSmthClass = new SmthClass() });
	afterEach(() => { testSmthClass = undefined });

	it("test call# 1", () => {
		testSmthClass.smthMethod = jasmine.createSpy("smthMethod spy");
		testSmthClass.callerFn();
		expect(testSmthClass.smthMethod).toHaveBeenCalled();
	});

	it("test call# 2", () => {
		testSmthClass.smthMethod = jasmine.createSpy("smthMethod() spy");
		testSmthClass.callerFn();
		expect(testSmthClass.smthMethod).toHaveBeenCalled();
	});

	it("test call# 3", () => {
		testSmthClass.smthMethod = jasmine.createSpy("smthMethod() spy").and.returnValue("test call# 3");
		testSmthClass.callerFn();
		expect(testSmthClass.smthMethod).toHaveBeenCalled();
	});

	it("test call# 4", () => {
		testSmthClass.smthMethod = jasmine.createSpy("smthMethod() spy").and.callFake(() => {
			if (window.console && console.log) {
				console.log("test call# 4");
			}
			return "test call# 4";
		});
		testSmthClass.callerFn();
		expect(testSmthClass.smthMethod).toHaveBeenCalled();
	});
});

describe("createSpyObj", () => {
	it("test call", () => {
		const spy = jasmine.createSpyObj("SmthClass", ["smthMethod"]);
		spy.smthMethod.and.returnValue("spy");
		const actual = spy.smthMethod("it");
		expect(actual).toBe("spy");
	});

	it("test call fake", () => {
		const spy = jasmine.createSpyObj("SmthClass", ["smthMethod"]);
		spy.smthMethod.and.callFake(() => {
			if (window.console && console.log) {
				console.log("callFake");
			}
			return "spy";
		});
		const actual = spy.smthMethod("it");
		expect(actual).toBe("spy");
	});
});
