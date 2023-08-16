function DoIt() {
	if (window.console && console.clear)
		console.clear();

	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}

	Outer()
		.then((param) => { console.log("DoIt() resolve(%s)", param) }, (param) => { console.log("DoIt() reject(%s)", param) })
		.catch(error => { console.log("DoIt() catch(%s)", error)});
}

function Outer(withReject) {
	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		if(window.console && console.log)
			console.log("Outer() %s starting...", new Date().toString());

		Inner()
			.then((param) => { console.log("Outer() resolve(%s)", param) }, (param) => { console.log("Outer() reject(%s)", param) })
			.catch(error => { console.log("Outer() catch(%s)", error)});

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("Outer() %s finished (timeoutID = %i)", new Date().toString(), timeoutID);

			clearTimeout(timeoutID);
			
			if (withReject)
				reject("Outer() reject");
			else
				resolve("Outer() resolve");
		}, 2000);

		if(window.console && console.log)
			console.log("Outer() timeoutID = %i", timeoutID);
	});
}

function Inner(withReject) {
	throw new Error("Inner() throw new Error() o_O");

	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		if(window.console && console.log)
			console.log("Inner() %s starting...", new Date().toString());

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("Inner() %s finished (timeoutID = %i)", new Date().toString(), timeoutID);

			clearTimeout(timeoutID);

			if (withReject)
				reject("Inner() reject");
			else
				resolve("Inner() resolve");
		}, 500);

		if(window.console && console.log)
			console.log("Inner() timeoutID = %i", timeoutID);
	});
}