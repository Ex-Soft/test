function DoIt() {
	if (window.console && console.clear)
		console.clear();

	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}

	Victim(document.getElementById("checkboxReject").checked)
		.then((param) => { console.log("DoIt() resolve(%s)", param) }, (param) => { console.log("DoIt() reject(%s)", param) })
		.catch(error => { console.log("DoIt() catch(%s)", error)});
}

function Victim(withReject) {
	return new Promise(function(resolve, reject) {
		var timeoutID = -1;

		if(window.console && console.log)
			console.log("Victim() %s starting...", new Date().toString());

		timeoutID = setTimeout(function() {
			if(window.console && console.log)
				console.log("Victim() %s finished (timeoutID = %i)", new Date().toString(), timeoutID);

			clearTimeout(timeoutID);

			if(window.console && console.log)
				console.log("Victim() %s finished (timeoutID = %i) before reject", new Date().toString(), timeoutID);

			if (withReject)
				reject("Victim() reject");
			
			if(window.console && console.log)
				console.log("Victim() %s finished (timeoutID = %i) after reject", new Date().toString(), timeoutID);

			if(window.console && console.log)
				console.log("Victim() %s finished (timeoutID = %i) before resolve", new Date().toString(), timeoutID);

			resolve("Victim() resolve");
			
			if(window.console && console.log)
				console.log("Victim() %s finished (timeoutID = %i) after resolve", new Date().toString(), timeoutID);
		}, 500);

		if(window.console && console.log)
			console.log("Victim() timeoutID = %i", timeoutID);
	});
}