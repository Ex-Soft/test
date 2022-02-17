function DoIt() {
	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}

	doSomething().then(function() {
		if(window.console && console.log)
			console.log("%s then->resolve(%o)", new Date().toString(), arguments);
	}, function() {
		if(window.console && console.log)
			console.log("%s then->reject(%o)", new Date().toString(), arguments);
	}).catch(function() {
		if(window.console && console.log)
			console.log("%s catch(%o)", new Date().toString(), arguments);
	});

	doSomething().then(function() {
		if(window.console && console.log)
			console.log("%s then->resolve(%o)", new Date().toString(), arguments);
	}).catch(function() {
		if(window.console && console.log)
			console.log("%s catch(%o)", new Date().toString(), arguments);
	});

	doSomething(true).then(function() {
		if(window.console && console.log)
			console.log("%s then->resolve(%o)", new Date().toString(), arguments);
	}, function() {
		if(window.console && console.log)
			console.log("%s then->reject(%o)", new Date().toString(), arguments);
	}).catch(function() {
		if(window.console && console.log)
			console.log("%s catch(%o)", new Date().toString(), arguments);
	});

	doSomething(true).then(function() {
		if(window.console && console.log)
			console.log("%s then->resolve(%o)", new Date().toString(), arguments);
	}).catch(function() {
		if(window.console && console.log)
			console.log("%s catch(%o)", new Date().toString(), arguments);
	});
}

function doSomething(withReject) {
	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		if(window.console && console.log)
			console.log("%s starting...", new Date().toString());

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("%s finished (timeoutID = %i)", new Date().toString(), timeoutID);

			clearTimeout(timeoutID);
			
			if (withReject)
				reject("reject");
			else
				resolve("resolve");
		}, 2000);

		if(window.console && console.log)
			console.log("timeoutID = %i", timeoutID);
	});
}
