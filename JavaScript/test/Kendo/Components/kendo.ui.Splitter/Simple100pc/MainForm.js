$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	$("#splitter").kendoSplitter({
		panes: [
			{
				collapsible: true,
				min: "10%",
				max: "50%",
				size: "25%"
			},
			{ collapsed: false }
		]
	});
});
