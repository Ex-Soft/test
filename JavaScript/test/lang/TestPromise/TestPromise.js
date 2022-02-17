function DoIt() {
	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}


	doSomething().then(function() {
		return doSomethingElse();
	})
	.then(finalHandler);


/*
Tue Nov 10 2015 16:49:37 GMT+0200 doSomething(undefined) starting...
Tue Nov 10 2015 16:49:39 GMT+0200 doSomething(undefined) finished
Tue Nov 10 2015 16:49:39 GMT+0200 doSomethingElse(undefined) starting...
Tue Nov 10 2015 16:49:41 GMT+0200 doSomethingElse(undefined) finished
Tue Nov 10 2015 16:49:41 GMT+0200 finalHandler("resolve from doSomethingElse")
*/

/*
	doSomething().then(function() {
		doSomethingElse();
	})
	.then(finalHandler);
*/

/*
Tue Nov 10 2015 16:48:15 GMT+0200 doSomething(undefined) starting...
Tue Nov 10 2015 16:48:17 GMT+0200 doSomething(undefined) finished
Tue Nov 10 2015 16:48:17 GMT+0200 doSomethingElse(undefined) starting...
Tue Nov 10 2015 16:48:17 GMT+0200 finalHandler(undefined)
Tue Nov 10 2015 16:48:19 GMT+0200 doSomethingElse(undefined) finished
*/

/*
	doSomething().then(doSomethingElse())
	.then(finalHandler);
*/

/*
Tue Nov 10 2015 16:46:11 GMT+0200 doSomething(undefined) starting...
Tue Nov 10 2015 16:46:11 GMT+0200 doSomethingElse(undefined) starting...
Tue Nov 10 2015 16:46:13 GMT+0200 doSomething(undefined) finished
Tue Nov 10 2015 16:46:14 GMT+0200 finalHandler("resolve from doSomething")
Tue Nov 10 2015 16:46:14 GMT+0200 doSomethingElse(undefined) finished
*/

/*
	doSomething().then(doSomethingElse)
	.then(finalHandler);
*/

/*
Tue Nov 10 2015 16:43:44 GMT+0200 doSomething(undefined) starting...
Tue Nov 10 2015 16:43:46 GMT+0200 doSomething(undefined) finished
Tue Nov 10 2015 16:43:46 GMT+0200 doSomethingElse("resolve from doSomething") starting...
Tue Nov 10 2015 16:43:48 GMT+0200 doSomethingElse("resolve from doSomething") finished
Tue Nov 10 2015 16:43:48 GMT+0200 finalHandler("resolve from doSomethingElse")
*/
}

function doSomething(param) {
	if(window.console && console.log)
		console.log("%s doSomething(%o) starting...", new Date().toString(), param);

	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("%s doSomething(%o) finished", new Date().toString(), param);

			clearTimeout(timeoutID);
			resolve("resolve from doSomething");

			return "return from doSomething";
		}, 2000);
	});
}

function doSomethingElse(param) {
	if(window.console && console.log)
		console.log("%s doSomethingElse(%o) starting...", new Date().toString(), param);

	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("%s doSomethingElse(%o) finished", new Date().toString(), param);

			clearTimeout(timeoutID);
			resolve("resolve from doSomethingElse");

			return "return from doSomethingElse";
		}, 2000);
	});
}

function finalHandler(param) {
	if(window.console && console.log)
		console.log("%s finalHandler(%o)", new Date().toString(), param);	
}
