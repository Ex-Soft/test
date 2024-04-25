class TestClassWithReservedWords {
	constructor() {
		if (window.console && console.log)
			console.log("constructor()");
	}

	get() {
		if (window.console && console.log)
			console.log("get()");
	}

	post() {
		if (window.console && console.log)
			console.log("post()");
	}

	put() {
		if (window.console && console.log)
			console.log("put()");
	}
	
	patch() {
		if (window.console && console.log)
			console.log("patch()");
	}

	delete() {
		if (window.console && console.log)
			console.log("delete()");
	}
}

function onLoad() {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log) {
		const testClassWithReservedWords = new TestClassWithReservedWords();
		testClassWithReservedWords.get();
		testClassWithReservedWords.post();
		testClassWithReservedWords.put();
		testClassWithReservedWords.patch();
		testClassWithReservedWords.delete();
	}
}
