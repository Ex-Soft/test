$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	$("#a3").click(function(e){
		if (window.console && console.log)
			console.log("$(\"#a3\").click(%o)", arguments);

		return false;
	});

	$("#a4").on("click", function(e){
		if (window.console && console.log)
			console.log("$(\"#a4\").on(\"click\", (%o)", arguments);

		var a = $(this);
		//$("#a4").trigger("blur");
		a.trigger("blur");

		return false;
	});
});
