function DoIt() {
	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}

	doSomething().then(function() {
		if(window.console && console.log)
			console.log("%s then", new Date().toString());
	});
}

function doSomething() {
	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		if(window.console && console.log)
			console.log("%s starting...", new Date().toString());

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("%s finished (timeoutID = %i)", new Date().toString(), timeoutID);

			clearTimeout(timeoutID);
			resolve();
		}, 2000);

		if(window.console && console.log)
			console.log("timeoutID = %i", timeoutID);
	});
}
