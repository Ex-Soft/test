$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		bus = new kendo.Observable();

	bus.bind("testEvent", function(e) {
		if (window.console && console.log)
			console.log("%o", arguments);
	});

	bus.trigger("testEvent", { data: "data" });
});
