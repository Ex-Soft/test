function DoIt() {
	if (window.console && console.clear)
		console.clear();

	if (!window.Promise)
	{
		if (window.console && console.log)
			console.log("!window.Promise");

		return;
	}

	const testFeature = 2;

	const fetchPromises = [];
	
	for (let i = 0; i < 5; ++i)
		fetchPromises.push(getData(i));

	if (testFeature === 1) {
		Promise.all(fetchPromises)
			.then(function (responses) {
				if (window.console && console.log)
					console.log("%s Promise.all().then()", new Date().toISOString());

				if (Array.isArray(responses)) {
					for (let i = 0, l = responses.length; i < l; ++i) {
						responses[i].json()
							.then(function (data) {
								if (window.console && console.log)
									console.log("%s %o", typeof data, data);
							})
					}
				}
			})
			.catch(function () {
				if (window.console && console.log)
					console.log("%s Promise.all().catch(%o)", new Date().toISOString(), arguments);
			})
			.finally(function () {
				if (window.console && console.log)
					console.log("%s Promise.all().finally()", new Date().toISOString());
			});
	}

	if (testFeature === 2) {
		Promise.allSettled(fetchPromises)
			.then(function (promises) {
				if (window.console && console.log)
					console.log("%s Promise.allSettled().then()", new Date().toISOString());

				if (Array.isArray(promises)) {
					for (let i = 0, l = promises.length; i < l; ++i) {
						promises[i].value.json()
							.then(function (data) {
								if (window.console && console.log)
									console.log("%s %o", typeof data, data);
							})
					}
				}
			})
			.catch(function () {
				if (window.console && console.log)
					console.log("%s Promise.allSettled().catch(%o)", new Date().toISOString(), arguments);
			})
			.finally(function () {
				if (window.console && console.log)
					console.log("%s Promise.allSettled().finally()", new Date().toISOString());
			});
	}
}

function getData(i) {
	if(window.console && console.log)
		console.log("%s getData(%i)", new Date().toISOString(), i);

	return fetch(`http://localhost:5293/coop${i % 2 !== 0 ? "/get500" : ""}`);
}
