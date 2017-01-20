$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		inpt = $("#maskedtextbox"),
		maskedtextbox = $("#maskedtextbox").kendoMaskedTextBox(),
		_inpt = $("#maskedtextbox").data("kendoMaskedTextBox"),
		_maskedtextbox = maskedtextbox.data("kendoMaskedTextBox");
});
