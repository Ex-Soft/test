$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		kSelect = new kendo.ui.Select($("#victim"), {
			name: "testSelect",
			value: 2,
			dataSource: [
				{ id: 1, name: "1st" },
				{ id: 2, name: "2nd" }
			],
			dataTextField: "name",
			dataValueField: "id"
		});
});
