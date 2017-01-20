$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	$("#toolbar").kendoToolBar({
		items: [
			{ type: "button", text: "Button", attributes: { title: "Hint" } },
			{ type: "button", text: "Toggle", togglable: true },
			{ type: "splitButton", text: "SplitButton", menuButtons: [{text: "Option 1"}, {text: "Option 2"}] }
		]
	});
});
