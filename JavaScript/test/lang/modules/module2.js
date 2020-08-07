if (window.console && console.log)
	console.log("module2.js (before)");

function DoIt()
{
	if(window.console && console.log)
		console.log("SmthConst = \"%s\"", SmthConst);
}

function DoIt2()
{
	if(window.console && console.log)
		console.log("SmthConst = \"%s\"", SmthConst);
}

export { DoIt, DoIt2 };

if (window.console && console.log)
	console.log("module2.js (after)");
