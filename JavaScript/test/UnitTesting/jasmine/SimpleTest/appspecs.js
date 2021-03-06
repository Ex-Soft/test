﻿describe("Addition", function () {
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
