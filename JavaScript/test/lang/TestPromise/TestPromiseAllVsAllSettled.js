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

	const promises = [
		Promise.resolve(33),
		new Promise((resolve) => setTimeout(() => resolve(66), 0)),
		99,
		Promise.reject(new Error("an error"))
	];
	
	if (testFeature === 1) {
		Promise.all(promises)
			.then(function (values) {
				if (window.console && console.log)
					console.log("%s Promise.all().then()", new Date().toISOString());

				if (Array.isArray(values)) {
					for (let i = 0, l = values.length; i < l; ++i) {
						if (window.console && console.log)
							console.log("%o", values[i]);
						
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
		Promise.allSettled(promises)
			.then(function (values) {
				if (window.console && console.log)
					console.log("%s Promise.allSettled().then()", new Date().toISOString());

				if (Array.isArray(values)) {
					for (let i = 0, l = values.length; i < l; ++i) {
						if (window.console && console.log)
							console.log("%o", values[i]);
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
