function add(num1, num2) {
	return num1 + num2;
}

function subtract(num1, num2) {
	return num1 - num2;
}

function multiply(num1, num2) {
	return num1 * num2;
}

function justVoidFunction() {
	if (window.console && console.log) {
		console.log("justVoidFunction()");
	}
}

class SmthClass {
	smthMethod(param) {
		const msg = `smthMethod(${param.toString()})`;
		if (window.console && console.log) {
			console.log(msg);
		}
		return msg;
	}

	callerFn() {
		return this.smthMethod("from callerFn()");
	}
}

let smthClass = new SmthClass();
smthClass.smthMethod("app");

class ClassWithPropertiesOnly {
	constructor(data) {
		this.data = data;
	}
}

var a;
var b = null;
var foo = {
	a: 1,
	b: 2,
	bar: "baz"
};
var arr = [1,2,3,4,5];
var dt = new Date();
var num = 42.2;
var bool = true;
var str = "1";
