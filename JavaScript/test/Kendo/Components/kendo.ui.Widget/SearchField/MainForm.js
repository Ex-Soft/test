$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	$("#testInput").kendoNumericTextBox();
	
	var
		inpt = $("<input/>").attr({ type: "text" }).appendTo("body");
	
	if (inpt)
	{
		var
			searchField = inpt.kendoSearchField({
				name: "victimSearchField",
				buttonclick: function() {
					if(window.console && console.log)
						console.log("searchField.buttonclick(%o)", arguments);
				}
			}),
			_inpt = inpt.data("searchField"),
			_searchField = searchField.data("searchField");
	}
});
