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