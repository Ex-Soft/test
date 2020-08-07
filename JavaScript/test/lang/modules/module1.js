if (window.console && console.log)
	console.log("module1.js (before)");

const SmthConst = "SmthConstValue";

export { SmthConst };

if (window.console && console.log)
	console.log("module1.js (after)");
